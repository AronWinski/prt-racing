using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerDisplay : MonoBehaviour {

    private int speed;
    public Text speedText;

    // Update is called once per frame
    public void updateSpeed(float s) {

        speedText.text = "SPEED: " + (int) s;
        
    }


}
