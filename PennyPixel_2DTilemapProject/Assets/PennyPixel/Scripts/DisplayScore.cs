using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour
{

    public static bool gameOver;
    public static bool won;
    //private bool triggered = false;
    public int score;

    public Text textbox;

    private GemBehaviour gemBehaviourScript;
    private TriggerZone triggerZoneScript;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {//If the game is not over, display score
        score = gemBehaviourScript.gemScore;
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        //Win condition: Reach the end
        if(triggerZoneScript.triggered)
        {
            won = true;
            gameOver = true;
        }

        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You Win!\nPress R to Play Again!";
            }
            else
            {
                textbox.text = "You Lose!\nPress R to Try Again! ";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }

        }

    }
}
