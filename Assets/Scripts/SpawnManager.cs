using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    public GameObject pipePrefab;
    float randomHeight = 0.5f;
    
    // Creating a variable to store the PlayerController script
    BirdController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPipes", 2.5f, 2.5f);
        // Find the player controller script when the game Starts
        playerControllerScript = GameObject.Find("Bird").GetComponent<BirdController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if isAlive variable from PlayerCotnroller is false
        if(playerControllerScript.isAlive == false)
        {
            //Stop Spawning in new pipes
            CancelInvoke();
        }
    }

    void SpawnPipes()
    {
        Instantiate(pipePrefab, new Vector2(386, Random.Range(-899, -895)), Quaternion.identity);
    }

}
