using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private float vel = 3f;
    [SerializeField] private GameObject enemyBullet;
    private float timeBullet = 1f;
    
    void Start()
    {
        myRB.velocity = new Vector2 (0, -1) * vel;
    }

    // Update is called once per frame
    void Update()
    {

        if(timeBullet <= 0)
        {
            //Instantiate Bullet
            Instantiate(enemyBullet, transform.position, transform.rotation);
            timeBullet = Random.Range(1f, 1.5f); ;
        }
        else 
        {
            timeBullet -= Time.deltaTime;
        }
    }

    void Shoot()
    { 
        
    }
}
