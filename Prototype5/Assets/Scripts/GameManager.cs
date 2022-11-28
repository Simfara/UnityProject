/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype5
 * This script controls the game mechanics such as the gameover case and restart methods. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;
    public void StartGame(int difficulty)
    {

        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
       public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void UpdateScore( int scoreToADD)
    {
        score += scoreToADD;
        scoreText.text = "Score: " + score;
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
            //TEST UPDATE SCORE
            //UpdateScore(5);
        }

       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
