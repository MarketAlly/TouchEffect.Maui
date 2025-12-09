using System.Windows.Input;
using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

/// <summary>
/// TouchEffect partial class containing all static Get/Set accessor methods.
/// </summary>
public partial class TouchEffect
{
	#region State Accessors

	public static bool GetIsAvailable(BindableObject? bindable)
		=> (bool)(bindable?.GetValue(IsAvailableProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetIsAvailable(BindableObject? bindable, bool value)
		=> bindable?.SetValue(IsAvailableProperty, value);

	public static bool GetShouldMakeChildrenInputTransparent(BindableObject? bindable)
		=> (bool)(bindable?.GetValue(ShouldMakeChildrenInputTransparentProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetShouldMakeChildrenInputTransparent(BindableObject? bindable, bool value)
		=> bindable?.SetValue(ShouldMakeChildrenInputTransparentProperty, value);

	public static TouchStatus GetStatus(BindableObject? bindable)
		=> (TouchStatus)(bindable?.GetValue(StatusProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetStatus(BindableObject? bindable, TouchStatus value)
		=> bindable?.SetValue(StatusProperty, value);

	public static TouchState GetState(BindableObject? bindable)
		=> (TouchState)(bindable?.GetValue(StateProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetState(BindableObject? bindable, TouchState value)
		=> bindable?.SetValue(StateProperty, value);

	public static TouchInteractionStatus GetInteractionStatus(BindableObject? bindable)
		=> (TouchInteractionStatus)(bindable?.GetValue(InteractionStatusProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetInteractionStatus(BindableObject? bindable, TouchInteractionStatus value)
		=> bindable?.SetValue(InteractionStatusProperty, value);

	public static HoverStatus GetHoverStatus(BindableObject? bindable)
		=> (HoverStatus)(bindable?.GetValue(HoverStatusProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoverStatus(BindableObject? bindable, HoverStatus value)
		=> bindable?.SetValue(HoverStatusProperty, value);

	public static HoverState GetHoverState(BindableObject? bindable)
		=> (HoverState)(bindable?.GetValue(HoverStateProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoverState(BindableObject? bindable, HoverState value)
		=> bindable?.SetValue(HoverStateProperty, value);

	#endregion

	#region Command Accessors

	public static ICommand? GetCommand(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (ICommand?)bindable.GetValue(CommandProperty);
	}

	public static void SetCommand(BindableObject? bindable, ICommand value)
		=> bindable?.SetValue(CommandProperty, value);

	public static ICommand? GetLongPressCommand(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (ICommand?)bindable.GetValue(LongPressCommandProperty);
	}

	public static void SetLongPressCommand(BindableObject? bindable, ICommand value)
		=> bindable?.SetValue(LongPressCommandProperty, value);

	public static object? GetCommandParameter(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return bindable.GetValue(CommandParameterProperty);
	}

	public static void SetCommandParameter(BindableObject? bindable, object value)
		=> bindable?.SetValue(CommandParameterProperty, value);

	public static object? GetLongPressCommandParameter(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return bindable.GetValue(LongPressCommandParameterProperty);
	}

	public static void SetLongPressCommandParameter(BindableObject? bindable, object value)
		=> bindable?.SetValue(LongPressCommandParameterProperty, value);

	public static int GetLongPressDuration(BindableObject? bindable)
		=> (int)(bindable?.GetValue(LongPressDurationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetLongPressDuration(BindableObject? bindable, int value)
		=> bindable?.SetValue(LongPressDurationProperty, value);

	#endregion

	#region Background Color Accessors

	public static Color? GetNormalBackgroundColor(BindableObject? bindable)
		=> bindable?.GetValue(NormalBackgroundColorProperty) as Color;

	public static void SetNormalBackgroundColor(BindableObject? bindable, Color value)
		=> bindable?.SetValue(NormalBackgroundColorProperty, value);

	public static Color? GetHoveredBackgroundColor(BindableObject? bindable)
		=> bindable?.GetValue(HoveredBackgroundColorProperty) as Color;

	public static void SetHoveredBackgroundColor(BindableObject? bindable, Color value)
		=> bindable?.SetValue(HoveredBackgroundColorProperty, value);

	public static Color? GetPressedBackgroundColor(BindableObject? bindable)
		=> bindable?.GetValue(PressedBackgroundColorProperty) as Color;

	public static void SetPressedBackgroundColor(BindableObject? bindable, Color value)
		=> bindable?.SetValue(PressedBackgroundColorProperty, value);

	#endregion

	#region Opacity Accessors

	public static double GetNormalOpacity(BindableObject? bindable)
		=> (double)(bindable?.GetValue(NormalOpacityProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalOpacity(BindableObject? bindable, double value)
		=> bindable?.SetValue(NormalOpacityProperty, value);

	public static double GetHoveredOpacity(BindableObject? bindable)
		=> (double)(bindable?.GetValue(HoveredOpacityProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredOpacity(BindableObject? bindable, double value)
		=> bindable?.SetValue(HoveredOpacityProperty, value);

	public static double GetPressedOpacity(BindableObject? bindable)
		=> (double)(bindable?.GetValue(PressedOpacityProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedOpacity(BindableObject? bindable, double value)
		=> bindable?.SetValue(PressedOpacityProperty, value);

	#endregion

	#region Scale Accessors

	public static double GetNormalScale(BindableObject? bindable)
		=> (double)(bindable?.GetValue(NormalScaleProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalScale(BindableObject? bindable, double value)
		=> bindable?.SetValue(NormalScaleProperty, value);

	public static double GetHoveredScale(BindableObject? bindable)
		=> (double)(bindable?.GetValue(HoveredScaleProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredScale(BindableObject? bindable, double value)
		=> bindable?.SetValue(HoveredScaleProperty, value);

	public static double GetPressedScale(BindableObject? bindable)
		=> (double)(bindable?.GetValue(PressedScaleProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedScale(BindableObject? bindable, double value)
		=> bindable?.SetValue(PressedScaleProperty, value);

	#endregion

	#region Translation Accessors

	public static double GetNormalTranslationX(BindableObject? bindable)
		=> (double)(bindable?.GetValue(NormalTranslationXProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalTranslationX(BindableObject? bindable, double value)
		=> bindable?.SetValue(NormalTranslationXProperty, value);

	public static double GetHoveredTranslationX(BindableObject? bindable)
		=> (double)(bindable?.GetValue(HoveredTranslationXProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredTranslationX(BindableObject? bindable, double value)
		=> bindable?.SetValue(HoveredTranslationXProperty, value);

	public static double GetPressedTranslationX(BindableObject? bindable)
		=> (double)(bindable?.GetValue(PressedTranslationXProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedTranslationX(BindableObject? bindable, double value)
		=> bindable?.SetValue(PressedTranslationXProperty, value);

	public static double GetNormalTranslationY(BindableObject? bindable)
		=> (double)(bindable?.GetValue(NormalTranslationYProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalTranslationY(BindableObject? bindable, double value)
		=> bindable?.SetValue(NormalTranslationYProperty, value);

	public static double GetHoveredTranslationY(BindableObject? bindable)
		=> (double)(bindable?.GetValue(HoveredTranslationYProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredTranslationY(BindableObject? bindable, double value)
		=> bindable?.SetValue(HoveredTranslationYProperty, value);

	public static double GetPressedTranslationY(BindableObject? bindable)
		=> (double)(bindable?.GetValue(PressedTranslationYProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedTranslationY(BindableObject? bindable, double value)
		=> bindable?.SetValue(PressedTranslationYProperty, value);

	#endregion

	#region Rotation Accessors

	public static double GetNormalRotation(BindableObject? bindable)
		=> (double)(bindable?.GetValue(NormalRotationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalRotation(BindableObject? bindable, double value)
		=> bindable?.SetValue(NormalRotationProperty, value);

	public static double GetHoveredRotation(BindableObject? bindable)
		=> (double)(bindable?.GetValue(HoveredRotationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredRotation(BindableObject? bindable, double value)
		=> bindable?.SetValue(HoveredRotationProperty, value);

	public static double GetPressedRotation(BindableObject? bindable)
		=> (double)(bindable?.GetValue(PressedRotationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedRotation(BindableObject? bindable, double value)
		=> bindable?.SetValue(PressedRotationProperty, value);

	public static double GetNormalRotationX(BindableObject? bindable)
		=> (double)(bindable?.GetValue(NormalRotationXProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalRotationX(BindableObject? bindable, double value)
		=> bindable?.SetValue(NormalRotationXProperty, value);

	public static double GetHoveredRotationX(BindableObject? bindable)
		=> (double)(bindable?.GetValue(HoveredRotationXProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredRotationX(BindableObject? bindable, double value)
		=> bindable?.SetValue(HoveredRotationXProperty, value);

	public static double GetPressedRotationX(BindableObject? bindable)
		=> (double)(bindable?.GetValue(PressedRotationXProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedRotationX(BindableObject? bindable, double value)
		=> bindable?.SetValue(PressedRotationXProperty, value);

	public static double GetNormalRotationY(BindableObject? bindable)
		=> (double)(bindable?.GetValue(NormalRotationYProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalRotationY(BindableObject? bindable, double value)
		=> bindable?.SetValue(NormalRotationYProperty, value);

	public static double GetHoveredRotationY(BindableObject? bindable)
		=> (double)(bindable?.GetValue(HoveredRotationYProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredRotationY(BindableObject? bindable, double value)
		=> bindable?.SetValue(HoveredRotationYProperty, value);

	public static double GetPressedRotationY(BindableObject? bindable)
		=> (double)(bindable?.GetValue(PressedRotationYProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedRotationY(BindableObject? bindable, double value)
		=> bindable?.SetValue(PressedRotationYProperty, value);

	#endregion

	#region Animation Accessors

	public static int GetAnimationDuration(BindableObject? bindable)
		=> (int)(bindable?.GetValue(AnimationDurationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetAnimationDuration(BindableObject? bindable, int value)
		=> bindable?.SetValue(AnimationDurationProperty, value);

	public static Easing? GetAnimationEasing(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (Easing?)bindable.GetValue(AnimationEasingProperty);
	}

	public static void SetAnimationEasing(BindableObject? bindable, Easing? value)
		=> bindable?.SetValue(AnimationEasingProperty, value);

	public static int GetPressedAnimationDuration(BindableObject? bindable)
		=> (int)(bindable?.GetValue(PressedAnimationDurationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedAnimationDuration(BindableObject? bindable, int value)
		=> bindable?.SetValue(PressedAnimationDurationProperty, value);

	public static Easing? GetPressedAnimationEasing(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (Easing?)bindable.GetValue(PressedAnimationEasingProperty);
	}

	public static void SetPressedAnimationEasing(BindableObject? bindable, Easing? value)
		=> bindable?.SetValue(PressedAnimationEasingProperty, value);

	public static int GetNormalAnimationDuration(BindableObject? bindable)
		=> (int)(bindable?.GetValue(NormalAnimationDurationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalAnimationDuration(BindableObject? bindable, int value)
		=> bindable?.SetValue(NormalAnimationDurationProperty, value);

	public static Easing? GetNormalAnimationEasing(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (Easing?)bindable.GetValue(NormalAnimationEasingProperty);
	}

	public static void SetNormalAnimationEasing(BindableObject? bindable, Easing? value)
		=> bindable?.SetValue(NormalAnimationEasingProperty, value);

	public static int GetHoveredAnimationDuration(BindableObject? bindable)
		=> (int)(bindable?.GetValue(HoveredAnimationDurationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredAnimationDuration(BindableObject? bindable, int value)
		=> bindable?.SetValue(HoveredAnimationDurationProperty, value);

	public static Easing? GetHoveredAnimationEasing(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (Easing?)bindable.GetValue(HoveredAnimationEasingProperty);
	}

	public static void SetHoveredAnimationEasing(BindableObject? bindable, Easing? value)
		=> bindable?.SetValue(HoveredAnimationEasingProperty, value);

	public static int GetPulseCount(BindableObject? bindable)
		=> (int)(bindable?.GetValue(PulseCountProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPulseCount(BindableObject? bindable, int value)
		=> bindable?.SetValue(PulseCountProperty, value);

	#endregion

	#region Toggle and Threshold Accessors

	public static bool? GetIsToggled(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (bool?)bindable.GetValue(IsToggledProperty);
	}

	public static void SetIsToggled(BindableObject? bindable, bool? value)
		=> bindable?.SetValue(IsToggledProperty, value);

	public static int GetDisallowTouchThreshold(BindableObject? bindable)
		=> (int)(bindable?.GetValue(DisallowTouchThresholdProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetDisallowTouchThreshold(BindableObject? bindable, int value)
		=> bindable?.SetValue(DisallowTouchThresholdProperty, value);

	#endregion

	#region Native Animation Accessors

	public static bool GetNativeAnimation(BindableObject? bindable)
		=> (bool)(bindable?.GetValue(NativeAnimationProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNativeAnimation(BindableObject? bindable, bool value)
		=> bindable?.SetValue(NativeAnimationProperty, value);

	public static Color? GetNativeAnimationColor(BindableObject? bindable)
		=> bindable?.GetValue(NativeAnimationColorProperty) as Color;

	public static void SetNativeAnimationColor(BindableObject? bindable, Color value)
		=> bindable?.SetValue(NativeAnimationColorProperty, value);

	public static int GetNativeAnimationRadius(BindableObject? bindable)
		=> (int)(bindable?.GetValue(NativeAnimationRadiusProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNativeAnimationRadius(BindableObject? bindable, int value)
		=> bindable?.SetValue(NativeAnimationRadiusProperty, value);

	public static int GetNativeAnimationShadowRadius(BindableObject? bindable)
		=> (int)(bindable?.GetValue(NativeAnimationShadowRadiusProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNativeAnimationShadowRadius(BindableObject? bindable, int value)
		=> bindable?.SetValue(NativeAnimationShadowRadiusProperty, value);

	public static bool GetNativeAnimationBorderless(BindableObject? bindable)
		=> (bool)(bindable?.GetValue(NativeAnimationBorderlessProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNativeAnimationBorderless(BindableObject? bindable, bool value)
		=> bindable?.SetValue(NativeAnimationBorderlessProperty, value);

	#endregion

	#region Background Image Accessors

	public static ImageSource? GetNormalBackgroundImageSource(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (ImageSource?)bindable.GetValue(NormalBackgroundImageSourceProperty);
	}

	public static void SetNormalBackgroundImageSource(BindableObject? bindable, ImageSource value)
		=> bindable?.SetValue(NormalBackgroundImageSourceProperty, value);

	public static ImageSource? GetHoveredBackgroundImageSource(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (ImageSource?)bindable.GetValue(HoveredBackgroundImageSourceProperty);
	}

	public static void SetHoveredBackgroundImageSource(BindableObject? bindable, ImageSource value)
		=> bindable?.SetValue(HoveredBackgroundImageSourceProperty, value);

	public static ImageSource? GetPressedBackgroundImageSource(BindableObject? bindable)
	{
		if (bindable == null) throw new ArgumentNullException(nameof(bindable));
		return (ImageSource?)bindable.GetValue(PressedBackgroundImageSourceProperty);
	}

	public static void SetPressedBackgroundImageSource(BindableObject? bindable, ImageSource value)
		=> bindable?.SetValue(PressedBackgroundImageSourceProperty, value);

	public static Aspect GetBackgroundImageAspect(BindableObject? bindable)
		=> (Aspect)(bindable?.GetValue(BackgroundImageAspectProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetBackgroundImageAspect(BindableObject? bindable, Aspect value)
		=> bindable?.SetValue(BackgroundImageAspectProperty, value);

	public static Aspect GetNormalBackgroundImageAspect(BindableObject? bindable)
		=> (Aspect)(bindable?.GetValue(NormalBackgroundImageAspectProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetNormalBackgroundImageAspect(BindableObject? bindable, Aspect value)
		=> bindable?.SetValue(NormalBackgroundImageAspectProperty, value);

	public static Aspect GetHoveredBackgroundImageAspect(BindableObject? bindable)
		=> (Aspect)(bindable?.GetValue(HoveredBackgroundImageAspectProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetHoveredBackgroundImageAspect(BindableObject? bindable, Aspect value)
		=> bindable?.SetValue(HoveredBackgroundImageAspectProperty, value);

	public static Aspect GetPressedBackgroundImageAspect(BindableObject? bindable)
		=> (Aspect)(bindable?.GetValue(PressedBackgroundImageAspectProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetPressedBackgroundImageAspect(BindableObject? bindable, Aspect value)
		=> bindable?.SetValue(PressedBackgroundImageAspectProperty, value);

	public static bool GetShouldSetImageOnAnimationEnd(BindableObject? bindable)
		=> (bool)(bindable?.GetValue(ShouldSetImageOnAnimationEndProperty) ?? throw new ArgumentNullException(nameof(bindable)));

	public static void SetShouldSetImageOnAnimationEnd(BindableObject? bindable, bool value)
		=> bindable?.SetValue(ShouldSetImageOnAnimationEndProperty, value);

	#endregion
}
