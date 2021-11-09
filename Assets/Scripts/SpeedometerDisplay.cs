using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerDisplay : MonoBehaviour {

    private int speed;

   public void updateSpeed(float s)
    {
        GetComponent<Text>().text = "SPEED: " + (int) s;
    }


}
