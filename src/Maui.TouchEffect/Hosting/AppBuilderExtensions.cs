using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MarketAlly.TouchEffect.Maui.Hosting;

public static class AppBuilderExtensions
{
	public static MauiAppBuilder UseMauiTouchEffect(this MauiAppBuilder builder)
	{
		builder.ConfigureEffects(effects =>
		{
            // Register TouchEffect for all supported platforms
#if IOS
			effects.Add<TouchEffect, PlatformTouchEffect>();
#endif
#if ANDROID
			effects.Add<TouchEffect, PlatformTouchEffect>();
#endif
#if WINDOWS
			effects.Add<TouchEffect, PlatformTouchEffect>();
#endif
		});

		return builder;
	}
}
