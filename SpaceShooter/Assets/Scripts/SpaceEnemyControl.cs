using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyControl : Enemy
{
    [SerializeField] private GameObject myBullet;

 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                Instantiate(myBullet, transform.position, transform.rotation);
                timeBullet = Random.Range(2f, 4f);
            }
            else
            {
                timeBullet -= Time.deltaTime;
            }
        }
    }
}
