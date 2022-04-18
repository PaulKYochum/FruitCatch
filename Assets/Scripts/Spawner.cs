using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Paul Kent Yochum
// Spawner Script
// 4/16/2022


public class Spawner : MonoBehaviour
{

    public GameObject[] fruits;   
    public GameObject spider;
    public float xBounds, yBounds;

    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());    // Begins IEnumerator coroutine 
    }

    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));

        int randomFruit = Random.Range(0, fruits.Length);    // Allows for larger/smaller ammount of fruits added in

        if(Random.value <= .6f)
        {
            Instantiate(fruits[randomFruit], new Vector2(Random.Range(-xBounds, xBounds), yBounds), Quaternion.identity);    // Spawns fruit
        }
        else 
            Instantiate(spider, new Vector2(Random.Range(-xBounds, xBounds), yBounds), Quaternion.identity);    // Spawns spiders

        StartCoroutine(SpawnRandomGameObject());    // Loops through IEnumerator 
    }
    
    
    
}
