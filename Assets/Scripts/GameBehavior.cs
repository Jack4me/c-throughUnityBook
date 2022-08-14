using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameBehavior : MonoBehaviour, IManager

{


    private string _state;
    public Stack<string> lootStack = new Stack<string>();
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    
     void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        _state = "Manager initilize...";
        
        Debug.Log(State);
        lootStack.Push("Sword");
        lootStack.Push("Bow");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
    }
    private int _playerHP = 2;
    private bool _showWinScreen = false;
    private bool _showLoseScreen = false;
    private int maxItem = 1;

    private int _itemsCollected = 0;
    public string labelTex = "Collect all the items";
    public int HealthBar
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Your Life {0}", value);

            if (_playerHP <= 0)
            {
                labelTex = "You DIE!!!";
                Time.timeScale = 0;
                _showLoseScreen = true;
            }
            else
            {
                labelTex = "Ouch, Thats hurt!!!";

            }
        }
    }
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;


            if (_itemsCollected >= maxItem)
            {

                labelTex = "You have found all the item!!!";
                Time.timeScale = 0;
                _showWinScreen = true;
            }
            else
            {
                labelTex = "Item found, only " + (maxItem - _itemsCollected) + " more to go!";
            }
        }
    }




    void OnGUI()
    {


        GUI.Box(new Rect(20, 20, 150, 25),
        "Player Health : " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25),
            "Items Collected : " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelTex);

        if (_showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
             Screen.height / 2 - 50, 200, 100), "YOU WON!!"))
            {
                Utilities.RestartMetod();
            }
        }
        if (_showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
             Screen.height / 2 - 50, 200, 100), "YOU LOSE"))
            {
                Utilities.RestartMetod();
            }
        }

    }
    public void PrintLootReport()
    {
        Debug.LogFormat("Some items are here {0}", lootStack.Count);
        var nextItem = lootStack.Peek();
        var curentItem = lootStack.Pop();

        Debug.LogFormat("Curent weapon is{0}, but you can hit him {1}", curentItem, nextItem);
    }
}

