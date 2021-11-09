using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerDisplay : MonoBehaviour {

    private int speed;
<<<<<<< Updated upstream

   public void updateSpeed(float s)
    {
        GetComponent<Text>().text = "SPEED: " + (int) s;
=======
    public Text speedText;

    // Update is called once per frame
    public void updateSpeed(float s) {

        GetComponent<Text>().text = "SPEED: " + (int) s;
        
>>>>>>> Stashed changes
    }


}
