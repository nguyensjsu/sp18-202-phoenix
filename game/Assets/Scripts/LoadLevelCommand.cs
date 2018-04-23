public class LoadLevelCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Play");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}
