public interface IGameSystem {
	void Initialize();
    void Run();
    void End();

	int Level { get; }
}
