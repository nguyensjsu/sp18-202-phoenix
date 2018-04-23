public interface ICommand {
	void execute();
	void setReceiver(Receiver target);
}
