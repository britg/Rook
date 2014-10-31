using UnityEngine;
using System.Collections;

public class EnemyRegistryController : GameBehaviour {

	public EnemyRegistry enemyRegistry { get; set; }

	void Awake () {
		enemyRegistry = new EnemyRegistry();
	}

}
