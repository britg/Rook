using UnityEngine;
using System.Collections;

public class EnemyRegistryController : GameController {

	public override EnemyRegistry enemyRegistry { get; set; }

	void Awake () {
		enemyRegistry = new EnemyRegistry();
	}

}
