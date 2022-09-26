/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype3 
 * This script manages the TEXT UI of the game,
 * It displays the score, shows game over, you won text and the option to replay the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;

    public PlayerControllerX playerControllerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {

        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //Display score until game is over
        if (!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score;

        }

        //loss condition
        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = " You Lose!\nPress R to try again!";
        }

        //win condition
        if (score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;
            scoreText.text = "You Win!\nPress R to play again";
        }

        //Press R to restart if game over
        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
