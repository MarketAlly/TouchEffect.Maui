using System.Windows.Input;
using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

/// <summary>
/// TouchEffect partial class containing all BindableProperty definitions.
/// </summary>
public partial class TouchEffect
{
	#region State Properties

	public static readonly BindableProperty IsAvailableProperty = BindableProperty.CreateAttached(
		nameof(IsAvailable),
		typeof(bool),
		typeof(TouchEffect),
		true,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty ShouldMakeChildrenInputTransparentProperty = BindableProperty.CreateAttached(
		nameof(ShouldMakeChildrenInputTransparent),
		typeof(bool),
		typeof(TouchEffect),
		true,
		propertyChanged: SetChildrenInputTransparentAndTryGenerateEffect);

	public static readonly BindableProperty StatusProperty = BindableProperty.CreateAttached(
		nameof(Status),
		typeof(TouchStatus),
		typeof(TouchEffect),
		TouchStatus.Completed,
		BindingMode.OneWayToSource);

	public static readonly BindableProperty StateProperty = BindableProperty.CreateAttached(
		nameof(State),
		typeof(TouchState),
		typeof(TouchEffect),
		TouchState.Normal,
		BindingMode.OneWayToSource);

	public static readonly BindableProperty InteractionStatusProperty = BindableProperty.CreateAttached(
		nameof(InteractionStatus),
		typeof(TouchInteractionStatus),
		typeof(TouchEffect),
		TouchInteractionStatus.Completed,
		BindingMode.OneWayToSource);

	public static readonly BindableProperty HoverStatusProperty = BindableProperty.CreateAttached(
		nameof(HoverStatus),
		typeof(HoverStatus),
		typeof(TouchEffect),
		Enums.HoverStatus.Exited,
		BindingMode.OneWayToSource);

	public static readonly BindableProperty HoverStateProperty = BindableProperty.CreateAttached(
		nameof(HoverState),
		typeof(HoverState),
		typeof(TouchEffect),
		Enums.HoverState.Normal,
		BindingMode.OneWayToSource);

	#endregion

	#region Command Properties

	public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(
		nameof(Command),
		typeof(ICommand),
		typeof(TouchEffect),
		default(ICommand),
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty LongPressCommandProperty = BindableProperty.CreateAttached(
		nameof(LongPressCommand),
		typeof(ICommand),
		typeof(TouchEffect),
		default(ICommand),
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty CommandParameterProperty = BindableProperty.CreateAttached(
		nameof(CommandParameter),
		typeof(object),
		typeof(TouchEffect),
		default,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty LongPressCommandParameterProperty = BindableProperty.CreateAttached(
		nameof(LongPressCommandParameter),
		typeof(object),
		typeof(TouchEffect),
		default,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty LongPressDurationProperty = BindableProperty.CreateAttached(
		nameof(LongPressDuration),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.LongPressDuration,
		propertyChanged: TryGenerateEffect);

	#endregion

	#region Background Color Properties

	public static readonly BindableProperty NormalBackgroundColorProperty = BindableProperty.CreateAttached(
		nameof(NormalBackgroundColor),
		typeof(Color),
		typeof(TouchEffect),
		KnownColor.Default,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredBackgroundColorProperty = BindableProperty.CreateAttached(
		nameof(HoveredBackgroundColor),
		typeof(Color),
		typeof(TouchEffect),
		KnownColor.Default,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedBackgroundColorProperty = BindableProperty.CreateAttached(
		nameof(PressedBackgroundColor),
		typeof(Color),
		typeof(TouchEffect),
		KnownColor.Default,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	#endregion

	#region Opacity Properties

	public static readonly BindableProperty NormalOpacityProperty = BindableProperty.CreateAttached(
		nameof(NormalOpacity),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Opacity,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredOpacityProperty = BindableProperty.CreateAttached(
		nameof(HoveredOpacity),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Opacity,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedOpacityProperty = BindableProperty.CreateAttached(
		nameof(PressedOpacity),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Opacity,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	#endregion

	#region Scale Properties

	public static readonly BindableProperty NormalScaleProperty = BindableProperty.CreateAttached(
		nameof(NormalScale),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Scale,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredScaleProperty = BindableProperty.CreateAttached(
		nameof(HoveredScale),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Scale,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedScaleProperty = BindableProperty.CreateAttached(
		nameof(PressedScale),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Scale,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	#endregion

	#region Translation Properties

	public static readonly BindableProperty NormalTranslationXProperty = BindableProperty.CreateAttached(
		nameof(NormalTranslationX),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.TranslationX,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredTranslationXProperty = BindableProperty.CreateAttached(
		nameof(HoveredTranslationX),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.TranslationX,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedTranslationXProperty = BindableProperty.CreateAttached(
		nameof(PressedTranslationX),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.TranslationX,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty NormalTranslationYProperty = BindableProperty.CreateAttached(
		nameof(NormalTranslationY),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.TranslationY,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredTranslationYProperty = BindableProperty.CreateAttached(
		nameof(HoveredTranslationY),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.TranslationY,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedTranslationYProperty = BindableProperty.CreateAttached(
		nameof(PressedTranslationY),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.TranslationY,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	#endregion

	#region Rotation Properties

	public static readonly BindableProperty NormalRotationProperty = BindableProperty.CreateAttached(
		nameof(NormalRotation),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredRotationProperty = BindableProperty.CreateAttached(
		nameof(HoveredRotation),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedRotationProperty = BindableProperty.CreateAttached(
		nameof(PressedRotation),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty NormalRotationXProperty = BindableProperty.CreateAttached(
		nameof(NormalRotationX),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredRotationXProperty = BindableProperty.CreateAttached(
		nameof(HoveredRotationX),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedRotationXProperty = BindableProperty.CreateAttached(
		nameof(PressedRotationX),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty NormalRotationYProperty = BindableProperty.CreateAttached(
		nameof(NormalRotationY),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredRotationYProperty = BindableProperty.CreateAttached(
		nameof(HoveredRotationY),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedRotationYProperty = BindableProperty.CreateAttached(
		nameof(PressedRotationY),
		typeof(double),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.Rotation,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	#endregion

	#region Animation Properties

	public static readonly BindableProperty AnimationDurationProperty = BindableProperty.CreateAttached(
		nameof(AnimationDuration),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Animation.DefaultDuration,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty AnimationEasingProperty = BindableProperty.CreateAttached(
		nameof(AnimationEasing),
		typeof(Easing),
		typeof(TouchEffect),
		null,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty PressedAnimationDurationProperty = BindableProperty.CreateAttached(
		nameof(PressedAnimationDuration),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Animation.DefaultDuration,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty PressedAnimationEasingProperty = BindableProperty.CreateAttached(
		nameof(PressedAnimationEasing),
		typeof(Easing),
		typeof(TouchEffect),
		null,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty NormalAnimationDurationProperty = BindableProperty.CreateAttached(
		nameof(NormalAnimationDuration),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Animation.DefaultDuration,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty NormalAnimationEasingProperty = BindableProperty.CreateAttached(
		nameof(NormalAnimationEasing),
		typeof(Easing),
		typeof(TouchEffect),
		null,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty HoveredAnimationDurationProperty = BindableProperty.CreateAttached(
		nameof(HoveredAnimationDuration),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Animation.DefaultDuration,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty HoveredAnimationEasingProperty = BindableProperty.CreateAttached(
		nameof(HoveredAnimationEasing),
		typeof(Easing),
		typeof(TouchEffect),
		null,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty PulseCountProperty = BindableProperty.CreateAttached(
		nameof(PulseCount),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.PulseCount,
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	#endregion

	#region Toggle and Threshold Properties

	public static readonly BindableProperty IsToggledProperty = BindableProperty.CreateAttached(
		nameof(IsToggled),
		typeof(bool?),
		typeof(TouchEffect),
		default(bool?),
		BindingMode.TwoWay,
		propertyChanged: ForceUpdateStateWithoutAnimationAndTryGenerateEffect);

	public static readonly BindableProperty DisallowTouchThresholdProperty = BindableProperty.CreateAttached(
		nameof(DisallowTouchThreshold),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.DisallowTouchThreshold,
		propertyChanged: TryGenerateEffect);

	#endregion

	#region Native Animation Properties

	public static readonly BindableProperty NativeAnimationProperty = BindableProperty.CreateAttached(
		nameof(NativeAnimation),
		typeof(bool),
		typeof(TouchEffect),
		false,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty NativeAnimationColorProperty = BindableProperty.CreateAttached(
		nameof(NativeAnimationColor),
		typeof(Color),
		typeof(TouchEffect),
		KnownColor.Default,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty NativeAnimationRadiusProperty = BindableProperty.CreateAttached(
		nameof(NativeAnimationRadius),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.NativeAnimationRadius,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty NativeAnimationShadowRadiusProperty = BindableProperty.CreateAttached(
		nameof(NativeAnimationShadowRadius),
		typeof(int),
		typeof(TouchEffect),
		TouchEffectConstants.Defaults.NativeAnimationShadowRadius,
		propertyChanged: TryGenerateEffect);

	public static readonly BindableProperty NativeAnimationBorderlessProperty = BindableProperty.CreateAttached(
		nameof(NativeAnimationBorderless),
		typeof(bool),
		typeof(TouchEffect),
		false,
		propertyChanged: TryGenerateEffect);

	#endregion

	#region Background Image Properties

	public static readonly BindableProperty NormalBackgroundImageSourceProperty = BindableProperty.CreateAttached(
		nameof(NormalBackgroundImageSource),
		typeof(ImageSource),
		typeof(TouchEffect),
		default(ImageSource),
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredBackgroundImageSourceProperty = BindableProperty.CreateAttached(
		nameof(HoveredBackgroundImageSource),
		typeof(ImageSource),
		typeof(TouchEffect),
		default(ImageSource),
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedBackgroundImageSourceProperty = BindableProperty.CreateAttached(
		nameof(PressedBackgroundImageSource),
		typeof(ImageSource),
		typeof(TouchEffect),
		default(ImageSource),
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty BackgroundImageAspectProperty = BindableProperty.CreateAttached(
		nameof(BackgroundImageAspect),
		typeof(Aspect),
		typeof(TouchEffect),
		default(Aspect),
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty NormalBackgroundImageAspectProperty = BindableProperty.CreateAttached(
		nameof(NormalBackgroundImageAspect),
		typeof(Aspect),
		typeof(TouchEffect),
		default(Aspect),
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty HoveredBackgroundImageAspectProperty = BindableProperty.CreateAttached(
		nameof(HoveredBackgroundImageAspect),
		typeof(Aspect),
		typeof(TouchEffect),
		default(Aspect),
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty PressedBackgroundImageAspectProperty = BindableProperty.CreateAttached(
		nameof(PressedBackgroundImageAspect),
		typeof(Aspect),
		typeof(TouchEffect),
		default(Aspect),
		propertyChanged: ForceUpdateStateAndTryGenerateEffect);

	public static readonly BindableProperty ShouldSetImageOnAnimationEndProperty = BindableProperty.CreateAttached(
		nameof(ShouldSetImageOnAnimationEnd),
		typeof(bool),
		typeof(TouchEffect),
		default(bool),
		propertyChanged: TryGenerateEffect);

	#endregion
}
