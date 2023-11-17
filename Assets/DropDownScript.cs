using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DropDownScript : MonoBehaviour
{
   [SerializeField] private ActionBasedSnapTurnProvider snapTurn;
   
   [SerializeField] private ActionBasedContinuousTurnProvider continousTurn;

public void TurnProviderSelect(int index)
{
    if (index == 0)
    {
        snapTurn.enabled = true;
        continousTurn.enabled = false;
    }
    if (index == 1)
    {
        snapTurn.enabled = false;
        continousTurn.enabled = true;
    }
}

}
