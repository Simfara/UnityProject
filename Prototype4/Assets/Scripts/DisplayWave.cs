using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayWave : MonoBehaviour
{
    public Text textbox;

    public int score = 0;
    private bool gameOver = false;

    public SpawnManager spawnManager;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        //get a refernce to tht SapwnManager script
       spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
     
        textbox.text = "Wave: 0";

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Wave: " + spawnManager.waveNumber;

        //Win Condition
        if (spawnManager.waveNumber == 10)
        {
            gameOver = true;
            textbox.text = "You Win. Press R to Play Again! ";
        }

        //Lose Condition
        if (player.transform.position.y < -10)
        {
            gameOver = true;
            textbox.text = "You Lose. Press R to Restart! ";
        }


        if (gameOver)
        {
            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }

    }
}
