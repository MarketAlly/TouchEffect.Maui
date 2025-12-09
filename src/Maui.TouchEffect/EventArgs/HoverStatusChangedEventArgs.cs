using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

public class HoverStatusChangedEventArgs : EventArgs
{
	internal HoverStatusChangedEventArgs(HoverStatus status)
	{
		Status = status;
	}

	public HoverStatus Status { get; }
}
