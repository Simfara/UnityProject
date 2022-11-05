using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public static int score = 0;
    public int score;
    //variable to keep track of what level we are on
    private string CurrentLevelName = string.Empty;

    #region This code makes this class a Singelton
    public static GameManager instance;

    private void Awake()
    {
        if (instance ==null)
        {
            instance = this;
            //make sure this game manager persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Trying to instantiate a second" +
                 "instance of singleton Game Manager");
        }
    }
    #endregion

    //methods to load an unload scene
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level" + levelName);
            return;
        }

        CurrentLevelName = levelName;

    }
    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + levelName);
            return;

        }
    }

}
