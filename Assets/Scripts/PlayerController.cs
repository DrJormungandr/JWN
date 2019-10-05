using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isOnGround = true;
    public float speed = 20;
    public float jumpForce = 3;
    private float horizontalInput;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput);
        playerDirection(horizontalInput);
        jump();
        
    }

   private void playerDirection(float direction)
    {
        
        if (direction < 0)
        {
            playerAnim.SetBool("isRunning", true);
            playerSprite.flipX = false;
        }
        else if (direction > 0)
        {
            playerAnim.SetBool("isRunning", true);
            playerSprite.flipX = true;
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
    } 

    private void jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("jumpAction");
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
