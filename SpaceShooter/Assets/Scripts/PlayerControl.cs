using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D myRb;
    [SerializeField] private float vel = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform playerBulletPosition;
    [SerializeField] private GameObject explosion;
    [SerializeField] private float bulletSpeed = 7f;
    [SerializeField] private float xLimit;
    [SerializeField] private float yLimit;
    private float vertical;
    private float horizontal;
    [SerializeField] private int health = 5;


    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Shoot();
        Fly();

    }

    private void Fly()
    {
        Vector2 myVel = new Vector2(horizontal, vertical).normalized * vel;
        myRb.velocity = myVel;

        //limiting his position on the screen
        float myX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float myY = Mathf.Clamp(transform.position.y, -yLimit, yLimit);

        //My position
        transform.position = new Vector3(myX, myY, transform.position.z);
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject myBullet = Instantiate(bullet, playerBulletPosition.position, transform.rotation);
            //Give the direction and speed to the RB of the bullet 
            myBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("AAAAAAAAAA QUE DOR!!" + health);
        
        //If I have no health I will die 
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
