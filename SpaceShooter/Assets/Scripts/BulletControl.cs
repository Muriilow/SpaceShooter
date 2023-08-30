using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private GameObject impactBullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Only work if the bullet collide with the enemy
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(1);
        }
        //Only work if the bullet collide with the player
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControl>().TakeDamage(1);
        }

       Instantiate(impactBullet, transform.position, transform.rotation);
       Destroy(gameObject);
    }
}
