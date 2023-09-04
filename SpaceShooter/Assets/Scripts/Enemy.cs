using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float vel;
    [SerializeField] protected int health;
    [SerializeField] protected GameObject explosion;
    [SerializeField] protected float bulletSpeed = 5f;
    [SerializeField] protected int points = 10;
    protected float timeBullet = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //If the enemy have no health he will die 
        if (health <= 0)
        {
            Die();
            //Get the game controller script and then increase the points
            var gameController = FindObjectOfType<EnemyGenerator>();
            gameController.DecreaseAmountEnemies();
            gameController.GetPoints(points);

        }
    }

    //If the enemy already passed the screen
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EnemyDestroyer"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            var gameController = FindObjectOfType<EnemyGenerator>();
            gameController.DecreaseAmountEnemies();
        }
    }

    //If the enemy collides with the player
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")) { Die(); }
        other.gameObject.GetComponent<PlayerControl>().TakeDamage(1);

        var gameController = FindObjectOfType<EnemyGenerator>();
        gameController.DecreaseAmountEnemies();
    }

    //Die
    private void Die()
    {
        if(transform.position.y < 5)
        { 
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
