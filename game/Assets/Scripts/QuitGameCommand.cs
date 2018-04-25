public class QuitGameCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Quit");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}
