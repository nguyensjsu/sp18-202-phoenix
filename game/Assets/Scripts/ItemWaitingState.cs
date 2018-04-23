using System;

public class WaitingState: IItemStates
{
	IItem item;

	public WaitingState (IItem item)
	{
		this.item = item;
	}

	public void waiting() {
	}

	public void idle() {
	}

	public void executing() {
	}
}
