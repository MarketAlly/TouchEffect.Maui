using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

public class HoverStateChangedEventArgs : EventArgs
{
	internal HoverStateChangedEventArgs(HoverState state)
	{
		State = state;
	}

	public HoverState State { get; }
}
