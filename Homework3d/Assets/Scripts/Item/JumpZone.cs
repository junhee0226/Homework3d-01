using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    [SerializeField] float jumpForce = 400f, speed = 5f, jumpZoneForce = 2f;
    int jumpCount = 1;
    float moveX;

    bool isJumpZone = false;
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "JumpZone")
        {
            isJumpZone = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (isJumpZone)
        {
            rb.AddForce(new Vector2(0, jumpZoneForce) * jumpForce);
            isJumpZone = false;
        }
        moveX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }
}
