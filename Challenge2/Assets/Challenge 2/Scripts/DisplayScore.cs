using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour
{
    public Text textbox;

    public int score = 0;
    public bool won;
    // Start is called before the first frame update

    private HealthSystem healthSystemScript;
    void Start()
    {
        won = false;
        textbox = GetComponent<Text>();

        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;

        if(score > 1)
        {
           
            textbox.text = "You WIN!\nPress R to Restart!";
            won = true;
            healthSystemScript.gameOver = true;

        }
    }
}