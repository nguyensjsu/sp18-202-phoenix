using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePattern {

	private static MovePattern instance;
	private int level;
	private Dictionary<int, Dictionary<int, Vector2>> patterns = new Dictionary<int, Dictionary<int, Vector2>>();

	private MovePattern(int level) {
		this.level = level;
		patterns[level] = new Dictionary<int, Vector2>();

		TextAsset textAsset = (TextAsset)Resources.Load("Routes", typeof(TextAsset));
		string routesFile = textAsset.text;
		string[] steps = routesFile.Split('\n');
		string[] endpoints = steps[level].Split(',');
		for (int step = 0; step < endpoints.Length; step += 1) {
			float x = float.Parse(endpoints[step].Split('|')[0]);
			float y = float.Parse(endpoints[step].Split('|')[1]);	
			patterns[level][step] = new Vector2(x, y);
		}
	}

	public static MovePattern getInstance(){
		return instance;
	}

	public static void setInstance(int level){
		instance = new MovePattern(level);
	}

	public void Move(IMonster monster) {
		MonoBehaviour behaviour = monster as MonoBehaviour;
		if(behaviour != null) {
			Vector2 current = new Vector2(behaviour.transform.position.x, behaviour.transform.position.y);
			Vector2 target = patterns[level][monster.Step];
			float speed = monster.Speed * Time.deltaTime;
			behaviour.transform.position = Vector2.MoveTowards(current, target, speed);

			bool hasReachedTarget = (Vector2)behaviour.transform.position == patterns[level][monster.Step];
			if(hasReachedTarget) {
				monster.Step++;
			}
		}
	}
}
