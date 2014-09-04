using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActionPointsView : View {

    Text text;

    void Start () {
        text = GetComponent<Text>();
    }

    void Update () {
        text.text = "Action Points: " + player.actionPoints;
    }

  
}
