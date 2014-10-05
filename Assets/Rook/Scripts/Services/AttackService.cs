using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackService {

	AttackAction action;
	List<IReceiveAction> targets;

	public AttackService (AttackAction _action, List<IReceiveAction> _targets) {
		action = _action;
		targets = _targets;
	}

	public void PerformAttack () {
		int amount = action.damageRange.rand;
		foreach (IReceiveAction target in targets) {
			ProcessAttackOnTarget(target, amount);
		}
	}

	void ProcessAttackOnTarget (IReceiveAction target, int amount) {
		target.TakeDamage(amount);
	}

}
