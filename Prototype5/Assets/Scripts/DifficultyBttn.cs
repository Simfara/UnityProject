/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype5
 * This script controls the difficulty of the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyBttn : MonoBehaviour
{

    private Button button;
    public int difficulty;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
