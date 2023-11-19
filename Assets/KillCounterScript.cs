using UnityEngine;
using UnityEngine.UI;

public class KillCounterScript : MonoBehaviour
{
    public GameObject KillCounter;
    void Update()
    {
        KillCounter.GetComponent<Text>().text = "Kills: " + StalkerAI.KillCount;
    }
}
