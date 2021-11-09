using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerDisplay : MonoBehaviour {

    private int speed = 100;
    public Text speedText;

    // Update is called once per frame
    void Update() {

        speedText.text = "SPEED: " + speed;
            speed--;
        
    }
}
