using System.Collections;

public interface IGameSystem {

	IEnumerator Spawn();
    IEnumerator LoadScene();

	int Level { get; }
	bool IsPaused { get; }
	bool IsOver { get; }
	ArrayList MonsterList { get; }
}
