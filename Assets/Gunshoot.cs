using UnityEngine;
using UnityEngine.UIElements;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform firePoint;      // Where the bullet will spawn 
    public float bulletSpeed = 20f;  // Speed of the bullet
    public float fireRate = 1.5f;    // Time in seconds between shots
    private float nextFireTime = 0f; // Used to control fire rate

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            
            if (Input.GetMouseButtonDown(0)) // Left-click to shoot
            { 
                Shoot();
                nextFireTime = Time.time + fireRate; // Set time for next shot
            }
        }
    }

    void Shoot()
    {
        // Bullet fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * bulletSpeed;
        }

        
        Destroy(bullet, 2f); // Destroy after 2 seconds

        
    }
}
