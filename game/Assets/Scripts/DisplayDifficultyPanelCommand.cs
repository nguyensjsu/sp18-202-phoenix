public class DisplayDifficultyPanelCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Display Difficulty");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}
