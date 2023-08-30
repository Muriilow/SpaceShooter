using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private float vel = 3f;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject explosion;
    private int health = 1;
    private float timeBullet = 1f;
    
    void Start()
    {
        myRB.velocity = new Vector2 (0, -1) * vel;
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if my sprite renderer is visible 
        //Getting information from my children 
        bool isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;
        if(isVisible)
        {
            Shoot();
        }


    }

    //Method to receive the quantity of damage the enemy needs to take
    public void TakeDamage(int damage)
    {
        health -= damage;
        //If the enemy have no health he will die 
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void Shoot()
    {
        if (timeBullet <= 0)
        {
            //Instantiate Bullet
            Instantiate(enemyBullet, bulletPosition.position, transform.rotation);
            timeBullet = Random.Range(1f, 1.5f);
        }
        else
        {
            timeBullet -= Time.deltaTime;
        }
    }
}
