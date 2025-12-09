using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

public class TouchStatusChangedEventArgs : EventArgs
{
	internal TouchStatusChangedEventArgs(TouchStatus status)
	{
		Status = status;
	}

	public TouchStatus Status { get; }
}
