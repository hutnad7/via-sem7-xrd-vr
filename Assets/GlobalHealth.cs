using UnityEngine;

public class GlobalHealth : MonoBehaviour
{
    public static int PlayerHealth = 100;
    public int LocalHealth = 100;

    public void TakeDamage()
    {
        LocalHealth -= 20;
        PlayerHealth = LocalHealth;
    }
}
