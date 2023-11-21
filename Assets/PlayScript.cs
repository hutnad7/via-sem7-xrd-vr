using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{
    public static bool isPlaying = false;
    public void OnPlayClicked()
    {
        isPlaying = true;
    }
}
