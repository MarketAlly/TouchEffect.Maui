namespace Maui.TouchEffect;

/// <summary>
/// Constants used throughout the TouchEffect library.
/// </summary>
public static class TouchEffectConstants
{
    /// <summary>
    /// Animation constants
    /// </summary>
    public static class Animation
    {
        /// <summary>
        /// Default animation progress delay in milliseconds for smooth transitions.
        /// </summary>
        public const int DefaultProgressDelay = 10;

        /// <summary>
        /// Default animation duration when not specified (instant).
        /// </summary>
        public const int DefaultDuration = 0;

        /// <summary>
        /// Maximum recommended animation duration for responsive feel.
        /// </summary>
        public const int MaxRecommendedDuration = 300;

        /// <summary>
        /// Frame rate target for animations (60fps).
        /// </summary>
        public const int TargetFrameRate = 60;

        /// <summary>
        /// Throttle interval for property changes in milliseconds.
        /// </summary>
        public const int ThrottleInterval = 16; // ~60fps
    }

    /// <summary>
    /// Default visual property values
    /// </summary>
    public static class Defaults
    {
        /// <summary>
        /// Default opacity for all states.
        /// </summary>
        public const double Opacity = 1.0;

        /// <summary>
        /// Default scale for all states.
        /// </summary>
        public const double Scale = 1.0;

        /// <summary>
        /// Default translation X offset.
        /// </summary>
        public const double TranslationX = 0.0;

        /// <summary>
        /// Default translation Y offset.
        /// </summary>
        public const double TranslationY = 0.0;

        /// <summary>
        /// Default rotation angle in degrees.
        /// </summary>
        public const double Rotation = 0.0;

        /// <summary>
        /// Default long press duration in milliseconds.
        /// </summary>
        public const int LongPressDuration = 500;

        /// <summary>
        /// Default touch movement threshold in pixels.
        /// </summary>
        public const int DisallowTouchThreshold = 0;

        /// <summary>
        /// Default native animation radius (-1 means use platform default).
        /// </summary>
        public const int NativeAnimationRadius = -1;

        /// <summary>
        /// Default native animation shadow radius.
        /// </summary>
        public const int NativeAnimationShadowRadius = -1;

        /// <summary>
        /// Default pulse count (0 means no pulse).
        /// </summary>
        public const int PulseCount = 0;
    }

    /// <summary>
    /// Platform-specific constants
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// Android specific constants
        /// </summary>
        public static class Android
        {
            /// <summary>
            /// Minimum API level for ripple effect support.
            /// </summary>
            public const int MinRippleApiLevel = 21; // Lollipop

            /// <summary>
            /// Default ripple alpha value.
            /// </summary>
            public const byte DefaultRippleAlpha = 64;

            /// <summary>
            /// Default ripple color RGB values.
            /// </summary>
            public const byte DefaultRippleColor = 128;
        }

        /// <summary>
        /// iOS specific constants
        /// </summary>
        public static class iOS
        {
            /// <summary>
            /// Minimum iOS version for hover gesture support.
            /// </summary>
            public const int MinHoverGestureVersion = 13;
        }

        /// <summary>
        /// Windows specific constants
        /// </summary>
        public static class Windows
        {
            /// <summary>
            /// Default pointer movement threshold in pixels.
            /// </summary>
            public const double DefaultMovementThreshold = 20.0;

            /// <summary>
            /// Maximum animation timeout in milliseconds.
            /// </summary>
            public const int MaxAnimationTimeout = 10000;
        }
    }

    /// <summary>
    /// Visual state names for use with VisualStateManager
    /// </summary>
    public static class VisualStates
    {
        /// <summary>
        /// Visual state for unpressed/normal state.
        /// </summary>
        public const string Unpressed = "Unpressed";

        /// <summary>
        /// Visual state for pressed state.
        /// </summary>
        public const string Pressed = "Pressed";

        /// <summary>
        /// Visual state for hovered state.
        /// </summary>
        public const string Hovered = "Hovered";

        /// <summary>
        /// Visual state for disabled state.
        /// </summary>
        public const string Disabled = "Disabled";

        /// <summary>
        /// Visual state for focused state.
        /// </summary>
        public const string Focused = "Focused";
    }

    /// <summary>
    /// Preset animation durations for common scenarios
    /// </summary>
    public static class PresetDurations
    {
        /// <summary>
        /// Instant feedback with no animation.
        /// </summary>
        public const int Instant = 0;

        /// <summary>
        /// Very fast animation for responsive buttons.
        /// </summary>
        public const int VeryFast = 50;

        /// <summary>
        /// Fast animation for most interactive elements.
        /// </summary>
        public const int Fast = 100;

        /// <summary>
        /// Normal animation speed for standard interactions.
        /// </summary>
        public const int Normal = 150;

        /// <summary>
        /// Slow animation for emphasis or special effects.
        /// </summary>
        public const int Slow = 250;

        /// <summary>
        /// Very slow animation for dramatic effects.
        /// </summary>
        public const int VerySlow = 500;
    }
}