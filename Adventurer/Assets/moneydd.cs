using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneydd : MonoBehaviour

{
    Text point;
    public static int pointvalue;

    void Start()
    {
        point = GetComponent<Text> ();
        pointvalue= 0;
    }

    void Update(){
        point.text = "Points : " + pointvalue;
    }

    public void setpoint (int points){
        pointvalue += points;
    }

}
