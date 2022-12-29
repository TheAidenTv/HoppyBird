using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
public class PipeGenerator : MonoBehaviour
{
    // Prefab for the pipe game object
    public GameObject pipePrefab;

    // Interval at which to generate new pipes (in seconds)
    public float pipeInterval = 2f;

    // Speed at which to move the pipes (in units per second)
    public float pipeSpeed = 3f;

    // Minimum and maximum vertical positions at which pipes can be spawned
    public float minY = -6f;
    public float maxY = 6f;

    // Size of the gap between the top and bottom pipes
    public float gapSize = 1f;

    // Timer to track the elapsed time since the last pipe was generated
    public float timer = 2f;

    public bool gameOver = false;

    public Text score;
    public Text storedScore;

    public int count = 0;

    public GameObject gameOverPopup;

    public AudioSource pipeMade;

    int highScore;
    public Text highScoreText;

    void Update()
    {
        if (!gameOver)
        {
            gameOverPopup.SetActive(false);
            // Update the timer
            timer += Time.deltaTime;

            // Check if it's time to generate a new pipe
            if (timer >= pipeInterval)
            {
                // Reset the timer
                timer = 0f;

                // Generate a random vertical position for the pipes
                float y = Random.Range(minY, maxY);

                // Create the top and bottom pipes
                GameObject pipe = Instantiate(pipePrefab);
                pipe.transform.position = new Vector3(10, y, 0);
            }

            // Move all pipes from right to left
            foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("MultiPipe"))
            {
                pipe.transform.position += Vector3.left * Time.deltaTime * pipeSpeed;

                // Check if the pipe's x position is less than or equal to -10
                if (pipe.transform.position.x <= -6f)
                {
                    // Destroy the pipe
                    Destroy(pipe);
                }
            }
        }
        else
        {
            gameOverPopup.SetActive(true);
            score.text = "";
            highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        }
     
    }

    public void setGameOver()
    {
        gameOver = true;
    }
    //
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            count++;
            highScore = count;

            score.text = count.ToString();
            storedScore.text = count.ToString();

            pipeMade.Play();

            if(PlayerPrefs.GetInt("highScore") <= highScore)
            {
                PlayerPrefs.SetInt("highScore", highScore);
                PlayerPrefs.Save();
            }
        }
    }
}
