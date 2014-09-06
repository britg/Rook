using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatStatusView : View {

    Text text;

    void Start () {
        text = gameObject.GetComponent<Text>();
    }

    void Update () {
        if (turnController.InCombat) {
            text.text = "In Combat!";
        } else {
            text.text = "Out of Combat";
        }
    }
}
