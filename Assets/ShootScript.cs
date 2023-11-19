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

        if (Physics.Raycast(spawnpoint.position, spawnpoint.forward, out RaycastHit hit))
        {
            // Check if the hit object has a "PistolShot" method
            hit.transform.SendMessage("Shot", SendMessageOptions.DontRequireReceiver);
        }

        GameObject spawnBullet = Instantiate(bulletCube, spawnpoint.position, spawnpoint.rotation);
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * bulletSpeed;
        Destroy(spawnBullet, 1.5f);

        flash.SetActive(false);
    }
}
