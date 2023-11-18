using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bulletCube;
    public GameObject bullet;
    public Transform spawnpoint;
    public AudioSource fire;
    public GameObject flash;

    [SerializeField] private float bulletSpeed = 10f;

    public void Shoot()
    {
        fire.Play();
        flash.SetActive(true);
       bullet.SetActive(true);
       GameObject spawnBullet = Instantiate(bulletCube, spawnpoint.position, spawnpoint.rotation);
       spawnBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * bulletSpeed;
       Destroy(spawnBullet, 1.5f);
        flash.SetActive(false);
    }
}
