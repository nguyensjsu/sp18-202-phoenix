public class DisplayControlsPanelCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Display Controls");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}
