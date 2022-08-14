//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class Character : LearningCurve 
//{
//    public string name;
//    public int exp = 0;
    
//    public Character()
//    {
//        name = "Not Assigned";
//        exp = 1;
//    }
//    public Character(string name, int exp)
//    {
//        this.name = name;
//        this.exp = exp;
       

//    }
//    public Character(string name)
//    {
//        this.name = name;
       
//    }
//    public virtual void PrintStatsInfo()
//    {
//        Debug.LogFormat("Hero: {0}, Exp: {1}", name, exp);
//    }
//    private void Reset()
//    {
//        this.name = "Not Assigned";
//        this.exp = 0;
//    }

//}
//public struct Weapon
//{
//    public string name;
//    public int damage;
//    public Weapon(string name, int damage)
//    {
//        this.name = name;
//        this.damage = damage;
//    }
//        public void PrintStatsInfo()
//    {
//        Debug.LogFormat("Weapon: {0} - {1} DMG: ", name, damage);
//    }

//}