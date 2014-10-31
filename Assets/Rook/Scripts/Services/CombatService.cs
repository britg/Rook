using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatService {

	Player player;
    AgentRegistry agentRegistry;

	public bool InCombat {
		get {
			return player.inCombat;
		}
	}
	List<Agent> agentsInCombat = new List<Agent>();

	public CombatService (Player _player, AgentRegistry _agentRegistry) {
		player = _player;
        agentRegistry = _agentRegistry;
	}

    public void DetectCombat () {
//        foreach (Agent agent in agentRegistry.agents) {
//            bool detectsPlayer = e.Detect(player);
//
//            if (!e.inCombat && detectsPlayer) {
//                EnterCombat((Character)e);
//            }
//
//            if (e.inCombat && !detectsPlayer) {
//                ExitCombat((Character)e);
//            }
//
//            if (e.inCombat && e.dead) {
//                ExitCombat((Character)e);
//            }
//        }
//
//        CheckAnyCombat();
    }

    public void EnterCombat (Agent agent) {
//		if (!charactersInCombat.Contains(character)) {
//			character.inCombat = true;
//			charactersInCombat.Add(character);
//		}
//
//        if (InCombat) {
//            return;
//        }
//
//        Debug.Log("Entering combat!");
//		player.inCombat = true;
    }

	public void ExitCombat (Agent agent) {
//		character.inCombat = false;
//		charactersInCombat.Remove(character);
//        CheckAnyCombat();
	}

    void CheckAnyCombat () {
//		if (player.inCombat && charactersInCombat.Count <= 0) {
//            Debug.Log("Exiting combat");
//			player.inCombat = false;
//            player.ResetActionPoints();
//		}
    }
}
