using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PLayGame (){
        AudioManagerScript.PlaySound("Button");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame (){
        AudioManagerScript.PlaySound("Button");
        Application.Quit();
    }

    public void Control (){
        AudioManagerScript.PlaySound("Button");
        SceneManager.LoadScene("Control");
    }

    public void BackToMenu (){
        AudioManagerScript.PlaySound("Button");
        SceneManager.LoadScene("Main Menu");
    }
}
