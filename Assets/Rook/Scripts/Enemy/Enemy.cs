using UnityEngine;
using System.Collections;

[System.Serializable]
public class Enemy {

    [SerializeField]
    int actionPoints;

    [SerializeField]
    int maxActionPoints;

    [SerializeField]
    int detectRange;


    public int ActionPoints {
        get {
            return actionPoints;
        }
    }

    public int MaxActionPoints {
        get {
            return maxActionPoints;
        }
    }

    public int DetectRange {
        get {
            return detectRange;
        }
    }

}
