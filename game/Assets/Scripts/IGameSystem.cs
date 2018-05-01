using System.Collections;

public interface IGameSystem {

	IEnumerator Spawn();

	int Level { get; }
	bool IsPaused { get; }
	bool IsOver { get; }
	ArrayList MonsterList { get; }
}
