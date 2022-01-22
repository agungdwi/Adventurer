using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Killed : MonoBehaviour
{
    public static int scoreValue = 0;
    Text kill;
    void Start()
    {
        kill = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        kill.text = "Kill : " + scoreValue;
    }
}
