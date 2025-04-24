using UnityEngine;
using UnityEngine.SceneManagement;

public class S_DoorManager : MonoBehaviour
{
    public S_FinalDoor[] portas;

    void Update()
    {
        foreach (var porta in portas)
        {
            if (!porta.JogadorNaPorta) return;
        }
        //SceneManager.LoadScene("TelaDeVitoria");
        Object.FindFirstObjectByType<S_GameUIManager>().ShowWinScreen();
    }
}