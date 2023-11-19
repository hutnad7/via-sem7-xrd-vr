using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public void OnExitClicked()
    {
        PlayScript.isPlaying = false;
    }
}
