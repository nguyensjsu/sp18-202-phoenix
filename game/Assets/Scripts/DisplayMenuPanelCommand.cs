public class DisplayMenuPanelCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Display Menu");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}

