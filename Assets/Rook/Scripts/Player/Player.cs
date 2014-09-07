﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player {

    public PlayerControlMode controlMode;

    public int maxLife = 100;
    public int life = 100;

    public int maxActionPoints = 10;
    public int actionPoints = 10;

}