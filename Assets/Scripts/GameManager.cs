using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int nextSceneIndex = 1; //increases scene index to go to the next scene
    private int sceneCount;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Init();
        }

        DontDestroyOnLoad(this);
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    void Init()
    {
        SceneManager.LoadScene(1); //loading scene 1 by index
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnNextClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }

    public void OnBackClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene > 0)
        {
            SceneManager.LoadScene(currentScene - 1);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
