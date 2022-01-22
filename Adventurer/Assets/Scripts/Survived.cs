using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Survived : MonoBehaviour
{

     public Text timer;
     
    public void SetTime (int min, int sec, int msec){

        timer.text = string.Format("{0:00}:{1:00}:{2:00}",min,sec,msec);
    }

     public void SetKill (int kill){
         
     }
}
