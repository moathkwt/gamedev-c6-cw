using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float playerRange = 5f;
    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody rbEnemy;

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (Vector3.Distance(transform.position, cam.transform.position) < playerRange)
        {
            Vector3 playerDirection = cam.transform.position - transform.position;

            rbEnemy.velocity = playerDirection.normalized * moveSpeed;
        }

        if (shouldShoot)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = fireRate;
            }
        }
        else
            rbEnemy.velocity = Vector2.zero;
    }
}

    // Update is called once per frame
    
