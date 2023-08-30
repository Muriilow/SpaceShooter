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
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
