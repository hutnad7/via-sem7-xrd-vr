using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletCube;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private float bulletSpeed = 10f;

    public void Shoot()
    {
        bullet.SetActive(true);
       GameObject spawnBullet = Instantiate(bulletCube, spawnpoint.position, spawnpoint.rotation);
       spawnBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * bulletSpeed;
       Destroy(spawnBullet, 1.5f);
    }
}
