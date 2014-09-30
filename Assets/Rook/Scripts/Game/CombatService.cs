using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatService {

	bool inCombat = false;
	public bool InCombat {
		get {
			return inCombat;
		}
	}
	List<GameObject> enemiesInCombat = new List<GameObject>();

    public void EnterCombat (GameObject enemyObj) {

		if (!enemiesInCombat.Contains(enemyObj)) {
			enemiesInCombat.Add(enemyObj);
		}

        if (inCombat) {
            return;
        }

        Debug.Log("Entering combat!");
        inCombat = true;
    }

	public void ExitCombat (GameObject enemyObj) {
		if (!inCombat) {
			return;
		}

		enemiesInCombat.Remove(enemyObj);
		if (enemiesInCombat.Count <= 0) {
			Debug.Log ("Exiting combat!");
			inCombat = false;
		}
	}
}
