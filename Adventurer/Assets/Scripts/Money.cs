using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
    public GameObject Shop;
    public GameObject GameOver;
    public static int MoneyValue;
    public Text Points;

    void Start()
    {
       Points = GetComponent<Text>();
       MoneyValue= 0;
    }

    void update(){
        
    }


    public void HealthButton (){
        if (MoneyValue >= 5){
            AudioManagerScript.PlaySound("ShopButton");
            MoneyValue -= 5;
            moneydd.pointvalue -= 5;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealthUp();
        }
    }

    public void AttackDamageButton (){
        if (MoneyValue >= 5){
            AudioManagerScript.PlaySound("ShopButton");
            MoneyValue -= 5;
            moneydd.pointvalue -= 5;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().AttackDamageUp();
        }
    }

    public void AttackRateButton(){
        if (MoneyValue >= 5){
            AudioManagerScript.PlaySound("ShopButton");
            MoneyValue -= 5;
            moneydd.pointvalue -= 5;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().AttackRateUp();
        }
    }

    public void BackButton(){
        AudioManagerScript.PlaySound("Button");
        Shop.SetActive(false);
        GameOver.SetActive(true);
    }


}
