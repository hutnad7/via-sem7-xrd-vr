using UnityEngine;
using UnityEngine.UI;

public class KillCounterScript : MonoBehaviour
{
    public GameObject KillCounter;
    public GameObject winText;
    public GameObject restartButton;

    void Update()
    {
        KillCounter.GetComponent<Text>().text = "TOTAL KILLS: " + StalkerAI.KillCount;

      
        if (StalkerAI.KillCount >= 5)
        {
         
            winText.SetActive(true);

            restartButton.SetActive(true);

            KillCounter.SetActive(true);
        }
    }
}