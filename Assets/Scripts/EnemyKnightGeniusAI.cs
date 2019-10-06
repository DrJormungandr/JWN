using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnightGeniusAI : MonoBehaviour
{
    private GameObject player;
    private Animator knightAnim;
    private SpriteRenderer knightSprite;
    private Vector3 offset;
    public GameObject hurtbox;
    bool looksRight = true;
    private float distanceFromPlayer;
    public float attackRate = 3;
    public float sightDistance = 8;
    public float attackDistance = 3;
    public float speed = 3;
    public float attackDelay = 0.1F;
    private float nextAttack = 2;
    AudioSource playAudio;
    public AudioClip uvidelShelupon;
    public AudioClip udarilShelupon;
    public AudioClip diedSound;
    public AudioClip maslinuPoymal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        knightAnim = gameObject.GetComponent<Animator>();
        knightSprite = gameObject.GetComponent<SpriteRenderer>();
        playAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        PlayerSight();
        AttackPlayer();
        getDirection();
        Debug.Log(distanceFromPlayer.ToString());
        constraint();
    }

    private void PlayerSight()
    {
        Vector3 toPlayer = new Vector3(player.transform.position.x - transform.position.x, 0);
        if (distanceFromPlayer < sightDistance)
        {
            transform.Translate(toPlayer * Time.deltaTime * 2);
        }
    }
    private void constraint()
    {
        if (gameObject.transform.position.y < -21)
        {
            Destroy(gameObject);
        }
    }
    private void AttackPlayer()
    {
        if (distanceFromPlayer <= attackDistance)
        {
            playAudio.PlayOneShot(udarilShelupon);
            offset = new Vector3(2, -0.2F, 0);
            if (looksRight)
            {
                offset.x *= -1;
            }
            else
            {
                offset.x = Mathf.Abs(offset.x);
            }

            offset = gameObject.transform.position - offset;

            if (Time.time > nextAttack)
            {
                knightAnim.SetTrigger("attackAction");

                StartCoroutine(AttackDelayCoroutine());
                nextAttack = Time.time + attackRate;
            }

        }
    }

    private void getDirection()
    {
        if (player.transform.position.x - transform.position.x > 0)
        {
            looksRight = true;
            knightSprite.flipX = false;


        }
        if (player.transform.position.x - transform.position.x < 0)
        {
            looksRight = false;
            knightSprite.flipX = true;
        }
    }

    IEnumerator AttackDelayCoroutine(){
        yield return new WaitForSeconds(attackDelay);
        Instantiate(hurtbox, (offset), gameObject.transform.rotation);
    }
}


