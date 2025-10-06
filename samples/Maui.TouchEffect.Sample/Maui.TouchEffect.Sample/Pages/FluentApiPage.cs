using Maui.TouchEffect;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace Maui.TouchEffect.Sample.Pages;

/// <summary>
/// Sample page demonstrating the new Fluent API and Preset features.
/// </summary>
public class FluentApiPage : ContentPage
{
    private int tapCount = 0;
    private Label statusLabel;

    public FluentApiPage()
    {
        Title = "Fluent API & Presets Demo";
        BackgroundColor = Colors.White;

        var tapCommand = new Command(() =>
        {
            tapCount++;
            statusLabel.Text = $"Taps: {tapCount}";
        });

        statusLabel = new Label
        {
            Text = "Taps: 0",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 20)
        };

        Content = new ScrollView
        {
            Content = new StackLayout
            {
                Padding = 20,
                Spacing = 20,
                Children =
                {
                    new Label
                    {
                        Text = "Fluent API & Preset Demonstrations",
                        FontSize = 24,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },

                    statusLabel,

                    CreateSectionLabel("Fluent Builder API"),

                    // Button created with fluent API
                    CreateFluentButton(tapCommand),

                    // Card with hover effect
                    CreateFluentCard(tapCommand),

                    // List item with background change
                    CreateFluentListItem(tapCommand),

                    CreateSectionLabel("Preset Configurations"),

                    // Primary button preset
                    CreatePresetPrimaryButton(tapCommand),

                    // Elevated card preset
                    CreatePresetElevatedCard(tapCommand),

                    // Icon button preset
                    CreatePresetIconButton(tapCommand),

                    // List item preset
                    CreatePresetListItem(tapCommand),

                    CreateSectionLabel("Special Effects"),

                    // Pulse effect
                    CreatePulseEffect(tapCommand),

                    // Bounce effect
                    CreateBounceEffect(tapCommand),

                    // Native ripple effect
                    CreateNativeRippleEffect(tapCommand)
                }
            }
        };
    }

    private Label CreateSectionLabel(string text)
    {
        return new Label
        {
            Text = text,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.DarkGray,
            Margin = new Thickness(0, 10, 0, 5)
        };
    }

    private View CreateFluentButton(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.Blue,
            CornerRadius = 8,
            Padding = 15,
            Content = new Label
            {
                Text = "Fluent API Button",
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            }
        };

        // Configure with fluent API
        frame.ConfigureTouchEffect()
            .WithPressedScale(0.95)
            .WithPressedOpacity(0.7)
            .WithAnimation(100, Easing.CubicOut)
            .WithCommand(command)
            .Build();

        return frame;
    }

    private View CreateFluentCard(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.White,
            BorderColor = Colors.LightGray,
            CornerRadius = 10,
            Padding = 20,
            HasShadow = true,
            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Card with Hover",
                        FontSize = 16,
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label
                    {
                        Text = "Hover over me (desktop) or tap me!",
                        TextColor = Colors.Gray
                    }
                }
            }
        };

        // Configure with fluent API for card effect
        frame.ConfigureTouchEffect()
            .AsCard()
            .WithCommand(command)
            .Build();

        return frame;
    }

    private View CreateFluentListItem(ICommand command)
    {
        var stack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Padding = 15,
            BackgroundColor = Colors.White,
            Children =
            {
                new BoxView
                {
                    Color = Colors.Green,
                    WidthRequest = 40,
                    HeightRequest = 40,
                    CornerRadius = 20
                },
                new Label
                {
                    Text = "List Item with Background Effect",
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0)
                }
            }
        };

        // Configure with fluent API for list item
        stack.ConfigureTouchEffect()
            .AsListItem()
            .WithCommand(command)
            .Build();

        return new Frame
        {
            Padding = 0,
            CornerRadius = 5,
            Content = stack
        };
    }

    private View CreatePresetPrimaryButton(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.Purple,
            CornerRadius = 8,
            Padding = 15,
            Content = new Label
            {
                Text = "Primary Button Preset",
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            }
        };

        // Apply primary button preset
        TouchEffectPresets.Button.ApplyPrimary(frame);
        TouchEffect.SetCommand(frame, command);

        return frame;
    }

    private View CreatePresetElevatedCard(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.White,
            BorderColor = Colors.Transparent,
            CornerRadius = 12,
            Padding = 20,
            HasShadow = true,
            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Elevated Card Preset",
                        FontSize = 16,
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label
                    {
                        Text = "With scale and hover effects",
                        TextColor = Colors.Gray
                    }
                }
            }
        };

        // Apply elevated card preset
        TouchEffectPresets.Card.ApplyElevated(frame);
        TouchEffect.SetCommand(frame, command);

        return frame;
    }

    private View CreatePresetIconButton(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.Orange,
            CornerRadius = 30,
            WidthRequest = 60,
            HeightRequest = 60,
            HorizontalOptions = LayoutOptions.Center,
            Padding = 0,
            Content = new Label
            {
                Text = "+",
                FontSize = 30,
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }
        };

        // Apply FAB preset
        TouchEffectPresets.IconButton.ApplyFloatingAction(frame);
        TouchEffect.SetCommand(frame, command);

        return frame;
    }

    private View CreatePresetListItem(ICommand command)
    {
        var stack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Padding = 15,
            BackgroundColor = Colors.White,
            Children =
            {
                new Image
                {
                    Source = "dotnet_bot.svg",
                    WidthRequest = 40,
                    HeightRequest = 40
                },
                new StackLayout
                {
                    Margin = new Thickness(10, 0),
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label
                        {
                            Text = "List Item Preset",
                            FontAttributes = FontAttributes.Bold
                        },
                        new Label
                        {
                            Text = "With subtitle",
                            FontSize = 12,
                            TextColor = Colors.Gray
                        }
                    }
                }
            }
        };

        // Apply list item preset
        TouchEffectPresets.ListItem.Apply(stack);
        TouchEffect.SetCommand(stack, command);

        return new Frame
        {
            Padding = 0,
            CornerRadius = 5,
            Content = stack
        };
    }

    private View CreatePulseEffect(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.Red,
            CornerRadius = 10,
            Padding = 15,
            Content = new Label
            {
                Text = "Pulse Effect (3 pulses)",
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            }
        };

        // Apply pulse effect
        TouchEffectPresets.Special.ApplyPulse(frame, 3);
        TouchEffect.SetCommand(frame, command);

        return frame;
    }

    private View CreateBounceEffect(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.Teal,
            CornerRadius = 10,
            Padding = 15,
            Content = new Label
            {
                Text = "Bounce Effect",
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            }
        };

        // Apply bounce effect
        TouchEffectPresets.Special.ApplyBounce(frame);
        TouchEffect.SetCommand(frame, command);

        return frame;
    }

    private View CreateNativeRippleEffect(ICommand command)
    {
        var frame = new Frame
        {
            BackgroundColor = Colors.Indigo,
            CornerRadius = 10,
            Padding = 15,
            Content = new Label
            {
                Text = "Native Ripple Effect",
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            }
        };

        // Apply native ripple effect
        TouchEffectPresets.Native.ApplyRipple(frame, Colors.White);
        TouchEffect.SetCommand(frame, command);

        return frame;
    }
}