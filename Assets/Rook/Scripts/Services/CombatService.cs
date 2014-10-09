using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatService {

	Player player;

	public bool InCombat {
		get {
			return player.inCombat;
		}
	}
	List<GameObject> enemiesInCombat = new List<GameObject>();

	public CombatService (Player _player) {
		player = _player;
	}

    public void EnterCombat (Character enemy) {
		GameObject enemyObj = enemy.go;
		if (!enemiesInCombat.Contains(enemyObj)) {
			enemy.inCombat = true;
			enemiesInCombat.Add(enemyObj);
		}

        if (InCombat) {
            return;
        }

        Debug.Log("Entering combat!");
		player.inCombat = true;
    }

	public void ExitCombat (Character enemy) {
		GameObject enemyObj = enemy.go;
		if (!InCombat) {
			return;
		}

		enemy.inCombat = false;
		enemiesInCombat.Remove(enemyObj);
		if (enemiesInCombat.Count <= 0) {
			Debug.Log ("Exiting combat!");
			player.inCombat = false;
		}
	}
}
