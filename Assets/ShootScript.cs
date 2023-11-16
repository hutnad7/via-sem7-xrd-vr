using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnpoint;

    public void Shoot()
    {
        bullet.SetActive(true);
        Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
    }
}
