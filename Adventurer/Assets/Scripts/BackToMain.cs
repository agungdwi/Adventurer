using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMain : MonoBehaviour
{
    public GameObject Shop;
    public GameObject GameOver;

    public void Back(){
        AudioManagerScript.PlaySound("Button");
        SceneManager.LoadScene("Main Menu");
        Killed.scoreValue = 0;
    }

    public void Restart(){
        AudioManagerScript.PlaySound("Button");
        SceneManager.LoadScene("Game");
        Killed.scoreValue = 0;
    }

    public void GoToShop(){
        AudioManagerScript.PlaySound("Button");
        Shop.SetActive(true);
        GameOver.SetActive(false);
    }
    public void Back2(){
        AudioManagerScript.PlaySound("Button");
        SceneManager.LoadScene("Main Menu");
    }
}
