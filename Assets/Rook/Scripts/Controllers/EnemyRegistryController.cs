using UnityEngine;
using System.Collections;

public class EnemyRegistryController : GameBehaviour {

	public override EnemyRegistry enemyRegistry { get; set; }

	void Awake () {
		enemyRegistry = new EnemyRegistry();
	}

}
