using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Variables
    Rigidbody2D bird;

    // Start is called before the first frame update
    void Start()
    {
        // Setting Rigidbody2D varable equal to Rigidbody2D component
        bird = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Programing a key to control the bird
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Apply force upwards when key is pressed
            bird.AddForce(new Vector2(0,1) * 200);
        }
    }
}
