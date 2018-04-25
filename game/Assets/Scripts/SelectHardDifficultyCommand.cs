public class SelectHardDifficultyCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Hard Difficulty");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}

