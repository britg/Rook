using UnityEngine;
using System.Collections;
using Vectrosity;

public class PlayerLifeView : View {

    public Color lifeColor;
    public float lifeBarThickness;
    public float lifeBarMultiplier;
    public Vector2 lifeBarStart;

    VectorLine lifeBar;
    Vector2 lifeBarEnd;

    int currentHitPoints {
        get {
            return player.hitPoints.currentValue;
        }
    }

	int maxHitPoints {
		get {
			return player.hitPoints.maxValue;
		}
	}

    void Start () {
        CreateLine();
    }

    void Update () {
        DisplayLife();
    }

    void CreateLine () {
        lifeBarStart.y = Screen.height - lifeBarStart.y;
        lifeBarEnd = new Vector3(lifeBarStart.x + (maxHitPoints * lifeBarMultiplier), lifeBarStart.y);
        Vector2[] barPoints = new Vector2[2] { lifeBarStart, lifeBarEnd };
        lifeBar = VectorLine.SetLine(lifeColor, barPoints);
        lifeBar.SetWidth(lifeBarThickness, 0);
    }

    void DisplayLife () {
        lifeBarEnd = new Vector3(lifeBarStart.x + (currentHitPoints * lifeBarMultiplier), lifeBarStart.y);
        lifeBar.points2 = new Vector2[2] { lifeBarStart, lifeBarEnd };
        lifeBar.Draw();
    }

}
