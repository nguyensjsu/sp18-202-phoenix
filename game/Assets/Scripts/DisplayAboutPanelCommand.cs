public class DisplayAboutPanelCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Display About");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}
