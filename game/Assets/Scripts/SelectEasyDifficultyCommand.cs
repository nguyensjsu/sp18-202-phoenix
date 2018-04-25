public class SelectEasyDifficultyCommand : ICommand {

	private Receiver receiver;

	public void execute() {
		receiver.doAction("Easy Difficulty");
	}

	public void setReceiver(Receiver target) {
		receiver = target;
	}
}

