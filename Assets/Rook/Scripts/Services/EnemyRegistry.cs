using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyRegistry {

    public List<Enemy> enemies = new List<Enemy>();
	List<Enemy> enemiesTakingTurn = new List<Enemy>();
    List<Enemy> enemiesInCombat = new List<Enemy>();

    public void Register (Enemy enemy) {
        enemies.Add(enemy);
    }

	public void Unregister (Enemy enemy) {
		enemies.Remove(enemy);
	}

	public void SeedTurn () {
		enemiesTakingTurn = enemies;
	}

	public Enemy NextEnemyTakingTurn () {
		return enemiesTakingTurn.FirstOrDefault();;
	}

	public void EnemyDoneWithTurn (Enemy enemy) {
		enemiesTakingTurn.Remove (enemy);
	}

}
