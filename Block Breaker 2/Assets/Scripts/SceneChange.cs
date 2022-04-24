using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public void LoadNextScene()
    {
        int nextSceneBuildIndex = (SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void StartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().scoreReset();
    }
}
