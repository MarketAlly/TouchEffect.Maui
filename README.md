# MarketAlly.TouchEffect.Maui

[![NuGet](https://img.shields.io/nuget/v/MarketAlly.TouchEffect.Maui.svg)](https://www.nuget.org/packages/MarketAlly.TouchEffect.Maui)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MarketAlly.TouchEffect.Maui.svg)](https://www.nuget.org/packages/MarketAlly.TouchEffect.Maui)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A comprehensive touch effect library for .NET MAUI applications by **MarketAlly**, providing rich interaction feedback and animations across all platforms. MarketAlly.TouchEffect.Maui brings advanced touch handling, hover states, long press detection, and smooth animations to any MAUI view.

## Features

### 🎯 Core Capabilities
- **Universal Touch Feedback** - Consistent touch interactions across iOS, Android, and Windows
- **50+ Customizable Properties** - Fine-grained control over every aspect of the touch experience
- **Hardware-Accelerated Animations** - Smooth, performant transitions using platform-native acceleration
- **Accessibility First** - Full keyboard, screen reader, and assistive technology support
- **Memory Efficient** - WeakEventManager pattern prevents memory leaks

### 🎨 Visual Effects
- **Opacity Animations** - Fade effects on touch with customizable values
- **Scale Transformations** - Grow or shrink elements during interaction
- **Color Transitions** - Dynamic background color changes for different states
- **Translation & Rotation** - Move and rotate elements during touch
- **Native Platform Effects** - Android ripple effects and iOS haptic feedback

### 🔧 Advanced Features
- **Long Press Detection** - Configurable duration with separate command binding
- **Hover Support** - Mouse and stylus hover states on supported platforms
- **Toggle Behavior** - Switch-like functionality with persistent state
- **Gesture Threshold** - Configurable movement tolerance before cancellation
- **Command Pattern** - MVVM-friendly with ICommand support

## Platform Support

| Platform     | Version    | Features                                          |
|-------------|------------|---------------------------------------------------|
| iOS         | 13.0+      | Full support with haptic feedback                |
| Android     | API 24+    | Full support with native ripple effects          |
| Windows     | 10.0.17763+ | Full support with WinUI 3 animations            |
| Mac Catalyst| ❌         | Not currently supported                          |
| Tizen       | ❌         | Not currently supported                          |

## Installation

### Package Manager
```bash
Install-Package MarketAlly.TouchEffect.Maui -Version 1.0.0
```

### .NET CLI
```bash
dotnet add package MarketAlly.TouchEffect.Maui --version 1.0.0
```

### PackageReference
```xml
<PackageReference Include="MarketAlly.TouchEffect.Maui" Version="1.0.0" />
```

## Quick Start

### 1. Configure Your App

In your `MauiProgram.cs`:

```csharp
using MarketAlly.TouchEffect.Maui.Hosting;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiTouchEffect()  // Add this line
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        return builder.Build();
    }
}
```

### 2. Add Touch Effects to Your Views

#### XAML Approach

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:touch="clr-namespace:MarketAlly.TouchEffect.Maui;assembly=MarketAlly.TouchEffect.Maui"
             x:Class="YourApp.MainPage">

    <StackLayout Padding="20">

        <!-- Simple Button Effect -->
        <Frame touch:TouchEffect.PressedScale="0.95"
               touch:TouchEffect.PressedOpacity="0.7"
               touch:TouchEffect.AnimationDuration="100"
               touch:TouchEffect.Command="{Binding TapCommand}">
            <Label Text="Tap Me" HorizontalOptions="Center" />
        </Frame>

        <!-- Card with Hover Effect -->
        <Frame touch:TouchEffect.PressedScale="0.98"
               touch:TouchEffect.HoveredScale="1.02"
               touch:TouchEffect.HoveredBackgroundColor="LightGray"
               touch:TouchEffect.AnimationDuration="200"
               touch:TouchEffect.AnimationEasing="{x:Static Easing.CubicInOut}">
            <Label Text="Hover or Touch Me" />
        </Frame>

        <!-- Native Ripple Effect (Android) -->
        <Frame touch:TouchEffect.NativeAnimation="True"
               touch:TouchEffect.NativeAnimationColor="Blue"
               touch:TouchEffect.Command="{Binding SelectCommand}">
            <Label Text="Native Effect" />
        </Frame>

    </StackLayout>
</ContentPage>
```

#### 🆕 Fluent Builder Approach (New!)

```csharp
using MarketAlly.TouchEffect.Maui;

// Configure a button with fluent API
var button = new Frame { Content = new Label { Text = "Click Me" } }
    .ConfigureTouchEffect()
    .AsButton()
    .WithCommand(viewModel.TapCommand)
    .Build();

// Create a card with hover effect
var card = new Frame { Content = contentView }
    .ConfigureTouchEffect()
    .AsCard()
    .WithCommand(viewModel.SelectCommand)
    .Build();

// Apply a preset
var listItem = new StackLayout()
    .WithListItemPreset();
```

#### 🆕 Using Presets (New!)

```csharp
// Apply common UI patterns instantly
TouchEffectPresets.Button.ApplyPrimary(myButton);
TouchEffectPresets.Card.ApplyElevated(myCard);
TouchEffectPresets.ListItem.Apply(myListItem);
TouchEffectPresets.IconButton.ApplyFloatingAction(myFab);

// Or use extension methods
myButton.WithButtonPreset();
myCard.WithCardPreset();
myListItem.WithListItemPreset();
```

## 🆕 New Features in v1.0.0

### Fluent Builder Pattern
Configure touch effects with a clean, chainable API:

```csharp
element.ConfigureTouchEffect()
    .WithPressedScale(0.95)
    .WithPressedOpacity(0.7)
    .WithAnimation(100, Easing.CubicOut)
    .WithCommand(tapCommand)
    .Build();
```

### Preset Configurations
Pre-built configurations for common UI patterns:

- **Button Presets**: Primary, Secondary, Text
- **Card Presets**: Standard, Elevated, Interactive
- **List Item Presets**: Standard, Selectable, Swipeable
- **Icon Button Presets**: Standard, FAB, Toolbar
- **Toggle Presets**: Standard, Checkbox
- **Image Presets**: Thumbnail, Gallery, Avatar
- **Native Effects**: Ripple, Haptic
- **Special Effects**: Pulse, Bounce, Shake

### Centralized Constants
All magic numbers replaced with semantic constants:

```csharp
TouchEffectConstants.Defaults.LongPressDuration // 500ms
TouchEffectConstants.Animation.TargetFrameRate  // 60fps
TouchEffectConstants.Platform.Android.MinRippleRadius // 48dp
```

### Enhanced Error Handling
Comprehensive logging interface for debugging:

```csharp
// Implement custom logging
public class MyLogger : ITouchEffectLogger
{
    public void LogError(Exception ex, string context, string? info = null)
    {
        // Log to your preferred service
    }
}

// Configure in your app
TouchEffect.SetLogger(new MyLogger());
```

## Common Use Cases

### Interactive Cards
```xml
<Frame CornerRadius="10"
       touch:TouchEffect.PressedScale="0.95"
       touch:TouchEffect.AnimationDuration="150"
       touch:TouchEffect.Command="{Binding OpenDetailCommand}"
       touch:TouchEffect.CommandParameter="{Binding .}">
    <StackLayout>
        <Image Source="{Binding ImageUrl}" />
        <Label Text="{Binding Title}" FontAttributes="Bold" />
        <Label Text="{Binding Description}" />
    </StackLayout>
</Frame>
```

### Toggle Buttons
```xml
<Frame touch:TouchEffect.IsToggled="{Binding IsSelected}"
       touch:TouchEffect.PressedBackgroundColor="Green"
       touch:TouchEffect.NormalBackgroundColor="Gray">
    <Label Text="Toggle Me" />
</Frame>
```

### Long Press Actions
```xml
<Image Source="photo.jpg"
       touch:TouchEffect.Command="{Binding TapCommand}"
       touch:TouchEffect.LongPressCommand="{Binding ShowMenuCommand}"
       touch:TouchEffect.LongPressDuration="500" />
```

## Properties Reference

### State Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| IsAvailable | bool | true | Enables/disables the effect |
| IsToggled | bool? | null | Toggle state (null = no toggle behavior) |
| Status | TouchStatus | Completed | Current touch status |
| State | TouchState | Normal | Current touch state |

### Animation Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| AnimationDuration | int | 0 | Animation duration in milliseconds |
| AnimationEasing | Easing | null | Animation easing function |
| PulseCount | int | 0 | Number of pulse repetitions (-1 for infinite) |

### Visual Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| PressedOpacity | double | 1.0 | Opacity when pressed |
| PressedScale | double | 1.0 | Scale when pressed |
| PressedBackgroundColor | Color | Default | Background color when pressed |
| HoveredOpacity | double | 1.0 | Opacity when hovered |
| HoveredScale | double | 1.0 | Scale when hovered |
| NormalOpacity | double | 1.0 | Normal state opacity |

### Command Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| Command | ICommand | null | Command to execute on tap |
| CommandParameter | object | null | Parameter for command |
| LongPressCommand | ICommand | null | Command for long press |
| LongPressDuration | int | 500 | Long press duration in ms |

### Platform-Specific Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| NativeAnimation | bool | false | Use platform native animations |
| NativeAnimationColor | Color | Default | Native animation color |
| NativeAnimationRadius | int | -1 | Animation radius (Android/iOS) |

## Events

```csharp
public partial class MyPage : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Subscribe to events
        TouchEffect.SetStatusChanged(MyView, OnTouchStatusChanged);
        TouchEffect.SetStateChanged(MyView, OnTouchStateChanged);
        TouchEffect.SetCompleted(MyView, OnTouchCompleted);
    }

    void OnTouchStatusChanged(object sender, TouchStatusChangedEventArgs e)
    {
        Debug.WriteLine($"Touch Status: {e.Status}");
    }

    void OnTouchStateChanged(object sender, TouchStateChangedEventArgs e)
    {
        Debug.WriteLine($"Touch State: {e.State}");
    }

    void OnTouchCompleted(object sender, TouchCompletedEventArgs e)
    {
        Debug.WriteLine("Touch completed!");
    }
}
```

## Performance Tips

1. **Keep Animations Short** - Use durations under 300ms for responsive feel
2. **Prefer Scale Over Size** - Scale transformations are GPU-accelerated
3. **Use Native Animations** - Enable platform-specific effects when possible
4. **Limit Simultaneous Effects** - Too many concurrent animations can impact performance
5. **Test on Lower-End Devices** - Ensure smooth performance across all target devices

## Accessibility

TouchEffect.Maui is fully accessible by default:

- ✅ **Keyboard Navigation** - Full support for Tab, Enter, and Space keys
- ✅ **Screen Readers** - Compatible with VoiceOver, TalkBack, and Narrator
- ✅ **Focus Indicators** - Proper focus visualization
- ✅ **Touch Exploration** - Support for accessibility touch modes

```xml
<!-- Accessible button with semantic properties -->
<Frame touch:TouchEffect.Command="{Binding SubmitCommand}"
       SemanticProperties.Description="Submit form button"
       SemanticProperties.Hint="Double tap to submit">
    <Label Text="Submit" />
</Frame>
```

## Troubleshooting

### Touch Not Working
- Verify `IsAvailable` is true
- Check parent view `InputTransparent` settings
- Ensure view has appropriate size (not 0x0)

### Animations Stuttering
- Reduce `AnimationDuration`
- Disable debug mode for testing
- Check for layout cycles during animation

### Platform-Specific Issues

**iOS**: Ensure `View.UserInteractionEnabled` is true in custom renderers

**Android**: For API 21+, native ripple requires a bounded view

**Windows**: Hover only works with mouse/pen, not touch input

## Migration from Xamarin

If migrating from Xamarin.Forms TouchEffect:

1. Update namespace: `Xamarin.CommunityToolkit` → `MarketAlly.TouchEffect.Maui`
2. Update package reference to `MarketAlly.TouchEffect.Maui`
3. Add `.UseMauiTouchEffect()` in MauiProgram.cs
4. Properties and behavior remain the same

## Contributing

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) for details.

### Building from Source

```bash
# Clone the repository
git clone https://github.com/felipebaltazar/TouchEffect.git

# Build the project
dotnet build src/Maui.TouchEffect/TouchEffect.Maui.csproj

# Run tests
dotnet test

# Pack NuGet package
dotnet pack src/Maui.TouchEffect/TouchEffect.Maui.csproj
```

## Changelog

### Version 1.0.0 (2024-11)
- 🆕 **Fluent Builder Pattern**: New intuitive API for configuring touch effects
- 🆕 **Preset Configurations**: 20+ pre-built configurations for common UI patterns
- 🆕 **Centralized Constants**: Eliminated magic numbers throughout codebase
- 🆕 **Logging Interface**: Comprehensive error handling and debugging support
- 🆕 **Windows Support**: Full Windows platform implementation with WinUI 3
- ✨ **Code Quality**: Partial classes, improved organization, and documentation
- 🐛 **Bug Fixes**: Fixed .NET 9 compatibility issues
- 📝 **Documentation**: Enhanced XML documentation for all public APIs

### Version 8.1.0
- Initial release as MarketAlly.TouchEffect.Maui
- Ported from original TouchEffect for .NET MAUI
- Full iOS and Android support

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Based on the original [TouchEffect](https://github.com/felipebaltazar/TouchEffect) by Andrei (MIT License)
- Original [Xamarin Community Toolkit](https://github.com/xamarin/XamarinCommunityToolkit) team
- [.NET MAUI](https://github.com/dotnet/maui) team
- All [contributors](https://github.com/MarketAlly/TouchEffect/graphs/contributors)

## Support

- 📖 [Documentation](https://github.com/MarketAlly/TouchEffect/wiki)
- 🐛 [Report Issues](https://github.com/MarketAlly/TouchEffect/issues)
- 💬 [Discussions](https://github.com/MarketAlly/TouchEffect/discussions)
- ⭐ Star this repository if you find it helpful!

---

Made with ❤️ by **MarketAlly** for the .NET MAUI Community

*Based on the original TouchEffect by Andrei - Used under MIT License*