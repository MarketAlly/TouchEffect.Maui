using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;
using Microsoft.Maui.Platform;
using System.ComponentModel;
using MarketAlly.TouchEffect.Maui.Enums;
using AView = Android.Views.View;
using Color = Android.Graphics.Color;
using Mview = Microsoft.Maui.Controls.View;
using Mcolor = Microsoft.Maui.Graphics.Color;

namespace MarketAlly.TouchEffect.Maui;

public class PlatformTouchEffect : Microsoft.Maui.Controls.Platform.PlatformEffect
{
    private static readonly Mcolor defaultNativeAnimationColor = new(
        TouchEffectConstants.Platform.Android.DefaultRippleColor,
        TouchEffectConstants.Platform.Android.DefaultRippleColor,
        TouchEffectConstants.Platform.Android.DefaultRippleColor,
        TouchEffectConstants.Platform.Android.DefaultRippleAlpha);

    AccessibilityManager? accessibilityManager;
    AccessibilityListener? accessibilityListener;
    TouchEffect? effect;
    bool isHoverSupported;
    RippleDrawable? ripple;
    AView? rippleView;
    float startX;
    float startY;
    Mcolor? rippleColor;
    int rippleRadius = TouchEffectConstants.Defaults.NativeAnimationRadius;

    AView view => Control ?? Container;

    ViewGroup? group => (Container ?? Control) as ViewGroup;

    internal bool IsCanceled { get; set; }

    bool IsAccessibilityMode => accessibilityManager != null
        && accessibilityManager.IsEnabled
        && accessibilityManager.IsTouchExplorationEnabled;

    bool IsForegroundRippleWithTapGestureRecognizer
        => ripple != null &&
            ripple.IsAlive() &&
            view.IsAlive() &&
            view.Foreground == ripple &&
            Element is Mview mauiView &&
            mauiView.GestureRecognizers.Any(gesture => gesture is TapGestureRecognizer);

    protected override void OnAttached()
    {
        if (view == null)
            return;

        effect = TouchEffect.PickFrom(Element);
        if (effect?.IsDisabled ?? true)
            return;

        effect.Element = (VisualElement)Element;

        view.Touch += OnTouch;
        UpdateClickHandler();

        accessibilityManager = view.Context?.GetSystemService(Context.AccessibilityService) as AccessibilityManager;
        if (accessibilityManager != null)
        {
            accessibilityListener = new AccessibilityListener(this);
            accessibilityManager.AddAccessibilityStateChangeListener(accessibilityListener);
            accessibilityManager.AddTouchExplorationStateChangeListener(accessibilityListener);
        }

        if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop || !effect.NativeAnimation)
            return;

        view.Clickable = true;
        view.LongClickable = true;
        CreateRipple();

        if (group == null)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                view.Foreground = ripple;

            return;
        }

        rippleView = new FrameLayout(group.Context ?? throw new NullReferenceException())
        {
            LayoutParameters = new ViewGroup.LayoutParams(-1, -1),
            Clickable = false,
            Focusable = false,
            Enabled = false,
        };
        view.LayoutChange += OnLayoutChange;
        rippleView.Background = ripple;
        group.AddView(rippleView);
        rippleView.BringToFront();
    }

    protected override void OnDetached()
    {
        if (effect?.Element == null)
            return;

        try
        {
            if (accessibilityManager != null && accessibilityListener != null)
            {
                accessibilityManager.RemoveAccessibilityStateChangeListener(accessibilityListener);
                accessibilityManager.RemoveTouchExplorationStateChangeListener(accessibilityListener);
                accessibilityListener.Dispose();
                accessibilityManager = null;
                accessibilityListener = null;
            }

            if (view != null)
            {
                view.LayoutChange -= OnLayoutChange;
                view.Touch -= OnTouch;
                view.Click -= OnClick;

                if (Build.VERSION.SdkInt >= BuildVersionCodes.M && view.Foreground == ripple)
                    view.Foreground = null;
            }

            effect.Element = null;
            effect = null;

            if (rippleView != null)
            {
                rippleView.Pressed = false;
                rippleView.Background = null;
                group?.RemoveView(rippleView);
                rippleView.Dispose();
                rippleView = null;
            }

            ripple?.Dispose();
            ripple = null;
        }
        catch (ObjectDisposedException ex)
        {
            TouchEffect.Logger.LogWarning($"Object already disposed during OnDetached: {ex.Message}", "PlatformTouchEffect.Android");
        }
        isHoverSupported = false;
    }

    protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
    {
        base.OnElementPropertyChanged(args);
        if (args.PropertyName == TouchEffect.IsAvailableProperty.PropertyName ||
            args.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
        {
            UpdateClickHandler();
        }
    }

    void UpdateClickHandler()
    {
        view.Click -= OnClick;
        if (IsAccessibilityMode || (effect?.IsAvailable ?? false) && (effect?.Element?.IsEnabled ?? false))
        {
            view.Click += OnClick;
            return;
        }
    }

    void OnTouch(object? sender, AView.TouchEventArgs e)
    {
        e.Handled = false;

        if (effect?.IsDisabled ?? true)
            return;

        if (IsAccessibilityMode)
            return;

        switch (e.Event?.ActionMasked)
        {
            case MotionEventActions.Down:
                OnTouchDown(e);
                break;
            case MotionEventActions.Up:
                OnTouchUp();
                break;
            case MotionEventActions.Cancel:
                OnTouchCancel();
                break;
            case MotionEventActions.Move:
                OnTouchMove(sender, e);
                break;
            case MotionEventActions.HoverEnter:
                OnHoverEnter();
                break;
            case MotionEventActions.HoverExit:
                OnHoverExit();
                break;
        }
    }

    void OnTouchDown(AView.TouchEventArgs e)
    {
        _ = e.Event ?? throw new NullReferenceException();

        IsCanceled = false;

        startX = e.Event.GetX();
        startY = e.Event.GetY();

        effect?.HandleUserInteraction(TouchInteractionStatus.Started);
        effect?.HandleTouch(TouchStatus.Started);

        StartRipple(e.Event.GetX(), e.Event.GetY());

        if (effect?.DisallowTouchThreshold > 0)
            group?.Parent?.RequestDisallowInterceptTouchEvent(true);
    }

    void OnTouchUp()
        => HandleEnd(effect?.Status == TouchStatus.Started ? TouchStatus.Completed : TouchStatus.Canceled);

    void OnTouchCancel()
        => HandleEnd(TouchStatus.Canceled);

    void OnTouchMove(object? sender, AView.TouchEventArgs e)
    {
        if (IsCanceled || e.Event == null)
            return;

        var diffX = Math.Abs(e.Event.GetX() - startX) / view.Context?.Resources?.DisplayMetrics?.Density ?? throw new NullReferenceException();
        var diffY = Math.Abs(e.Event.GetY() - startY) / view.Context?.Resources?.DisplayMetrics?.Density ?? throw new NullReferenceException();
        var maxDiff = Math.Max(diffX, diffY);

        var disallowTouchThreshold = effect?.DisallowTouchThreshold;
        if (disallowTouchThreshold > 0 && maxDiff > disallowTouchThreshold)
        {
            HandleEnd(TouchStatus.Canceled);
            return;
        }

        if (sender is not AView touchView)
            return;

        var screenPointerCoords = new Point(view.Left + e.Event.GetX(), view.Top + e.Event.GetY());
        var viewRect = new Rect(view.Left, view.Top, view.Right - view.Left, view.Bottom - view.Top);
        var status = viewRect.Contains(screenPointerCoords) ? TouchStatus.Started : TouchStatus.Canceled;

        if (isHoverSupported && (status == TouchStatus.Canceled && effect?.HoverStatus == HoverStatus.Entered
            || status == TouchStatus.Started && effect?.HoverStatus == HoverStatus.Exited))
            effect?.HandleHover(status == TouchStatus.Started ? HoverStatus.Entered : HoverStatus.Exited);

        if (effect?.Status != status)
        {
            effect?.HandleTouch(status);

            if (status == TouchStatus.Started)
                StartRipple(e.Event.GetX(), e.Event.GetY());
            if (status == TouchStatus.Canceled)
                EndRipple();
        }
    }

    void OnHoverEnter()
    {
        isHoverSupported = true;
        effect?.HandleHover(HoverStatus.Entered);
    }

    void OnHoverExit()
    {
        isHoverSupported = true;
        effect?.HandleHover(HoverStatus.Exited);
    }

    void OnClick(object? sender, System.EventArgs args)
    {
        if (effect?.IsDisabled ?? true)
            return;

        if (!IsAccessibilityMode)
            return;

        IsCanceled = false;
        HandleEnd(TouchStatus.Completed);
    }

    void HandleEnd(TouchStatus status)
    {
        if (IsCanceled)
            return;

        IsCanceled = true;
        if (effect?.DisallowTouchThreshold > 0)
            group?.Parent?.RequestDisallowInterceptTouchEvent(false);

        effect?.HandleTouch(status);

        effect?.HandleUserInteraction(TouchInteractionStatus.Completed);

        EndRipple();
    }

    void StartRipple(float x, float y)
    {
        if (effect?.IsDisabled ?? true)
            return;

        if (effect.CanExecute && effect.NativeAnimation)
        {
            UpdateRipple();
            if (rippleView != null)
            {
                rippleView.Enabled = true;
                rippleView.BringToFront();
                ripple?.SetHotspot(x, y);
                rippleView.Pressed = true;
            }
            else if (IsForegroundRippleWithTapGestureRecognizer)
            {
                ripple?.SetHotspot(x, y);
                view.Pressed = true;
            }
        }
    }

    void EndRipple()
    {
        if (effect?.IsDisabled ?? true)
            return;

        if (rippleView != null)
        {
            if (rippleView.Pressed)
            {
                rippleView.Pressed = false;
                rippleView.Enabled = false;
            }
        }
        else if (IsForegroundRippleWithTapGestureRecognizer)
        {
            if (view.Pressed)
                view.Pressed = false;
        }
    }

    void CreateRipple()
    {
        var drawable = Build.VERSION.SdkInt >= BuildVersionCodes.M && group == null
            ? view?.Foreground
            : view?.Background;

        var isEmptyDrawable = Element is Layout || drawable == null;

        if (drawable is RippleDrawable rippleDrawable && rippleDrawable.GetConstantState() is Drawable.ConstantState constantState)
            ripple = (RippleDrawable)constantState.NewDrawable();
        else
            ripple = new RippleDrawable(GetColorStateList(), isEmptyDrawable ? null : drawable, isEmptyDrawable ? new ColorDrawable(Color.White) : null);

        UpdateRipple();
    }

    void UpdateRipple()
    {
        if (effect?.IsDisabled ?? true)
            return;

        if (effect.NativeAnimationColor == rippleColor && effect.NativeAnimationRadius == rippleRadius)
            return;

        rippleColor = effect.NativeAnimationColor;
        rippleRadius = effect.NativeAnimationRadius;
        ripple?.SetColor(GetColorStateList());
        if (Build.VERSION.SdkInt >= BuildVersionCodes.M && ripple != null)
            ripple.Radius = (int)(view.Context?.Resources?.DisplayMetrics?.Density * effect?.NativeAnimationRadius ?? throw new NullReferenceException());
    }

    ColorStateList GetColorStateList()
    {
        var nativeAnimationColor = effect?.NativeAnimationColor;
        nativeAnimationColor ??= defaultNativeAnimationColor;

        return new ColorStateList(
            new[] { new int[] { } },
            new[] { (int)nativeAnimationColor.ToPlatform() });
    }

    void OnLayoutChange(object? sender, AView.LayoutChangeEventArgs e)
    {
        if (sender is not AView layoutView || group == null || rippleView == null)
            return;

        rippleView.Right = layoutView.Width;
        rippleView.Bottom = layoutView.Height;
    }

    sealed class AccessibilityListener : Java.Lang.Object,
                                         AccessibilityManager.IAccessibilityStateChangeListener,
                                         AccessibilityManager.ITouchExplorationStateChangeListener
    {
        PlatformTouchEffect? platformTouchEffect;

        internal AccessibilityListener(PlatformTouchEffect platformTouchEffect)
            => this.platformTouchEffect = platformTouchEffect;

        public void OnAccessibilityStateChanged(bool enabled)
            => platformTouchEffect?.UpdateClickHandler();

        public void OnTouchExplorationStateChanged(bool enabled)
            => platformTouchEffect?.UpdateClickHandler();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                platformTouchEffect = null;

            base.Dispose(disposing);
        }
    }
}
