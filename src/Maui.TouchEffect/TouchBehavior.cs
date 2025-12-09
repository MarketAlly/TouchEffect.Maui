using System.Windows.Input;
using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

/// <summary>
/// A Behavior-based alternative to TouchEffect for attaching touch feedback to elements.
/// MAUI is moving toward Behaviors over Effects, so this provides a more modern API.
/// </summary>
/// <example>
/// XAML Usage:
/// <code>
/// &lt;Button&gt;
///     &lt;Button.Behaviors&gt;
///         &lt;touch:TouchBehavior PressedScale="0.95" Command="{Binding TapCommand}" /&gt;
///     &lt;/Button.Behaviors&gt;
/// &lt;/Button&gt;
/// </code>
/// </example>
public class TouchBehavior : Behavior<VisualElement>
{
    private VisualElement? _associatedElement;

    #region Bindable Properties

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TouchBehavior));

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TouchBehavior));

    public static readonly BindableProperty LongPressCommandProperty =
        BindableProperty.Create(nameof(LongPressCommand), typeof(ICommand), typeof(TouchBehavior));

    public static readonly BindableProperty LongPressCommandParameterProperty =
        BindableProperty.Create(nameof(LongPressCommandParameter), typeof(object), typeof(TouchBehavior));

    public static readonly BindableProperty LongPressDurationProperty =
        BindableProperty.Create(nameof(LongPressDuration), typeof(int), typeof(TouchBehavior), TouchEffectConstants.Defaults.LongPressDuration);

    public static readonly BindableProperty PressedScaleProperty =
        BindableProperty.Create(nameof(PressedScale), typeof(double), typeof(TouchBehavior), TouchEffectConstants.Defaults.Scale);

    public static readonly BindableProperty PressedOpacityProperty =
        BindableProperty.Create(nameof(PressedOpacity), typeof(double), typeof(TouchBehavior), TouchEffectConstants.Defaults.Opacity);

    public static readonly BindableProperty PressedBackgroundColorProperty =
        BindableProperty.Create(nameof(PressedBackgroundColor), typeof(Color), typeof(TouchBehavior));

    public static readonly BindableProperty HoveredScaleProperty =
        BindableProperty.Create(nameof(HoveredScale), typeof(double), typeof(TouchBehavior), TouchEffectConstants.Defaults.Scale);

    public static readonly BindableProperty HoveredOpacityProperty =
        BindableProperty.Create(nameof(HoveredOpacity), typeof(double), typeof(TouchBehavior), TouchEffectConstants.Defaults.Opacity);

    public static readonly BindableProperty HoveredBackgroundColorProperty =
        BindableProperty.Create(nameof(HoveredBackgroundColor), typeof(Color), typeof(TouchBehavior));

    public static readonly BindableProperty NormalScaleProperty =
        BindableProperty.Create(nameof(NormalScale), typeof(double), typeof(TouchBehavior), TouchEffectConstants.Defaults.Scale);

    public static readonly BindableProperty NormalOpacityProperty =
        BindableProperty.Create(nameof(NormalOpacity), typeof(double), typeof(TouchBehavior), TouchEffectConstants.Defaults.Opacity);

    public static readonly BindableProperty NormalBackgroundColorProperty =
        BindableProperty.Create(nameof(NormalBackgroundColor), typeof(Color), typeof(TouchBehavior));

    public static readonly BindableProperty AnimationDurationProperty =
        BindableProperty.Create(nameof(AnimationDuration), typeof(int), typeof(TouchBehavior), TouchEffectConstants.PresetDurations.Fast);

    public static readonly BindableProperty AnimationEasingProperty =
        BindableProperty.Create(nameof(AnimationEasing), typeof(Easing), typeof(TouchBehavior));

    public static readonly BindableProperty NativeAnimationProperty =
        BindableProperty.Create(nameof(NativeAnimation), typeof(bool), typeof(TouchBehavior), false);

    public static readonly BindableProperty NativeAnimationColorProperty =
        BindableProperty.Create(nameof(NativeAnimationColor), typeof(Color), typeof(TouchBehavior));

    public static readonly BindableProperty IsToggledProperty =
        BindableProperty.Create(nameof(IsToggled), typeof(bool?), typeof(TouchBehavior), null, BindingMode.TwoWay);

    public static readonly BindableProperty IsAvailableProperty =
        BindableProperty.Create(nameof(IsAvailable), typeof(bool), typeof(TouchBehavior), true);

    #endregion

    #region Properties

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public ICommand? LongPressCommand
    {
        get => (ICommand?)GetValue(LongPressCommandProperty);
        set => SetValue(LongPressCommandProperty, value);
    }

    public object? LongPressCommandParameter
    {
        get => GetValue(LongPressCommandParameterProperty);
        set => SetValue(LongPressCommandParameterProperty, value);
    }

    public int LongPressDuration
    {
        get => (int)GetValue(LongPressDurationProperty);
        set => SetValue(LongPressDurationProperty, value);
    }

    public double PressedScale
    {
        get => (double)GetValue(PressedScaleProperty);
        set => SetValue(PressedScaleProperty, value);
    }

    public double PressedOpacity
    {
        get => (double)GetValue(PressedOpacityProperty);
        set => SetValue(PressedOpacityProperty, value);
    }

    public Color? PressedBackgroundColor
    {
        get => (Color?)GetValue(PressedBackgroundColorProperty);
        set => SetValue(PressedBackgroundColorProperty, value);
    }

    public double HoveredScale
    {
        get => (double)GetValue(HoveredScaleProperty);
        set => SetValue(HoveredScaleProperty, value);
    }

    public double HoveredOpacity
    {
        get => (double)GetValue(HoveredOpacityProperty);
        set => SetValue(HoveredOpacityProperty, value);
    }

    public Color? HoveredBackgroundColor
    {
        get => (Color?)GetValue(HoveredBackgroundColorProperty);
        set => SetValue(HoveredBackgroundColorProperty, value);
    }

    public double NormalScale
    {
        get => (double)GetValue(NormalScaleProperty);
        set => SetValue(NormalScaleProperty, value);
    }

    public double NormalOpacity
    {
        get => (double)GetValue(NormalOpacityProperty);
        set => SetValue(NormalOpacityProperty, value);
    }

    public Color? NormalBackgroundColor
    {
        get => (Color?)GetValue(NormalBackgroundColorProperty);
        set => SetValue(NormalBackgroundColorProperty, value);
    }

    public int AnimationDuration
    {
        get => (int)GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }

    public Easing? AnimationEasing
    {
        get => (Easing?)GetValue(AnimationEasingProperty);
        set => SetValue(AnimationEasingProperty, value);
    }

    public bool NativeAnimation
    {
        get => (bool)GetValue(NativeAnimationProperty);
        set => SetValue(NativeAnimationProperty, value);
    }

    public Color? NativeAnimationColor
    {
        get => (Color?)GetValue(NativeAnimationColorProperty);
        set => SetValue(NativeAnimationColorProperty, value);
    }

    public bool? IsToggled
    {
        get => (bool?)GetValue(IsToggledProperty);
        set => SetValue(IsToggledProperty, value);
    }

    public bool IsAvailable
    {
        get => (bool)GetValue(IsAvailableProperty);
        set => SetValue(IsAvailableProperty, value);
    }

    #endregion

    #region Behavior Lifecycle

    protected override void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);
        _associatedElement = bindable;

        ApplyTouchEffect();
    }

    protected override void OnDetachingFrom(VisualElement bindable)
    {
        RemoveTouchEffect();
        _associatedElement = null;

        base.OnDetachingFrom(bindable);
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        // Reapply effect when properties change
        if (_associatedElement != null && propertyName != null)
        {
            ApplyTouchEffect();
        }
    }

    #endregion

    #region Touch Effect Application

    private void ApplyTouchEffect()
    {
        if (_associatedElement == null)
            return;

        // Apply all properties via the attached property system
        TouchEffect.SetIsAvailable(_associatedElement, IsAvailable);

        if (Command != null)
            TouchEffect.SetCommand(_associatedElement, Command);
        if (CommandParameter != null)
            TouchEffect.SetCommandParameter(_associatedElement, CommandParameter);
        if (LongPressCommand != null)
            TouchEffect.SetLongPressCommand(_associatedElement, LongPressCommand);
        if (LongPressCommandParameter != null)
            TouchEffect.SetLongPressCommandParameter(_associatedElement, LongPressCommandParameter);

        TouchEffect.SetLongPressDuration(_associatedElement, LongPressDuration);

        // Visual properties
        TouchEffect.SetPressedScale(_associatedElement, PressedScale);
        TouchEffect.SetPressedOpacity(_associatedElement, PressedOpacity);
        if (PressedBackgroundColor != null)
            TouchEffect.SetPressedBackgroundColor(_associatedElement, PressedBackgroundColor);

        TouchEffect.SetHoveredScale(_associatedElement, HoveredScale);
        TouchEffect.SetHoveredOpacity(_associatedElement, HoveredOpacity);
        if (HoveredBackgroundColor != null)
            TouchEffect.SetHoveredBackgroundColor(_associatedElement, HoveredBackgroundColor);

        TouchEffect.SetNormalScale(_associatedElement, NormalScale);
        TouchEffect.SetNormalOpacity(_associatedElement, NormalOpacity);
        if (NormalBackgroundColor != null)
            TouchEffect.SetNormalBackgroundColor(_associatedElement, NormalBackgroundColor);

        // Animation
        TouchEffect.SetAnimationDuration(_associatedElement, AnimationDuration);
        if (AnimationEasing != null)
            TouchEffect.SetAnimationEasing(_associatedElement, AnimationEasing);

        // Native
        TouchEffect.SetNativeAnimation(_associatedElement, NativeAnimation);
        if (NativeAnimationColor != null)
            TouchEffect.SetNativeAnimationColor(_associatedElement, NativeAnimationColor);

        // Toggle
        if (IsToggled.HasValue)
            TouchEffect.SetIsToggled(_associatedElement, IsToggled);
    }

    private void RemoveTouchEffect()
    {
        if (_associatedElement == null)
            return;

        // Remove any TouchEffect instances
        var effects = _associatedElement.Effects;
        for (int i = effects.Count - 1; i >= 0; i--)
        {
            if (effects[i] is TouchEffect)
            {
                effects.RemoveAt(i);
            }
        }
    }

    #endregion
}
