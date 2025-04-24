using UnityEngine;
using UnityEngine.SceneManagement;

public class S_LevelSelect : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }
}