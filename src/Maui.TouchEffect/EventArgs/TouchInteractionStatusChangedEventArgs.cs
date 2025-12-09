using MarketAlly.TouchEffect.Maui.Enums;

namespace MarketAlly.TouchEffect.Maui;

public class TouchInteractionStatusChangedEventArgs : EventArgs
{
	internal TouchInteractionStatusChangedEventArgs(TouchInteractionStatus touchInteractionStatus)
	{
		TouchInteractionStatus = touchInteractionStatus;
	}

	public TouchInteractionStatus TouchInteractionStatus { get; }
}
