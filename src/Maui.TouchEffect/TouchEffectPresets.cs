using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.TouchEffect;

/// <summary>
/// Predefined TouchEffect configurations for common UI patterns.
/// </summary>
public static class TouchEffectPresets
{
    /// <summary>
    /// Standard button effect with opacity change.
    /// </summary>
    public static class Button
    {
        /// <summary>
        /// Standard button with opacity feedback.
        /// </summary>
        public static void Apply(VisualElement element)
        {
            TouchEffect.SetPressedOpacity(element, 0.7);
            TouchEffect.SetAnimationDuration(element, 100); // Fast
            TouchEffect.SetAnimationEasing(element, Easing.CubicOut);
        }

        /// <summary>
        /// Primary button with scale and opacity feedback.
        /// </summary>
        public static void ApplyPrimary(VisualElement element)
        {
            TouchEffect.SetPressedOpacity(element, 0.8);
            TouchEffect.SetPressedScale(element, 0.95);
            TouchEffect.SetAnimationDuration(element, 100); // Fast
            TouchEffect.SetAnimationEasing(element, Easing.CubicOut);
        }

        /// <summary>
        /// Secondary button with subtle feedback.
        /// </summary>
        public static void ApplySecondary(VisualElement element)
        {
            TouchEffect.SetPressedOpacity(element, 0.6);
            TouchEffect.SetAnimationDuration(element, 50); // Very Fast
        }

        /// <summary>
        /// Text button with minimal feedback.
        /// </summary>
        public static void ApplyText(VisualElement element)
        {
            TouchEffect.SetPressedOpacity(element, 0.5);
            TouchEffect.SetAnimationDuration(element, 25); // Instant
        }
    }

    /// <summary>
    /// Card effect with scale animation.
    /// </summary>
    public static class Card
    {
        /// <summary>
        /// Standard card with subtle scale effect.
        /// </summary>
        public static void Apply(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.97);
            TouchEffect.SetAnimationDuration(element, 150); // Normal
            TouchEffect.SetAnimationEasing(element, Easing.CubicInOut);
        }

        /// <summary>
        /// Elevated card with shadow-like effect.
        /// </summary>
        public static void ApplyElevated(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.95);
            TouchEffect.SetPressedOpacity(element, 0.9);
            TouchEffect.SetAnimationDuration(element, 150); // Normal
            TouchEffect.SetAnimationEasing(element, Easing.CubicInOut);
            TouchEffect.SetHoveredScale(element, 1.02);
            TouchEffect.SetHoveredAnimationDuration(element, 200); // Slow
        }

        /// <summary>
        /// Interactive card with hover support.
        /// </summary>
        public static void ApplyInteractive(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.98);
            TouchEffect.SetHoveredScale(element, 1.01);
            TouchEffect.SetHoveredBackgroundColor(element, Colors.Gray.WithAlpha(0.1f));
            TouchEffect.SetAnimationDuration(element, 100); // Fast
            TouchEffect.SetAnimationEasing(element, Easing.CubicOut);
        }
    }

    /// <summary>
    /// List item effects.
    /// </summary>
    public static class ListItem
    {
        /// <summary>
        /// Standard list item with background highlight.
        /// </summary>
        public static void Apply(VisualElement element)
        {
            TouchEffect.SetPressedBackgroundColor(element, Colors.Gray.WithAlpha(0.2f));
            TouchEffect.SetAnimationDuration(element, 50); // Very Fast
        }

        /// <summary>
        /// Selectable list item with toggle behavior.
        /// </summary>
        public static void ApplySelectable(VisualElement element)
        {
            TouchEffect.SetIsToggled(element, false);
            TouchEffect.SetPressedBackgroundColor(element, Colors.Blue.WithAlpha(0.3f));
            TouchEffect.SetAnimationDuration(element, 100); // Fast
        }

        /// <summary>
        /// Swipeable list item with scale feedback.
        /// </summary>
        public static void ApplySwipeable(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.98);
            TouchEffect.SetPressedBackgroundColor(element, Colors.Gray.WithAlpha(0.1f));
            TouchEffect.SetAnimationDuration(element, 50); // Very Fast
        }
    }

    /// <summary>
    /// Icon button effects.
    /// </summary>
    public static class IconButton
    {
        /// <summary>
        /// Standard icon button with scale effect.
        /// </summary>
        public static void Apply(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.85);
            TouchEffect.SetPressedOpacity(element, 0.7);
            TouchEffect.SetAnimationDuration(element, 100); // Fast
            TouchEffect.SetAnimationEasing(element, Easing.SpringOut);
        }

        /// <summary>
        /// Floating action button effect.
        /// </summary>
        public static void ApplyFloatingAction(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.9);
            TouchEffect.SetPressedOpacity(element, 0.8);
            TouchEffect.SetAnimationDuration(element, 100); // Fast
            TouchEffect.SetAnimationEasing(element, Easing.SpringOut);
            TouchEffect.SetNativeAnimation(element, true);
        }

        /// <summary>
        /// Toolbar icon effect.
        /// </summary>
        public static void ApplyToolbar(VisualElement element)
        {
            TouchEffect.SetPressedOpacity(element, 0.5);
            TouchEffect.SetAnimationDuration(element, 50); // Very Fast
        }
    }

    /// <summary>
    /// Switch/Toggle effects.
    /// </summary>
    public static class Toggle
    {
        /// <summary>
        /// Standard toggle with color change.
        /// </summary>
        public static void Apply(VisualElement element)
        {
            TouchEffect.SetIsToggled(element, false);
            TouchEffect.SetPressedScale(element, 0.95);
            TouchEffect.SetAnimationDuration(element, 150); // Normal
            TouchEffect.SetAnimationEasing(element, Easing.CubicInOut);
        }

        /// <summary>
        /// Checkbox-style toggle.
        /// </summary>
        public static void ApplyCheckbox(VisualElement element)
        {
            TouchEffect.SetIsToggled(element, false);
            TouchEffect.SetPressedScale(element, 0.9);
            TouchEffect.SetAnimationDuration(element, 100); // Fast
            TouchEffect.SetAnimationEasing(element, Easing.BounceOut);
        }
    }

    /// <summary>
    /// Image effects.
    /// </summary>
    public static class Image
    {
        /// <summary>
        /// Thumbnail image with scale effect.
        /// </summary>
        public static void ApplyThumbnail(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.95);
            TouchEffect.SetHoveredScale(element, 1.05);
            TouchEffect.SetAnimationDuration(element, 150); // Normal
            TouchEffect.SetAnimationEasing(element, Easing.CubicInOut);
        }

        /// <summary>
        /// Gallery image with zoom effect.
        /// </summary>
        public static void ApplyGallery(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.98);
            TouchEffect.SetPressedOpacity(element, 0.8);
            TouchEffect.SetHoveredScale(element, 1.1);
            TouchEffect.SetAnimationDuration(element, 200); // Slow
            TouchEffect.SetAnimationEasing(element, Easing.CubicInOut);
        }

        /// <summary>
        /// Avatar image with subtle feedback.
        /// </summary>
        public static void ApplyAvatar(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.92);
            TouchEffect.SetPressedOpacity(element, 0.7);
            TouchEffect.SetAnimationDuration(element, 100); // Fast
            TouchEffect.SetAnimationEasing(element, Easing.CubicOut);
        }
    }

    /// <summary>
    /// Native platform effects.
    /// </summary>
    public static class Native
    {
        /// <summary>
        /// Android ripple effect.
        /// </summary>
        public static void ApplyRipple(VisualElement element, Color? color = null)
        {
            TouchEffect.SetNativeAnimation(element, true);
            if (color != null)
                TouchEffect.SetNativeAnimationColor(element, color);
        }

        /// <summary>
        /// iOS haptic feedback effect.
        /// </summary>
        public static void ApplyHaptic(VisualElement element)
        {
            TouchEffect.SetNativeAnimation(element, true);
            TouchEffect.SetPressedOpacity(element, 0.8);
            TouchEffect.SetAnimationDuration(element, 50); // Very Fast
        }
    }

    /// <summary>
    /// Special effects.
    /// </summary>
    public static class Special
    {
        /// <summary>
        /// Pulse effect with repeating animation.
        /// </summary>
        public static void ApplyPulse(VisualElement element, int count = 3)
        {
            TouchEffect.SetPressedScale(element, 1.1);
            TouchEffect.SetPressedOpacity(element, 0.7);
            TouchEffect.SetPulseCount(element, count);
            TouchEffect.SetAnimationDuration(element, 150); // Normal
            TouchEffect.SetAnimationEasing(element, Easing.SinInOut);
        }

        /// <summary>
        /// Bounce effect with spring animation.
        /// </summary>
        public static void ApplyBounce(VisualElement element)
        {
            TouchEffect.SetPressedScale(element, 0.8);
            TouchEffect.SetAnimationDuration(element, 200); // Slow
            TouchEffect.SetAnimationEasing(element, Easing.SpringOut);
        }

        /// <summary>
        /// Shake effect with rotation.
        /// </summary>
        public static void ApplyShake(VisualElement element)
        {
            TouchEffect.SetPressedRotation(element, 5);
            TouchEffect.SetPulseCount(element, 2);
            TouchEffect.SetAnimationDuration(element, 50); // Very Fast
            TouchEffect.SetAnimationEasing(element, Easing.BounceOut);
        }

        /// <summary>
        /// Disabled state with no interaction.
        /// </summary>
        public static void ApplyDisabled(VisualElement element)
        {
            TouchEffect.SetIsAvailable(element, false);
            element.Opacity = 0.5;
            element.InputTransparent = true;
        }
    }
}

/// <summary>
/// Extension methods for applying presets.
/// </summary>
public static class TouchEffectPresetExtensions
{
    /// <summary>
    /// Applies the standard button preset.
    /// </summary>
    public static T WithButtonPreset<T>(this T element) where T : VisualElement
    {
        TouchEffectPresets.Button.Apply(element);
        return element;
    }

    /// <summary>
    /// Applies the standard card preset.
    /// </summary>
    public static T WithCardPreset<T>(this T element) where T : VisualElement
    {
        TouchEffectPresets.Card.Apply(element);
        return element;
    }

    /// <summary>
    /// Applies the standard list item preset.
    /// </summary>
    public static T WithListItemPreset<T>(this T element) where T : VisualElement
    {
        TouchEffectPresets.ListItem.Apply(element);
        return element;
    }

    /// <summary>
    /// Applies the icon button preset.
    /// </summary>
    public static T WithIconButtonPreset<T>(this T element) where T : VisualElement
    {
        TouchEffectPresets.IconButton.Apply(element);
        return element;
    }

    /// <summary>
    /// Applies native platform animation.
    /// </summary>
    public static T WithNativeEffect<T>(this T element, Color? color = null) where T : VisualElement
    {
        TouchEffectPresets.Native.ApplyRipple(element, color);
        return element;
    }
}