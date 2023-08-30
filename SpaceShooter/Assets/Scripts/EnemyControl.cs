using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : Enemy
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform bulletPosition;
    
    void Start()
    {
        myRB.velocity = new Vector2 (0, -1) * vel;
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if my sprite renderer is visible 
        //Getting information from my children 
        Shoot();

    }

    private void Shoot()
    {
        bool isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;
        if (isVisible)
        {
            if (timeBullet <= 0)
            {
                //Instantiate Bullet
                GameObject myBullet = Instantiate(enemyBullet, bulletPosition.position, transform.rotation);
                myBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -bulletSpeed);
                timeBullet = Random.Range(1f, 1.5f);
            }
            else
            {
                timeBullet -= Time.deltaTime;
            }
        }
    }
}
