using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatService {

	Player player;
    EnemyRegistry enemyRegistry;

	public bool InCombat {
		get {
			return player.inCombat;
		}
	}
	List<Character> charactersInCombat = new List<Character>();

	public CombatService (Player _player, EnemyRegistry _enemyRegistry) {
		player = _player;
        enemyRegistry = _enemyRegistry;
	}

    public void DetectCombat () {
        foreach (Enemy e in enemyRegistry.enemies) {
            bool detectsPlayer = e.Detect(player);

            if (!e.inCombat && detectsPlayer) {
                EnterCombat((Character)e);
            }

            if (e.inCombat && !detectsPlayer) {
                ExitCombat((Character)e);
            }

            if (e.inCombat && e.dead) {
                ExitCombat((Character)e);
            }
        }

        CheckAnyCombat();
    }

    public void EnterCombat (Character character) {
		if (!charactersInCombat.Contains(character)) {
			character.inCombat = true;
			charactersInCombat.Add(character);
		}

        if (InCombat) {
            return;
        }

        Debug.Log("Entering combat!");
		player.inCombat = true;
    }

	public void ExitCombat (Character character) {
		character.inCombat = false;
		charactersInCombat.Remove(character);
        CheckAnyCombat();
	}

    void CheckAnyCombat () {
		if (player.inCombat && charactersInCombat.Count <= 0) {
            Debug.Log("Exiting combat");
			player.inCombat = false;
            player.ResetActionPoints();
		}
    }
}
