using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class LearningCurve : MonoBehaviour
{
    private Transform camTransform;
    public GameObject directionLight;
    private Transform _transformLight;
    private void Start()
    {
        //directionLight = GameObject.Find("Directional Light");
        //_transformLight = directionLight.GetComponent<Transform>();
        Debug.Log(GameObject.Find("Directional Light").GetComponent<Transform>().localPosition);

        

        camTransform = GetComponent<Transform>();
        Debug.LogFormat("This is {0}", camTransform.localPosition);

        //Character hero = new Character();
        //hero.PrintStatsInfo();

        //Character heroine = new Character();
        //heroine.PrintStatsInfo();

        //Weapon weapon = new Weapon("Axe", 120);
        //weapon.PrintStatsInfo();

        //Weapon huntingBow = new Weapon("Huntong Bow", 105);
        //Weapon warBow = huntingBow;
        //warBow.name = "WarBow JORJIK";
        //warBow.damage = 155;

        //huntingBow.PrintStatsInfo();
        //warBow.PrintStatsInfo();

        //Paladin knite = new Paladin("Holly Pal", warBow);
        //knite.PrintStatsInfo();


    }
}
