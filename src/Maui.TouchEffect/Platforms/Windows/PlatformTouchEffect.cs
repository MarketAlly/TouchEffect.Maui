using MarketAlly.TouchEffect.Maui.Enums;
using MarketAlly.TouchEffect.Maui.Extensions;
using Microsoft.Maui.Controls.Platform;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using System.Numerics;
using Windows.Foundation;
using Microsoft.UI.Input;
using WinUI = Microsoft.UI.Xaml.Controls;
using WinBrush = Microsoft.UI.Xaml.Media.Brush;
using WinSolidColorBrush = Microsoft.UI.Xaml.Media.SolidColorBrush;
using WinPoint = Windows.Foundation.Point;

namespace MarketAlly.TouchEffect.Maui;

public class PlatformTouchEffect : Microsoft.Maui.Controls.Platform.PlatformEffect
{
    private TouchEffect? _effect;
    private FrameworkElement? _view;
    private bool _isPressed;
    private bool _isHovered;
    private WinPoint _startPoint;
    private CompositeTransform? _compositeTransform;
    private Storyboard? _pressStoryboard;
    private Storyboard? _releaseStoryboard;
    private Storyboard? _hoverStoryboard;
    private WinBrush? _originalBrush;
    private double _originalOpacity;

    // Pointer capture for proper touch handling
    private uint? _capturedPointerId;
    private PointerPoint? _startPointerPoint;

    protected override void OnAttached()
    {
        _effect = TouchEffect.PickFrom(Element);
        if (_effect?.IsDisabled ?? true)
        {
            return;
        }

        _effect.Element = (VisualElement)Element;

        // Try to get the native view - Control first, then Container
        var view = Control as FrameworkElement ?? Container as FrameworkElement;

        if (view == null)
        {
            return;
        }

        _view = view;

        // Store original values
        _originalOpacity = _view.Opacity;
        if (_view is WinUI.Control control)
        {
            _originalBrush = control.Background;
        }

        // Set up transform for animations
        SetupTransform();

        // Attach event handlers
        AttachEventHandlers();

        // Enable hit testing
        _view.IsHitTestVisible = true;
    }

    protected override void OnDetached()
    {
        if (_effect?.Element == null || _view == null)
            return;

        try
        {
            // Clean up event handlers
            DetachEventHandlers();

            // Clean up animations
            CleanupAnimations();

            // Restore original values
            if (_view != null)
            {
                _view.Opacity = _originalOpacity;
                if (_view is WinUI.Control control && _originalBrush != null)
                {
                    control.Background = _originalBrush;
                }
                _view.RenderTransform = null;
            }

            _effect.Element = null;
            _effect = null;
            _view = null;
        }
        catch (Exception ex)
        {
            TouchEffect.Logger.LogError(ex, "PlatformTouchEffect.Windows.OnDetached", "Error during cleanup");
        }
    }

    private void SetupTransform()
    {
        if (_view == null)
            return;

        _compositeTransform = new CompositeTransform
        {
            CenterX = _view.ActualWidth / 2,
            CenterY = _view.ActualHeight / 2
        };
        _view.RenderTransform = _compositeTransform;

        // Update transform center when size changes
        _view.SizeChanged += OnViewSizeChanged;
    }

    private void OnViewSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (_compositeTransform != null)
        {
            _compositeTransform.CenterX = e.NewSize.Width / 2;
            _compositeTransform.CenterY = e.NewSize.Height / 2;
        }
    }

    private void AttachEventHandlers()
    {
        if (_view == null)
        {
            return;
        }

        // Pointer events for touch, mouse, and pen
        _view.PointerPressed += OnPointerPressed;
        _view.PointerReleased += OnPointerReleased;
        _view.PointerCanceled += OnPointerCanceled;
        _view.PointerCaptureLost += OnPointerCaptureLost;
        _view.PointerMoved += OnPointerMoved;

        // Hover events
        _view.PointerEntered += OnPointerEntered;
        _view.PointerExited += OnPointerExited;

        // Keyboard support for accessibility
        _view.KeyDown += OnKeyDown;
        _view.KeyUp += OnKeyUp;

        // Focus events
        _view.GotFocus += OnGotFocus;
        _view.LostFocus += OnLostFocus;
    }

    private void DetachEventHandlers()
    {
        if (_view == null)
            return;

        _view.PointerPressed -= OnPointerPressed;
        _view.PointerReleased -= OnPointerReleased;
        _view.PointerCanceled -= OnPointerCanceled;
        _view.PointerCaptureLost -= OnPointerCaptureLost;
        _view.PointerMoved -= OnPointerMoved;
        _view.PointerEntered -= OnPointerEntered;
        _view.PointerExited -= OnPointerExited;
        _view.KeyDown -= OnKeyDown;
        _view.KeyUp -= OnKeyUp;
        _view.GotFocus -= OnGotFocus;
        _view.LostFocus -= OnLostFocus;
        _view.SizeChanged -= OnViewSizeChanged;
    }

    private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        if (_effect == null || _effect.IsDisabled || _view == null)
        {
            return;
        }

        var pointer = e.GetCurrentPoint(_view);
        _startPointerPoint = pointer;
        _startPoint = pointer.Position;
        _isPressed = true;

        // Capture the pointer for this interaction
        _capturedPointerId = e.Pointer.PointerId;
        try
        {
            _view.CapturePointer(e.Pointer);
        }
        catch (Exception ex)
        {
            TouchEffect.Logger.LogWarning($"Failed to capture pointer: {ex.Message}", "PlatformTouchEffect.Windows");
        }

        // Handle the touch interaction
        HandleTouch(TouchStatus.Started, TouchInteractionStatus.Started);

        // Start long press detection
        StartLongPressDetection();

        e.Handled = true;
    }

    private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
    {
        if (_effect == null || _effect.IsDisabled)
            return;

        var pointer = e.GetCurrentPoint(_view);

        // Check if this is the pointer we're tracking (or if we're pressed but lost the ID somehow)
        if (_isPressed && (_capturedPointerId == null || _capturedPointerId == e.Pointer.PointerId))
        {
            _isPressed = false;
            _capturedPointerId = null;

            try
            {
                _view?.ReleasePointerCapture(e.Pointer);
            }
            catch (Exception ex)
            {
                TouchEffect.Logger.LogWarning($"Failed to release pointer capture: {ex.Message}", "PlatformTouchEffect.Windows");
            }

            // Determine if this is a completed tap or canceled
            var distance = CalculateDistance(_startPoint, pointer.Position);
            var threshold = _effect.DisallowTouchThreshold > 0
                ? _effect.DisallowTouchThreshold
                : TouchEffectConstants.Platform.Windows.DefaultMovementThreshold;

            if (distance <= threshold)
            {
                HandleTouch(TouchStatus.Completed, TouchInteractionStatus.Completed);
            }
            else
            {
                HandleTouch(TouchStatus.Canceled, TouchInteractionStatus.Completed);
            }

            CancelLongPressDetection();
        }

        e.Handled = true;
    }

    private void OnPointerCanceled(object sender, PointerRoutedEventArgs e)
    {
        HandleCancellation();
        e.Handled = true;
    }

    private void OnPointerCaptureLost(object sender, PointerRoutedEventArgs e)
    {
        HandleCancellation();
    }

    private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
    {
        if (_effect == null || _effect.IsDisabled || !_isPressed || _view == null)
            return;

        var pointer = e.GetCurrentPoint(_view);
        var distance = CalculateDistance(_startPoint, pointer.Position);
        var threshold = _effect.DisallowTouchThreshold > 0
            ? _effect.DisallowTouchThreshold
            : TouchEffectConstants.Platform.Windows.DefaultMovementThreshold;

        // Cancel if moved too far
        if (distance > threshold)
        {
            HandleCancellation();
        }
    }

    private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
    {
        if (_effect == null || _effect.IsDisabled)
            return;

        _isHovered = true;
        _effect.HandleHover(HoverStatus.Entered);
        UpdateVisualState();
    }

    private void OnPointerExited(object sender, PointerRoutedEventArgs e)
    {
        if (_effect == null || _effect.IsDisabled)
            return;

        _isHovered = false;
        _effect.HandleHover(HoverStatus.Exited);
        UpdateVisualState();
    }

    private void OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (_effect == null || _effect.IsDisabled)
            return;

        // Handle Space and Enter for accessibility
        if (e.Key == Windows.System.VirtualKey.Space || e.Key == Windows.System.VirtualKey.Enter)
        {
            if (!_isPressed)
            {
                _isPressed = true;
                HandleTouch(TouchStatus.Started, TouchInteractionStatus.Started);
                e.Handled = true;
            }
        }
    }

    private void OnKeyUp(object sender, KeyRoutedEventArgs e)
    {
        if (_effect == null || _effect.IsDisabled)
            return;

        if (e.Key == Windows.System.VirtualKey.Space || e.Key == Windows.System.VirtualKey.Enter)
        {
            if (_isPressed)
            {
                _isPressed = false;
                HandleTouch(TouchStatus.Completed, TouchInteractionStatus.Completed);
                e.Handled = true;
            }
        }
    }

    private void OnGotFocus(object sender, RoutedEventArgs e)
    {
        // Could add focus visual state here if needed
    }

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (_isPressed)
        {
            HandleCancellation();
        }
    }

    private void HandleCancellation()
    {
        if (_effect == null || !_isPressed)
            return;

        _isPressed = false;
        _capturedPointerId = null;
        _view?.ReleasePointerCaptures();

        HandleTouch(TouchStatus.Canceled, TouchInteractionStatus.Completed);
        CancelLongPressDetection();
    }

    private void HandleTouch(TouchStatus status, TouchInteractionStatus interactionStatus)
    {
        _effect?.HandleTouch(status);
        _effect?.HandleUserInteraction(interactionStatus);
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        if (_effect == null || _view == null)
            return;

        // Determine target values based on state
        double targetOpacity = _originalOpacity;
        double targetScale = TouchEffectConstants.Defaults.Scale;
        double targetTranslationX = TouchEffectConstants.Defaults.TranslationX;
        double targetTranslationY = TouchEffectConstants.Defaults.TranslationY;
        double targetRotation = TouchEffectConstants.Defaults.Rotation;
        WinBrush? targetBrush = _originalBrush;

        if (_isPressed && _effect.State == TouchState.Pressed)
        {
            targetOpacity = _effect.PressedOpacity;
            targetScale = _effect.PressedScale;
            targetTranslationX = _effect.PressedTranslationX;
            targetTranslationY = _effect.PressedTranslationY;
            targetRotation = _effect.PressedRotation;

            var pressedColor = _effect.PressedBackgroundColor;
            if (pressedColor != null && pressedColor != Microsoft.Maui.Graphics.Colors.Transparent)
            {
                targetBrush = new WinSolidColorBrush(Windows.UI.Color.FromArgb(
                    (byte)(pressedColor.Alpha * 255),
                    (byte)(pressedColor.Red * 255),
                    (byte)(pressedColor.Green * 255),
                    (byte)(pressedColor.Blue * 255)));
            }
        }
        else if (_isHovered && _effect.HoverState == HoverState.Hovered)
        {
            targetOpacity = _effect.HoveredOpacity;
            targetScale = _effect.HoveredScale;
            targetTranslationX = _effect.HoveredTranslationX;
            targetTranslationY = _effect.HoveredTranslationY;
            targetRotation = _effect.HoveredRotation;

            var hoveredColor = _effect.HoveredBackgroundColor;
            if (hoveredColor != null && hoveredColor != Microsoft.Maui.Graphics.Colors.Transparent)
            {
                targetBrush = new WinSolidColorBrush(Windows.UI.Color.FromArgb(
                    (byte)(hoveredColor.Alpha * 255),
                    (byte)(hoveredColor.Red * 255),
                    (byte)(hoveredColor.Green * 255),
                    (byte)(hoveredColor.Blue * 255)));
            }
        }
        else
        {
            targetOpacity = _effect.NormalOpacity;
            targetScale = _effect.NormalScale;
            targetTranslationX = _effect.NormalTranslationX;
            targetTranslationY = _effect.NormalTranslationY;
            targetRotation = _effect.NormalRotation;

            var normalColor = _effect.NormalBackgroundColor;
            if (normalColor != null && normalColor != Microsoft.Maui.Graphics.Colors.Transparent)
            {
                targetBrush = new WinSolidColorBrush(Windows.UI.Color.FromArgb(
                    (byte)(normalColor.Alpha * 255),
                    (byte)(normalColor.Red * 255),
                    (byte)(normalColor.Green * 255),
                    (byte)(normalColor.Blue * 255)));
            }
        }

        // Apply animations
        var duration = GetAnimationDuration();
        if (duration > 0)
        {
            AnimateToState(targetOpacity, targetScale, targetTranslationX, targetTranslationY,
                          targetRotation, targetBrush, duration);
        }
        else
        {
            // Apply immediately without animation
            _view.Opacity = targetOpacity;
            if (_compositeTransform != null)
            {
                _compositeTransform.ScaleX = targetScale;
                _compositeTransform.ScaleY = targetScale;
                _compositeTransform.TranslateX = targetTranslationX;
                _compositeTransform.TranslateY = targetTranslationY;
                _compositeTransform.Rotation = targetRotation;
            }
            if (_view is WinUI.Control control && targetBrush != null)
            {
                control.Background = targetBrush;
            }
        }
    }

    private void AnimateToState(double opacity, double scale, double translateX, double translateY,
                                double rotation, WinBrush? brush, int durationMs)
    {
        if (_view == null || _compositeTransform == null)
            return;

        var storyboard = new Storyboard();
        var duration = new Duration(TimeSpan.FromMilliseconds(durationMs));
        var easing = GetEasingFunction();

        // Opacity animation
        var opacityAnimation = new DoubleAnimation
        {
            To = opacity,
            Duration = duration,
            EasingFunction = easing
        };
        Storyboard.SetTarget(opacityAnimation, _view);
        Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
        storyboard.Children.Add(opacityAnimation);

        // Scale X animation
        var scaleXAnimation = new DoubleAnimation
        {
            To = scale,
            Duration = duration,
            EasingFunction = easing
        };
        Storyboard.SetTarget(scaleXAnimation, _compositeTransform);
        Storyboard.SetTargetProperty(scaleXAnimation, "ScaleX");
        storyboard.Children.Add(scaleXAnimation);

        // Scale Y animation
        var scaleYAnimation = new DoubleAnimation
        {
            To = scale,
            Duration = duration,
            EasingFunction = easing
        };
        Storyboard.SetTarget(scaleYAnimation, _compositeTransform);
        Storyboard.SetTargetProperty(scaleYAnimation, "ScaleY");
        storyboard.Children.Add(scaleYAnimation);

        // TranslateX animation
        var translateXAnimation = new DoubleAnimation
        {
            To = translateX,
            Duration = duration,
            EasingFunction = easing
        };
        Storyboard.SetTarget(translateXAnimation, _compositeTransform);
        Storyboard.SetTargetProperty(translateXAnimation, "TranslateX");
        storyboard.Children.Add(translateXAnimation);

        // TranslateY animation
        var translateYAnimation = new DoubleAnimation
        {
            To = translateY,
            Duration = duration,
            EasingFunction = easing
        };
        Storyboard.SetTarget(translateYAnimation, _compositeTransform);
        Storyboard.SetTargetProperty(translateYAnimation, "TranslateY");
        storyboard.Children.Add(translateYAnimation);

        // Rotation animation
        var rotationAnimation = new DoubleAnimation
        {
            To = rotation,
            Duration = duration,
            EasingFunction = easing
        };
        Storyboard.SetTarget(rotationAnimation, _compositeTransform);
        Storyboard.SetTargetProperty(rotationAnimation, "Rotation");
        storyboard.Children.Add(rotationAnimation);

        // Background color animation if control supports it
        if (_view is WinUI.Control control && brush is WinSolidColorBrush solidBrush)
        {
            control.Background = brush;
        }

        // Handle pulse/ripple count
        if (_effect?.PulseCount != 0)
        {
            var pulseCount = _effect?.PulseCount ?? TouchEffectConstants.Defaults.PulseCount;
            if (pulseCount < 0)
            {
                storyboard.RepeatBehavior = RepeatBehavior.Forever;
            }
            else if (pulseCount > 1)
            {
                storyboard.RepeatBehavior = new RepeatBehavior(pulseCount);
                storyboard.AutoReverse = true;
            }
        }

        storyboard.Begin();
    }

    private int GetAnimationDuration()
    {
        if (_effect == null)
            return TouchEffectConstants.Animation.DefaultDuration;

        // Determine which animation duration to use
        if (_isPressed)
        {
            return _effect.PressedAnimationDuration > 0
                ? _effect.PressedAnimationDuration
                : _effect.AnimationDuration;
        }
        else if (_isHovered)
        {
            return _effect.HoveredAnimationDuration > 0
                ? _effect.HoveredAnimationDuration
                : _effect.AnimationDuration;
        }
        else
        {
            return _effect.NormalAnimationDuration > 0
                ? _effect.NormalAnimationDuration
                : _effect.AnimationDuration;
        }
    }

    private EasingFunctionBase? GetEasingFunction()
    {
        if (_effect == null)
            return null;

        // Get the appropriate easing
        Microsoft.Maui.Easing? mauiEasing = null;

        if (_isPressed)
        {
            mauiEasing = _effect.PressedAnimationEasing ?? _effect.AnimationEasing;
        }
        else if (_isHovered)
        {
            mauiEasing = _effect.HoveredAnimationEasing ?? _effect.AnimationEasing;
        }
        else
        {
            mauiEasing = _effect.NormalAnimationEasing ?? _effect.AnimationEasing;
        }

        // Convert MAUI easing to WinUI easing
        if (mauiEasing == null)
            return null;

        // Map common easings
        if (mauiEasing == Microsoft.Maui.Easing.Linear)
            return null; // Linear is default, no easing function needed
        if (mauiEasing == Microsoft.Maui.Easing.CubicIn)
            return new CubicEase { EasingMode = EasingMode.EaseIn };
        if (mauiEasing == Microsoft.Maui.Easing.CubicOut)
            return new CubicEase { EasingMode = EasingMode.EaseOut };
        if (mauiEasing == Microsoft.Maui.Easing.CubicInOut)
            return new CubicEase { EasingMode = EasingMode.EaseInOut };
        if (mauiEasing == Microsoft.Maui.Easing.BounceIn)
            return new BounceEase { EasingMode = EasingMode.EaseIn };
        if (mauiEasing == Microsoft.Maui.Easing.BounceOut)
            return new BounceEase { EasingMode = EasingMode.EaseOut };
        if (mauiEasing == Microsoft.Maui.Easing.SinIn)
            return new SineEase { EasingMode = EasingMode.EaseIn };
        if (mauiEasing == Microsoft.Maui.Easing.SinOut)
            return new SineEase { EasingMode = EasingMode.EaseOut };
        if (mauiEasing == Microsoft.Maui.Easing.SinInOut)
            return new SineEase { EasingMode = EasingMode.EaseInOut };

        // Default to cubic for unrecognized easings
        return new CubicEase { EasingMode = EasingMode.EaseInOut };
    }

    private double CalculateDistance(WinPoint p1, WinPoint p2)
    {
        var dx = p2.X - p1.X;
        var dy = p2.Y - p1.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    private void CleanupAnimations()
    {
        _pressStoryboard?.Stop();
        _releaseStoryboard?.Stop();
        _hoverStoryboard?.Stop();
        _pressStoryboard = null;
        _releaseStoryboard = null;
        _hoverStoryboard = null;
    }

    #region Long Press Support

    private System.Threading.CancellationTokenSource? _longPressCts;

    private async void StartLongPressDetection()
    {
        if (_effect == null || _effect.LongPressCommand == null)
            return;

        CancelLongPressDetection();
        _longPressCts = new System.Threading.CancellationTokenSource();

        try
        {
            var duration = _effect.LongPressDuration > 0
                ? _effect.LongPressDuration
                : TouchEffectConstants.Defaults.LongPressDuration;
            await Task.Delay(duration, _longPressCts.Token);

            if (!_longPressCts.Token.IsCancellationRequested && _isPressed)
            {
                _effect.RaiseLongPressCompleted();
            }
        }
        catch (TaskCanceledException)
        {
            // Expected when gesture is canceled
        }
        catch (Exception ex)
        {
            TouchEffect.Logger.LogError(ex, "PlatformTouchEffect.Windows.StartLongPressDetection", "Error during long press detection");
        }
    }

    private void CancelLongPressDetection()
    {
        var cts = _longPressCts;
        _longPressCts = null;

        if (cts != null)
        {
            try
            {
                cts.Cancel();
                cts.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // Already disposed
            }
        }
    }

    #endregion
}
