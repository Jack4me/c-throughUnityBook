using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehavior : MonoBehaviour
{
    public GameBehavior gameBehavior;
    private void Start()
    {
         gameBehavior = GameObject.Find("MainGameManager").GetComponent<GameBehavior>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(transform.parent.gameObject);
            Debug.Log("Item Collected");

            gameBehavior.Items += 1;
            gameBehavior.PrintLootReport();
        }
    }
}
