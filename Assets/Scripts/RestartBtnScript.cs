using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameScript : MonoBehaviour
{
    public void RestartGame()
    {
        StalkerAI.KillCount = 0;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
