using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameUIManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        int indexAtual = SceneManager.GetActiveScene().buildIndex;
        int total = SceneManager.sceneCountInBuildSettings;

        if (indexAtual + 1 < total)
            SceneManager.LoadScene(indexAtual + 1);
        else
            SceneManager.LoadScene("TelaSelecaoFase");

        Time.timeScale = 1f;
    }
}