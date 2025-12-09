using System.Windows.Input;

namespace MarketAlly.TouchEffect.Maui;

/// <summary>
/// Fluent builder for configuring TouchEffect with a clean API.
/// </summary>
public class TouchEffectBuilder
{
    private readonly VisualElement element;
    private ICommand? command;
    private object? commandParameter;
    private ICommand? longPressCommand;
    private object? longPressCommandParameter;
    private int longPressDuration = TouchEffectConstants.Defaults.LongPressDuration;

    // Visual properties
    private double pressedOpacity = TouchEffectConstants.Defaults.Opacity;
    private double pressedScale = TouchEffectConstants.Defaults.Scale;
    private Color? pressedBackgroundColor;
    private double hoveredOpacity = TouchEffectConstants.Defaults.Opacity;
    private double hoveredScale = TouchEffectConstants.Defaults.Scale;
    private Color? hoveredBackgroundColor;
    private double normalOpacity = TouchEffectConstants.Defaults.Opacity;
    private double normalScale = TouchEffectConstants.Defaults.Scale;
    private Color? normalBackgroundColor;

    // Animation properties
    private int animationDuration = TouchEffectConstants.PresetDurations.Normal;
    private Easing? animationEasing;
    private int pressedAnimationDuration;
    private Easing? pressedAnimationEasing;
    private int hoveredAnimationDuration;
    private Easing? hoveredAnimationEasing;
    private int pulseCount = 1;

    // Native animation properties
    private bool nativeAnimation;
    private Color? nativeAnimationColor;
    private int nativeAnimationRadius = TouchEffectConstants.Defaults.NativeAnimationRadius;

    // Other properties
    private bool? isToggled;
    private int disallowTouchThreshold = TouchEffectConstants.Defaults.DisallowTouchThreshold;
    private bool isAvailable = true;

    /// <summary>
    /// Creates a new TouchEffectBuilder for the specified element.
    /// </summary>
    /// <param name="element">The visual element to apply the effect to.</param>
    public TouchEffectBuilder(VisualElement element)
    {
        this.element = element ?? throw new ArgumentNullException(nameof(element));
    }

    /// <summary>
    /// Creates a builder for the specified element.
    /// </summary>
    public static TouchEffectBuilder For(VisualElement element) => new(element);

    #region Command Configuration

    /// <summary>
    /// Sets the command to execute on tap.
    /// </summary>
    public TouchEffectBuilder WithCommand(ICommand command, object? parameter = null)
    {
        this.command = command;
        this.commandParameter = parameter;
        return this;
    }

    /// <summary>
    /// Sets the command to execute on long press.
    /// </summary>
    public TouchEffectBuilder WithLongPressCommand(ICommand command, object? parameter = null)
    {
        this.longPressCommand = command;
        this.longPressCommandParameter = parameter;
        return this;
    }

    /// <summary>
    /// Sets the duration for long press detection.
    /// </summary>
    public TouchEffectBuilder WithLongPressDuration(int milliseconds)
    {
        this.longPressDuration = milliseconds;
        return this;
    }

    #endregion

    #region Visual Configuration

    /// <summary>
    /// Configures the pressed state appearance.
    /// </summary>
    public TouchEffectBuilder WithPressedState(double? opacity = null, double? scale = null, Color? backgroundColor = null)
    {
        if (opacity.HasValue) pressedOpacity = opacity.Value;
        if (scale.HasValue) pressedScale = scale.Value;
        if (backgroundColor != null) pressedBackgroundColor = backgroundColor;
        return this;
    }

    /// <summary>
    /// Configures the hovered state appearance.
    /// </summary>
    public TouchEffectBuilder WithHoveredState(double? opacity = null, double? scale = null, Color? backgroundColor = null)
    {
        if (opacity.HasValue) hoveredOpacity = opacity.Value;
        if (scale.HasValue) hoveredScale = scale.Value;
        if (backgroundColor != null) hoveredBackgroundColor = backgroundColor;
        return this;
    }

    /// <summary>
    /// Configures the normal state appearance.
    /// </summary>
    public TouchEffectBuilder WithNormalState(double? opacity = null, double? scale = null, Color? backgroundColor = null)
    {
        if (opacity.HasValue) normalOpacity = opacity.Value;
        if (scale.HasValue) normalScale = scale.Value;
        if (backgroundColor != null) normalBackgroundColor = backgroundColor;
        return this;
    }

    /// <summary>
    /// Sets only the pressed opacity.
    /// </summary>
    public TouchEffectBuilder WithPressedOpacity(double opacity)
    {
        this.pressedOpacity = opacity;
        return this;
    }

    /// <summary>
    /// Sets only the pressed scale.
    /// </summary>
    public TouchEffectBuilder WithPressedScale(double scale)
    {
        this.pressedScale = scale;
        return this;
    }

    /// <summary>
    /// Sets only the pressed background color.
    /// </summary>
    public TouchEffectBuilder WithPressedBackgroundColor(Color color)
    {
        this.pressedBackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets only the hovered scale.
    /// </summary>
    public TouchEffectBuilder WithHoveredScale(double scale)
    {
        this.hoveredScale = scale;
        return this;
    }

    #endregion

    #region Animation Configuration

    /// <summary>
    /// Sets the animation duration and optional easing.
    /// </summary>
    public TouchEffectBuilder WithAnimation(int duration, Easing? easing = null)
    {
        this.animationDuration = duration;
        this.animationEasing = easing;
        return this;
    }

    /// <summary>
    /// Sets animation for pressed state.
    /// </summary>
    public TouchEffectBuilder WithPressedAnimation(int duration, Easing? easing = null)
    {
        this.pressedAnimationDuration = duration;
        this.pressedAnimationEasing = easing;
        return this;
    }

    /// <summary>
    /// Sets animation for hovered state.
    /// </summary>
    public TouchEffectBuilder WithHoveredAnimation(int duration, Easing? easing = null)
    {
        this.hoveredAnimationDuration = duration;
        this.hoveredAnimationEasing = easing;
        return this;
    }

    /// <summary>
    /// Sets the pulse/ripple count.
    /// </summary>
    public TouchEffectBuilder WithPulse(int count)
    {
        this.pulseCount = count;
        return this;
    }

    /// <summary>
    /// Enables infinite pulse.
    /// </summary>
    public TouchEffectBuilder WithInfinitePulse()
    {
        this.pulseCount = -1;
        return this;
    }

    #endregion

    #region Native Animation Configuration

    /// <summary>
    /// Enables native platform animations.
    /// </summary>
    public TouchEffectBuilder WithNativeAnimation(Color? color = null, int radius = -1)
    {
        this.nativeAnimation = true;
        this.nativeAnimationColor = color;
        this.nativeAnimationRadius = radius;
        return this;
    }

    #endregion

    #region Toggle Configuration

    /// <summary>
    /// Enables toggle behavior.
    /// </summary>
    public TouchEffectBuilder AsToggle(bool initialState = false)
    {
        this.isToggled = initialState;
        return this;
    }

    #endregion

    #region Other Configuration

    /// <summary>
    /// Sets the movement threshold for touch cancellation.
    /// </summary>
    public TouchEffectBuilder WithDisallowThreshold(int pixels)
    {
        this.disallowTouchThreshold = pixels;
        return this;
    }

    /// <summary>
    /// Disables the effect.
    /// </summary>
    public TouchEffectBuilder Disable()
    {
        this.isAvailable = false;
        return this;
    }

    #endregion

    #region Preset Methods

    /// <summary>
    /// Applies a button preset with standard press effect.
    /// </summary>
    public TouchEffectBuilder AsButton()
    {
        return WithPressedOpacity(0.7)
            .WithAnimation(TouchEffectConstants.PresetDurations.Fast, Easing.CubicOut);
    }

    /// <summary>
    /// Applies a card preset with subtle scale effect.
    /// </summary>
    public TouchEffectBuilder AsCard()
    {
        return WithPressedScale(0.97)
            .WithAnimation(TouchEffectConstants.PresetDurations.Normal, Easing.CubicInOut)
            .WithHoveredScale(1.02);
    }

    /// <summary>
    /// Applies a list item preset with background color change.
    /// </summary>
    public TouchEffectBuilder AsListItem()
    {
        return WithPressedBackgroundColor(Colors.LightGray.WithAlpha(0.3f))
            .WithAnimation(TouchEffectConstants.PresetDurations.VeryFast);
    }

    /// <summary>
    /// Applies a floating action button preset.
    /// </summary>
    public TouchEffectBuilder AsFloatingActionButton()
    {
        return WithPressedScale(0.9)
            .WithPressedOpacity(0.8)
            .WithAnimation(TouchEffectConstants.PresetDurations.Fast, Easing.SpringOut)
            .WithNativeAnimation();
    }

    #endregion

    /// <summary>
    /// Builds and applies the TouchEffect to the element.
    /// </summary>
    public VisualElement Build()
    {
        // Set all the properties
        TouchEffect.SetIsAvailable(this.element, this.isAvailable);

        if (this.command != null)
            TouchEffect.SetCommand(this.element, this.command);

        if (this.commandParameter != null)
            TouchEffect.SetCommandParameter(this.element, this.commandParameter);

        if (this.longPressCommand != null)
            TouchEffect.SetLongPressCommand(this.element, this.longPressCommand);

        if (this.longPressCommandParameter != null)
            TouchEffect.SetLongPressCommandParameter(this.element, this.longPressCommandParameter);

        TouchEffect.SetLongPressDuration(this.element, this.longPressDuration);

        // Visual properties
        TouchEffect.SetPressedOpacity(this.element, this.pressedOpacity);
        TouchEffect.SetPressedScale(this.element, this.pressedScale);
        if (this.pressedBackgroundColor != null)
            TouchEffect.SetPressedBackgroundColor(this.element, this.pressedBackgroundColor);

        TouchEffect.SetHoveredOpacity(this.element, this.hoveredOpacity);
        TouchEffect.SetHoveredScale(this.element, this.hoveredScale);
        if (this.hoveredBackgroundColor != null)
            TouchEffect.SetHoveredBackgroundColor(this.element, this.hoveredBackgroundColor);

        TouchEffect.SetNormalOpacity(this.element, this.normalOpacity);
        TouchEffect.SetNormalScale(this.element, this.normalScale);
        if (this.normalBackgroundColor != null)
            TouchEffect.SetNormalBackgroundColor(this.element, this.normalBackgroundColor);

        // Animation properties
        TouchEffect.SetAnimationDuration(this.element, this.animationDuration);
        if (this.animationEasing != null)
            TouchEffect.SetAnimationEasing(this.element, this.animationEasing);

        if (this.pressedAnimationDuration > 0)
            TouchEffect.SetPressedAnimationDuration(this.element, this.pressedAnimationDuration);
        if (this.pressedAnimationEasing != null)
            TouchEffect.SetPressedAnimationEasing(this.element, this.pressedAnimationEasing);

        if (this.hoveredAnimationDuration > 0)
            TouchEffect.SetHoveredAnimationDuration(this.element, this.hoveredAnimationDuration);
        if (this.hoveredAnimationEasing != null)
            TouchEffect.SetHoveredAnimationEasing(this.element, this.hoveredAnimationEasing);

        TouchEffect.SetPulseCount(this.element, this.pulseCount);

        // Native animation
        TouchEffect.SetNativeAnimation(this.element, this.nativeAnimation);
        if (this.nativeAnimationColor != null)
            TouchEffect.SetNativeAnimationColor(this.element, this.nativeAnimationColor);
        TouchEffect.SetNativeAnimationRadius(this.element, this.nativeAnimationRadius);

        // Other properties
        if (this.isToggled.HasValue)
            TouchEffect.SetIsToggled(this.element, this.isToggled);
        TouchEffect.SetDisallowTouchThreshold(this.element, this.disallowTouchThreshold);

        return this.element;
    }

    /// <summary>
    /// Builds and applies the effect, then returns the builder for further configuration.
    /// </summary>
    public TouchEffectBuilder Apply()
    {
        Build();
        return this;
    }
}

/// <summary>
/// Extension methods for applying TouchEffectBuilder to elements.
/// </summary>
public static class TouchEffectBuilderExtensions
{
    /// <summary>
    /// Creates a TouchEffectBuilder for this element.
    /// </summary>
    public static TouchEffectBuilder ConfigureTouchEffect(this VisualElement element)
    {
        return new TouchEffectBuilder(element);
    }

    /// <summary>
    /// Applies a button touch effect preset.
    /// </summary>
    public static VisualElement WithButtonEffect(this VisualElement element, ICommand? command = null)
    {
        var builder = new TouchEffectBuilder(element).AsButton();
        if (command != null)
            builder.WithCommand(command);
        return builder.Build();
    }

    /// <summary>
    /// Applies a card touch effect preset.
    /// </summary>
    public static VisualElement WithCardEffect(this VisualElement element, ICommand? command = null)
    {
        var builder = new TouchEffectBuilder(element).AsCard();
        if (command != null)
            builder.WithCommand(command);
        return builder.Build();
    }
}
