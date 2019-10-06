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
    private bool LooksRight;
    public GameObject nothingAttackPrefab;
    public GameObject hurtbox;
    public Vector3 offset;
    public int mana = 4 ;
    public int maxMana = 4;
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
        RightClickOfDeath();
        CloseCombat();
    }

   private void playerDirection(float direction)
    {
        
        if (direction < 0)
        {
            playerAnim.SetBool("isRunning", true);
            SetDirection(false);
        }
        else if (direction > 0)
        {
            playerAnim.SetBool("isRunning", true);
            SetDirection(true);
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

    private void RightClickOfDeath()
    {

        //    Camera.main.ScreenToWorldPoint()
        
        if (Input.GetButtonDown("Fire2") && mana >0)
        {
            mana -= 1;
            Instantiate(nothingAttackPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), nothingAttackPrefab.transform.rotation);
        }
    }

    private void CloseCombat()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            offset = new Vector3(2, -0.2F, 0);
            if (LooksRight)
            {
                offset.x *= -1;
            }
            else
            {
                offset.x = Mathf.Abs(offset.x);
            }

            offset = gameObject.transform.position - offset;

            Instantiate(hurtbox, (offset), gameObject.transform.rotation);
            playerAnim.SetTrigger("attackAction");

           // playerAnim.SetTrigger("");
        }
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void SetDirection(bool right)
    {
        if (right)
        {
            playerSprite.flipX = true;
            LooksRight = true;
        }
        else
        {
            playerSprite.flipX = false;
            LooksRight = false;
        }
    }
}
