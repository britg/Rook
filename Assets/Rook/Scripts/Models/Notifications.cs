using UnityEngine;
using System.Collections;

public static class Notifications {

	public static string PlayerTurn { get { return "OnPlayerTurn"; } }
	public static string EnemyTurn { get { return "OnEnemyTurn"; } }

    public static string PlayerEnteringCombat { get { return "OnPlayerEnteringCombat";  } }

    public static string ChangeMade { get { return "OnChangeMade"; } }
	public static string ActionFinished { get { return "OnActionFinished"; } }

	public static string EnterControlMode { get { return "OnEnterControlMode"; } }

}
