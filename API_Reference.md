# MarketAlly.TouchEffect.Maui API Reference

Complete API documentation for MarketAlly.TouchEffect.Maui v2.0.0.

## Table of Contents

- [TouchEffect Class](#toucheffect-class)
  - [Attached Properties](#attached-properties)
  - [Events](#events)
  - [Static Methods](#static-methods)
- [TouchBehavior Class](#touchbehavior-class)
- [TouchEffectBuilder Class](#toucheffectbuilder-class)
- [TouchEffectPresets Class](#toucheffectpresets-class)
- [Enumerations](#enumerations)
- [Interfaces](#interfaces)
- [Constants](#constants)

---

## TouchEffect Class

The core class that provides touch and hover visual feedback for any `VisualElement`.

**Namespace:** `MarketAlly.TouchEffect.Maui`

**Inheritance:** `RoutingEffect`

### Attached Properties

#### State Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `IsAvailable` | `bool` | `true` | Enables or disables the touch effect. When `false`, no touch feedback occurs. |
| `ShouldMakeChildrenInputTransparent` | `bool` | `true` | When `true`, child elements become input-transparent to allow touch to pass through. |
| `Status` | `TouchStatus` | `Completed` | **Read-only.** Current touch status (Started, Completed, Canceled). |
| `State` | `TouchState` | `Normal` | **Read-only.** Current touch state (Normal, Pressed). |
| `InteractionStatus` | `TouchInteractionStatus` | `Completed` | **Read-only.** Current interaction status. |
| `HoverStatus` | `HoverStatus` | `Exited` | **Read-only.** Current hover status (Entered, Exited). |
| `HoverState` | `HoverState` | `Normal` | **Read-only.** Current hover state (Normal, Hovered). |

**Usage:**
```xml
<Frame touch:TouchEffect.IsAvailable="{Binding CanInteract}"
       touch:TouchEffect.ShouldMakeChildrenInputTransparent="True">
    <Label Text="Interactive Content" />
</Frame>
```

#### Command Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Command` | `ICommand` | `null` | Command executed when touch completes successfully. |
| `CommandParameter` | `object` | `null` | Parameter passed to the `Command`. |
| `LongPressCommand` | `ICommand` | `null` | Command executed after long press duration elapses. |
| `LongPressCommandParameter` | `object` | `null` | Parameter for the `LongPressCommand`. Falls back to `CommandParameter` if null. |
| `LongPressDuration` | `int` | `500` | Duration in milliseconds before `LongPressCommand` executes. |

**Usage:**
```xml
<Frame touch:TouchEffect.Command="{Binding TapCommand}"
       touch:TouchEffect.CommandParameter="{Binding Item}"
       touch:TouchEffect.LongPressCommand="{Binding ContextMenuCommand}"
       touch:TouchEffect.LongPressDuration="800">
    <Label Text="Tap or Long Press" />
</Frame>
```

#### Background Color Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `NormalBackgroundColor` | `Color` | `Default` | Background color in normal state. |
| `HoveredBackgroundColor` | `Color` | `Default` | Background color when hovered (desktop platforms). |
| `PressedBackgroundColor` | `Color` | `Default` | Background color when pressed. |

**Usage:**
```xml
<Frame touch:TouchEffect.NormalBackgroundColor="White"
       touch:TouchEffect.HoveredBackgroundColor="LightGray"
       touch:TouchEffect.PressedBackgroundColor="Gray">
    <Label Text="Color Feedback" />
</Frame>
```

#### Opacity Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `NormalOpacity` | `double` | `1.0` | Opacity in normal state. |
| `HoveredOpacity` | `double` | `1.0` | Opacity when hovered. |
| `PressedOpacity` | `double` | `1.0` | Opacity when pressed. |

**Usage:**
```xml
<Frame touch:TouchEffect.NormalOpacity="1.0"
       touch:TouchEffect.HoveredOpacity="0.9"
       touch:TouchEffect.PressedOpacity="0.7">
    <Label Text="Opacity Feedback" />
</Frame>
```

#### Scale Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `NormalScale` | `double` | `1.0` | Scale in normal state. |
| `HoveredScale` | `double` | `1.0` | Scale when hovered. |
| `PressedScale` | `double` | `1.0` | Scale when pressed. |

**Usage:**
```xml
<Frame touch:TouchEffect.NormalScale="1.0"
       touch:TouchEffect.HoveredScale="1.02"
       touch:TouchEffect.PressedScale="0.95">
    <Label Text="Scale Feedback" />
</Frame>
```

#### Translation Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `NormalTranslationX` | `double` | `0.0` | X translation in normal state. |
| `HoveredTranslationX` | `double` | `0.0` | X translation when hovered. |
| `PressedTranslationX` | `double` | `0.0` | X translation when pressed. |
| `NormalTranslationY` | `double` | `0.0` | Y translation in normal state. |
| `HoveredTranslationY` | `double` | `0.0` | Y translation when hovered. |
| `PressedTranslationY` | `double` | `0.0` | Y translation when pressed. |

**Usage:**
```xml
<Frame touch:TouchEffect.PressedTranslationY="2">
    <Label Text="Moves down when pressed" />
</Frame>
```

#### Rotation Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `NormalRotation` | `double` | `0.0` | Z-axis rotation in normal state (degrees). |
| `HoveredRotation` | `double` | `0.0` | Z-axis rotation when hovered. |
| `PressedRotation` | `double` | `0.0` | Z-axis rotation when pressed. |
| `NormalRotationX` | `double` | `0.0` | X-axis rotation in normal state. |
| `HoveredRotationX` | `double` | `0.0` | X-axis rotation when hovered. |
| `PressedRotationX` | `double` | `0.0` | X-axis rotation when pressed. |
| `NormalRotationY` | `double` | `0.0` | Y-axis rotation in normal state. |
| `HoveredRotationY` | `double` | `0.0` | Y-axis rotation when hovered. |
| `PressedRotationY` | `double` | `0.0` | Y-axis rotation when pressed. |

**Usage:**
```xml
<Frame touch:TouchEffect.PressedRotation="5">
    <Label Text="Tilts when pressed" />
</Frame>
```

#### Animation Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `AnimationDuration` | `int` | `0` | Default animation duration in milliseconds. |
| `AnimationEasing` | `Easing` | `null` | Default easing function for animations. |
| `PressedAnimationDuration` | `int` | `0` | Animation duration for pressed state transitions. |
| `PressedAnimationEasing` | `Easing` | `null` | Easing for pressed state transitions. |
| `NormalAnimationDuration` | `int` | `0` | Animation duration for returning to normal state. |
| `NormalAnimationEasing` | `Easing` | `null` | Easing for normal state transitions. |
| `HoveredAnimationDuration` | `int` | `0` | Animation duration for hover state transitions. |
| `HoveredAnimationEasing` | `Easing` | `null` | Easing for hover state transitions. |
| `PulseCount` | `int` | `0` | Number of pulse repetitions. Use `-1` for infinite. |

**Usage:**
```xml
<Frame touch:TouchEffect.AnimationDuration="150"
       touch:TouchEffect.AnimationEasing="{x:Static Easing.CubicOut}"
       touch:TouchEffect.PressedScale="0.95">
    <Label Text="Animated Feedback" />
</Frame>
```

#### Toggle Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `IsToggled` | `bool?` | `null` | Toggle state. `null` disables toggle behavior. Supports two-way binding. |
| `DisallowTouchThreshold` | `int` | `0` | Movement threshold in pixels before touch is canceled. |

**Usage:**
```xml
<Frame touch:TouchEffect.IsToggled="{Binding IsSelected, Mode=TwoWay}"
       touch:TouchEffect.PressedBackgroundColor="Blue"
       touch:TouchEffect.NormalBackgroundColor="Gray">
    <Label Text="Toggle Button" />
</Frame>
```

#### Native Animation Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `NativeAnimation` | `bool` | `false` | Enables platform-specific animations (Android ripple, iOS highlight). |
| `NativeAnimationColor` | `Color` | `Default` | Color for native animation effects. |
| `NativeAnimationRadius` | `int` | `-1` | Radius for native ripple effect. `-1` uses default. |
| `NativeAnimationShadowRadius` | `int` | `-1` | Shadow radius for native effects. |
| `NativeAnimationBorderless` | `bool` | `false` | When `true`, ripple extends beyond view bounds. |

**Usage:**
```xml
<Frame touch:TouchEffect.NativeAnimation="True"
       touch:TouchEffect.NativeAnimationColor="Blue"
       touch:TouchEffect.NativeAnimationRadius="100">
    <Label Text="Native Ripple Effect" />
</Frame>
```

#### Background Image Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `NormalBackgroundImageSource` | `ImageSource` | `null` | Background image in normal state. |
| `HoveredBackgroundImageSource` | `ImageSource` | `null` | Background image when hovered. |
| `PressedBackgroundImageSource` | `ImageSource` | `null` | Background image when pressed. |
| `BackgroundImageAspect` | `Aspect` | `AspectFill` | Default aspect ratio for background images. |
| `NormalBackgroundImageAspect` | `Aspect` | `AspectFill` | Aspect ratio for normal state image. |
| `HoveredBackgroundImageAspect` | `Aspect` | `AspectFill` | Aspect ratio for hovered state image. |
| `PressedBackgroundImageAspect` | `Aspect` | `AspectFill` | Aspect ratio for pressed state image. |
| `ShouldSetImageOnAnimationEnd` | `bool` | `false` | When `true`, image changes occur after animation completes. |

### Events

| Event | EventArgs | Description |
|-------|-----------|-------------|
| `StatusChanged` | `TouchStatusChangedEventArgs` | Fired when touch status changes. |
| `StateChanged` | `TouchStateChangedEventArgs` | Fired when touch state changes. |
| `InteractionStatusChanged` | `TouchInteractionStatusChangedEventArgs` | Fired when interaction status changes. |
| `HoverStatusChanged` | `HoverStatusChangedEventArgs` | Fired when hover status changes. |
| `HoverStateChanged` | `HoverStateChangedEventArgs` | Fired when hover state changes. |
| `Completed` | `TouchCompletedEventArgs` | Fired when touch completes successfully. |
| `LongPressCompleted` | `LongPressCompletedEventArgs` | Fired when long press completes. |

**Usage in Code-Behind:**
```csharp
public partial class MyPage : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Get the effect instance
        var effect = MyView.Effects.OfType<TouchEffect>().FirstOrDefault();
        if (effect != null)
        {
            effect.Completed += OnTouchCompleted;
            effect.StateChanged += OnStateChanged;
        }
    }

    private void OnTouchCompleted(object sender, TouchCompletedEventArgs e)
    {
        Debug.WriteLine($"Touch completed with parameter: {e.Parameter}");
    }

    private void OnStateChanged(object sender, TouchStateChangedEventArgs e)
    {
        Debug.WriteLine($"State changed to: {e.State}");
    }
}
```

### Static Methods

#### SetLogger

```csharp
public static void SetLogger(ITouchEffectLogger? logger)
```

Sets the logger instance for all TouchEffect operations.

**Parameters:**
- `logger`: The logger implementation. Pass `null` to disable logging.

**Usage:**
```csharp
// Enable default console logging
TouchEffect.SetLogger(new DefaultTouchEffectLogger());

// Disable logging
TouchEffect.SetLogger(null);

// Custom logging
TouchEffect.SetLogger(new MyCustomLogger());
```

---

## TouchBehavior Class

**NEW in v2.0.0**

A Behavior-based alternative to `TouchEffect` for attaching touch feedback to elements. MAUI is moving toward Behaviors over Effects, making this the preferred modern API.

**Namespace:** `MarketAlly.TouchEffect.Maui`

**Inheritance:** `Behavior<VisualElement>`

### Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Command` | `ICommand` | `null` | Command executed on tap. |
| `CommandParameter` | `object` | `null` | Parameter for the command. |
| `LongPressCommand` | `ICommand` | `null` | Command for long press. |
| `LongPressCommandParameter` | `object` | `null` | Parameter for long press command. |
| `LongPressDuration` | `int` | `500` | Long press duration in ms. |
| `PressedScale` | `double` | `1.0` | Scale when pressed. |
| `PressedOpacity` | `double` | `1.0` | Opacity when pressed. |
| `PressedBackgroundColor` | `Color` | `null` | Background color when pressed. |
| `HoveredScale` | `double` | `1.0` | Scale when hovered. |
| `HoveredOpacity` | `double` | `1.0` | Opacity when hovered. |
| `HoveredBackgroundColor` | `Color` | `null` | Background color when hovered. |
| `NormalScale` | `double` | `1.0` | Scale in normal state. |
| `NormalOpacity` | `double` | `1.0` | Opacity in normal state. |
| `NormalBackgroundColor` | `Color` | `null` | Background color in normal state. |
| `AnimationDuration` | `int` | `100` | Animation duration in ms. |
| `AnimationEasing` | `Easing` | `null` | Animation easing function. |
| `NativeAnimation` | `bool` | `false` | Enable native platform animations. |
| `NativeAnimationColor` | `Color` | `null` | Color for native animations. |
| `IsToggled` | `bool?` | `null` | Toggle state (two-way bindable). |
| `IsAvailable` | `bool` | `true` | Enable/disable the behavior. |

### Usage

**XAML:**
```xml
<Button Text="Click Me">
    <Button.Behaviors>
        <touch:TouchBehavior
            PressedScale="0.95"
            PressedOpacity="0.8"
            AnimationDuration="100"
            AnimationEasing="{x:Static Easing.CubicOut}"
            Command="{Binding TapCommand}" />
    </Button.Behaviors>
</Button>
```

**C#:**
```csharp
var button = new Button { Text = "Click Me" };
button.Behaviors.Add(new TouchBehavior
{
    PressedScale = 0.95,
    PressedOpacity = 0.8,
    AnimationDuration = 100,
    Command = viewModel.TapCommand
});
```

---

## TouchEffectBuilder Class

Fluent builder for configuring TouchEffect with a clean, chainable API.

**Namespace:** `MarketAlly.TouchEffect.Maui`

### Static Methods

#### For

```csharp
public static TouchEffectBuilder For(VisualElement element)
```

Creates a builder for the specified element.

### Instance Methods

#### Command Configuration

| Method | Description |
|--------|-------------|
| `WithCommand(ICommand command, object? parameter = null)` | Sets the tap command. |
| `WithLongPressCommand(ICommand command, object? parameter = null)` | Sets the long press command. |
| `WithLongPressDuration(int milliseconds)` | Sets long press duration. |

#### Visual Configuration

| Method | Description |
|--------|-------------|
| `WithPressedState(double? opacity, double? scale, Color? backgroundColor)` | Configures pressed state. |
| `WithHoveredState(double? opacity, double? scale, Color? backgroundColor)` | Configures hovered state. |
| `WithNormalState(double? opacity, double? scale, Color? backgroundColor)` | Configures normal state. |
| `WithPressedOpacity(double opacity)` | Sets pressed opacity. |
| `WithPressedScale(double scale)` | Sets pressed scale. |
| `WithPressedBackgroundColor(Color color)` | Sets pressed background color. |
| `WithHoveredScale(double scale)` | Sets hovered scale. |

#### Animation Configuration

| Method | Description |
|--------|-------------|
| `WithAnimation(int duration, Easing? easing = null)` | Sets animation duration and easing. |
| `WithPressedAnimation(int duration, Easing? easing = null)` | Sets pressed state animation. |
| `WithHoveredAnimation(int duration, Easing? easing = null)` | Sets hovered state animation. |
| `WithPulse(int count)` | Sets pulse count. |
| `WithInfinitePulse()` | Enables infinite pulsing. |

#### Native Animation Configuration

| Method | Description |
|--------|-------------|
| `WithNativeAnimation(Color? color = null, int radius = -1)` | Enables native platform animations. |

#### Toggle Configuration

| Method | Description |
|--------|-------------|
| `AsToggle(bool initialState = false)` | Enables toggle behavior. |

#### Other Configuration

| Method | Description |
|--------|-------------|
| `WithDisallowThreshold(int pixels)` | Sets movement cancellation threshold. |
| `Disable()` | Disables the effect. |

#### Preset Methods

| Method | Description |
|--------|-------------|
| `AsButton()` | Applies standard button preset. |
| `AsCard()` | Applies card preset with scale effect. |
| `AsListItem()` | Applies list item preset with background color. |
| `AsFloatingActionButton()` | Applies FAB preset with native animation. |

#### Build Methods

| Method | Returns | Description |
|--------|---------|-------------|
| `Build()` | `VisualElement` | Applies configuration and returns the element. |
| `Apply()` | `TouchEffectBuilder` | Applies configuration and returns builder for chaining. |

### Usage

```csharp
// Basic usage
var button = TouchEffectBuilder.For(myFrame)
    .WithPressedScale(0.95)
    .WithPressedOpacity(0.8)
    .WithAnimation(100, Easing.CubicOut)
    .WithCommand(tapCommand)
    .Build();

// Using presets
var card = TouchEffectBuilder.For(myCard)
    .AsCard()
    .WithCommand(selectCommand)
    .Build();

// Complex configuration
var interactive = TouchEffectBuilder.For(element)
    .WithPressedState(opacity: 0.7, scale: 0.95, backgroundColor: Colors.LightGray)
    .WithHoveredState(opacity: 1.0, scale: 1.02, backgroundColor: Colors.White)
    .WithAnimation(150, Easing.CubicInOut)
    .WithLongPressCommand(contextMenuCommand)
    .WithLongPressDuration(800)
    .AsToggle()
    .Build();
```

### Extension Methods

```csharp
// Create a builder for any VisualElement
public static TouchEffectBuilder ConfigureTouchEffect(this VisualElement element)

// Quick presets
public static VisualElement WithButtonEffect(this VisualElement element, ICommand? command = null)
public static VisualElement WithCardEffect(this VisualElement element, ICommand? command = null)
```

---

## TouchEffectPresets Class

Predefined TouchEffect configurations for common UI patterns.

**Namespace:** `MarketAlly.TouchEffect.Maui`

### Button Presets

| Method | Description |
|--------|-------------|
| `Button.Apply(element)` | Standard button with opacity feedback (0.7 pressed). |
| `Button.ApplyPrimary(element)` | Primary button with scale (0.95) and opacity (0.8). |
| `Button.ApplySecondary(element)` | Secondary button with subtle opacity (0.6). |
| `Button.ApplyText(element)` | Text button with minimal feedback (0.5 opacity, instant). |

### Card Presets

| Method | Description |
|--------|-------------|
| `Card.Apply(element)` | Standard card with subtle scale (0.97). |
| `Card.ApplyElevated(element)` | Elevated card with scale (0.95), opacity (0.9), hover scale (1.02). |
| `Card.ApplyInteractive(element)` | Interactive card with hover background highlight. |

### ListItem Presets

| Method | Description |
|--------|-------------|
| `ListItem.Apply(element)` | Standard list item with background highlight. |
| `ListItem.ApplySelectable(element)` | Selectable item with toggle behavior. |
| `ListItem.ApplySwipeable(element)` | Swipeable item with scale feedback. |

### IconButton Presets

| Method | Description |
|--------|-------------|
| `IconButton.Apply(element)` | Standard icon button with scale (0.85), spring animation. |
| `IconButton.ApplyFloatingAction(element)` | FAB with scale (0.9), native animation. |
| `IconButton.ApplyToolbar(element)` | Toolbar icon with subtle opacity (0.5). |

### Toggle Presets

| Method | Description |
|--------|-------------|
| `Toggle.Apply(element)` | Standard toggle with scale effect. |
| `Toggle.ApplyCheckbox(element)` | Checkbox-style with bounce animation. |

### Image Presets

| Method | Description |
|--------|-------------|
| `Image.ApplyThumbnail(element)` | Thumbnail with scale (0.95 pressed, 1.05 hover). |
| `Image.ApplyGallery(element)` | Gallery image with zoom effect (1.1 hover). |
| `Image.ApplyAvatar(element)` | Avatar with subtle feedback. |

### Native Presets

| Method | Description |
|--------|-------------|
| `Native.ApplyRipple(element, color?)` | Android ripple effect. |
| `Native.ApplyHaptic(element)` | iOS-style haptic feedback. |

### Special Presets

| Method | Description |
|--------|-------------|
| `Special.ApplyPulse(element, count)` | Pulse effect with repeating animation. |
| `Special.ApplyBounce(element)` | Bounce effect with spring animation. |
| `Special.ApplyShake(element)` | Shake effect with rotation. |
| `Special.ApplyDisabled(element)` | Disabled state with no interaction. |

### Extension Methods

```csharp
element.WithButtonPreset();
element.WithCardPreset();
element.WithListItemPreset();
element.WithIconButtonPreset();
element.WithNativeEffect(color?);
```

---

## Enumerations

### TouchStatus

**Namespace:** `MarketAlly.TouchEffect.Maui.Enums`

| Value | Description |
|-------|-------------|
| `Started` | Touch has started. |
| `Completed` | Touch completed successfully. |
| `Canceled` | Touch was canceled (moved outside, interrupted). |

### TouchState

**Namespace:** `MarketAlly.TouchEffect.Maui.Enums`

| Value | Description |
|-------|-------------|
| `Normal` | Element is in normal state. |
| `Pressed` | Element is being pressed. |

### TouchInteractionStatus

**Namespace:** `MarketAlly.TouchEffect.Maui.Enums`

| Value | Description |
|-------|-------------|
| `Started` | User interaction started. |
| `Completed` | User interaction completed. |

### HoverStatus

**Namespace:** `MarketAlly.TouchEffect.Maui.Enums`

| Value | Description |
|-------|-------------|
| `Entered` | Pointer entered the element. |
| `Exited` | Pointer exited the element. |

### HoverState

**Namespace:** `MarketAlly.TouchEffect.Maui.Enums`

| Value | Description |
|-------|-------------|
| `Normal` | Element is not being hovered. |
| `Hovered` | Element is being hovered. |

---

## Interfaces

### ITouchEffectLogger

**Namespace:** `MarketAlly.TouchEffect.Maui.Interfaces`

Interface for custom logging implementations.

```csharp
public interface ITouchEffectLogger
{
    void LogError(Exception ex, string context, string? additionalInfo = null);
    void LogWarning(string message, string context);
    void LogInfo(string message, string context);
}
```

### Built-in Implementations

#### DefaultTouchEffectLogger

Logs to `Debug.WriteLine` with formatted output.

```csharp
TouchEffect.SetLogger(new DefaultTouchEffectLogger());
```

#### NullTouchEffectLogger

No-op logger that discards all messages. Used by default.

```csharp
// Singleton instance
NullTouchEffectLogger.Instance
```

---

## Constants

### TouchEffectConstants

**Namespace:** `MarketAlly.TouchEffect.Maui`

#### Defaults

| Constant | Value | Description |
|----------|-------|-------------|
| `LongPressDuration` | `500` | Default long press duration (ms). |
| `Opacity` | `1.0` | Default opacity. |
| `Scale` | `1.0` | Default scale. |
| `TranslationX` | `0.0` | Default X translation. |
| `TranslationY` | `0.0` | Default Y translation. |
| `Rotation` | `0.0` | Default rotation. |
| `PulseCount` | `0` | Default pulse count. |
| `DisallowTouchThreshold` | `0` | Default movement threshold. |
| `NativeAnimationRadius` | `-1` | Default native animation radius. |
| `NativeAnimationShadowRadius` | `-1` | Default shadow radius. |

#### Animation

| Constant | Value | Description |
|----------|-------|-------------|
| `DefaultDuration` | `0` | Default animation duration. |
| `DefaultProgressDelay` | `10` | Delay between animation frames. |
| `TargetFrameRate` | `60` | Target animation frame rate. |

#### PresetDurations

| Constant | Value | Description |
|----------|-------|-------------|
| `Instant` | `0` | No animation. |
| `VeryFast` | `50` | Very fast animations (ms). |
| `Fast` | `100` | Fast animations (ms). |
| `Normal` | `200` | Normal animations (ms). |
| `Slow` | `300` | Slow animations (ms). |

#### VisualStates

| Constant | Value |
|----------|-------|
| `Unpressed` | `"Unpressed"` |
| `Pressed` | `"Pressed"` |
| `Hovered` | `"Hovered"` |

#### Platform.Android

| Constant | Value | Description |
|----------|-------|-------------|
| `DefaultRippleColor` | `128` | Default ripple RGB value. |
| `DefaultRippleAlpha` | `80` | Default ripple alpha. |
| `MinRippleRadius` | `48` | Minimum ripple radius (dp). |

#### Platform.iOS

| Constant | Value | Description |
|----------|-------|-------------|
| `HighlightAlpha` | `0.5f` | Default highlight alpha. |

---

## Event Args Classes

### TouchStatusChangedEventArgs

```csharp
public class TouchStatusChangedEventArgs : EventArgs
{
    public TouchStatus Status { get; }
}
```

### TouchStateChangedEventArgs

```csharp
public class TouchStateChangedEventArgs : EventArgs
{
    public TouchState State { get; }
}
```

### TouchInteractionStatusChangedEventArgs

```csharp
public class TouchInteractionStatusChangedEventArgs : EventArgs
{
    public TouchInteractionStatus InteractionStatus { get; }
}
```

### HoverStatusChangedEventArgs

```csharp
public class HoverStatusChangedEventArgs : EventArgs
{
    public HoverStatus Status { get; }
}
```

### HoverStateChangedEventArgs

```csharp
public class HoverStateChangedEventArgs : EventArgs
{
    public HoverState State { get; }
}
```

### TouchCompletedEventArgs

```csharp
public class TouchCompletedEventArgs : EventArgs
{
    public object? Parameter { get; }
}
```

### LongPressCompletedEventArgs

```csharp
public class LongPressCompletedEventArgs : EventArgs
{
    public object? Parameter { get; }
}
```

---

## Migration Guide

### From v1.x to v2.0

1. **Update package reference** to version 2.0.0
2. **Update target framework** to .NET 10 if needed
3. **Optional: Use TouchBehavior** instead of attached properties for new code
4. **Optional: Configure logging** using `TouchEffect.SetLogger()`

No breaking changes - all v1.x code continues to work.

### From Xamarin TouchEffect

1. Update namespace from `Xamarin.CommunityToolkit.Effects` to `MarketAlly.TouchEffect.Maui`
2. Replace `TouchEff` with `TouchEffect` in XAML
3. Update `UseMauiApp<App>()` to include `.UseMauiTouchEffect()`

---

*Last updated: January 2025 | Version 2.0.0*
