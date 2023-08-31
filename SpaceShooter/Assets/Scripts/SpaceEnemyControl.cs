using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpaceEnemyControl : Enemy
{
    [SerializeField] private GameObject myBullet;
    [SerializeField] private Rigidbody2D myRB;
    private bool canMove = false;
 
    void Start()
    {
        myRB.velocity = Vector2.up * vel;   
    }

    // Update is called once per frame
    void Update()
    {
       if(myRB.position.y < 2.5)
        {
            if(myRB.position.x >= 0 && !canMove)
            {
                //Im on the right
                myRB.velocity = new Vector2(1, 1) * vel;
                canMove = true;
            }
            else if(myRB.position.x < 0 && !canMove)
            {
                //Im on the left
                myRB.velocity = new Vector2(-1, 1) * vel;
                canMove = true;
            }
        }
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
                GameObject bullet = Instantiate(myBullet, transform.position, transform.rotation);
                timeBullet = Random.Range(2f, 4f);
                var player = GameObject.FindGameObjectWithTag("Player");
                Vector2 direction = player.transform.position - bullet.transform.position;
                //Normalize speed
                direction.Normalize();
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                //The angle of the shot 
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //Giving the angle 
                bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90);
            }
            else
            {
                timeBullet -= Time.deltaTime;
            }
        }
    }
}
