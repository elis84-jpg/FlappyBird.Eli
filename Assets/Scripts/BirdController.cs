using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    //Variables
    Rigidbody2D bird;
    int score = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI gameOverText;

    AudioSource audioSource;
    //Variables for AudioClips in the game
    public AudioClip flySound;
    public AudioClip hitSound;
    public AudioClip dieSound;
    public AudioClip pointSound;

    // True Or False value to check if bird is alive or not
    public bool isAlive;

    //Check when the player collides with something in the scene
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Set isAlive variable to false whena collision happens withthe player
        isAlive = false;

        //Play hit and die sound when collision happens in the game
        audioSource.PlayOneShot(hitSound);
        audioSource.PlayOneShot(dieSound);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setting Rigidbody2D varable equal to Rigidbody2D component
        bird = GetComponent<Rigidbody2D>();

        // Set the alive to true
        isAlive = true;

        //Initializing the AudioSource variable whenthe game starts
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Programing a key to control the bird
        if(Input.GetKeyDown(KeyCode.Space) && isAlive == true)
        {
            // Apply force upwards when key is pressed
            bird.AddForce(new Vector2(0,1) * 200);

        }

        if(isAlive == false)
        {
            GameOver();
        }
        audioSource.PlayOneShot(flySound);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Points"))
        {
            // Increase score by 1
            score = score + 1;

            scoreUI.text = score.ToString();

            audioSource.PlayOneShot(pointSound);
        }
        // Play the point sound when score goes up
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
