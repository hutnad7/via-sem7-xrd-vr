using UnityEngine;
using UnityEngine.UI;   // Required when Using UI elements.

public class GlobalHealth : MonoBehaviour
{
    public static int PlayerHealth = 100;
    public int LocalHealth = 100;

    void Update()
    {
        PlayerHealth = LocalHealth;
    }

    public void TakeDamage()
    {
        LocalHealth -= 20;
    }
}
