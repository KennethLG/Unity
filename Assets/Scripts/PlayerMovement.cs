using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRb;
    public float speed = 0.5f;
    public float jumpSpeed = 100f;
    [SerializeField] bool isGrounded = false;
    public Animator playerAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        playerAnimator.SetBool("isWalking", sign(Input.GetAxis("Horizontal")) != 0);
        if (playerRb.velocity.x < 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (playerRb.velocity.x > 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            playerRb.AddForce(Vector2.up * jumpSpeed);
            isGrounded = false;
        }
        playerAnimator.SetBool("onGround", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    private float sign(float val) {
        if (val > 0) val = 1;
        if (val < 0) val = -1;
        if (val == 0) val = 0;
        return val;
    }
}
