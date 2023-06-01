using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D meuRb;
    [SerializeField] private float vel = 5f;
    // Start is called before the first frame update
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 myVel = new Vector2(horizontal, vertical) * vel;

        meuRb.velocity = myVel;
    }
}
