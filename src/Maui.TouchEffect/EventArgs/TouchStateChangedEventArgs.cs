using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

public class TouchStateChangedEventArgs : EventArgs
{
	internal TouchStateChangedEventArgs(TouchState state)
	{
		State = state;
	}

	public TouchState State { get; }
}
