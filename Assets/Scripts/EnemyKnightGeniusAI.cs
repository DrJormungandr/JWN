using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnightGeniusAI : MonoBehaviour
{
    private GameObject player;
    private Animator knightAnim;
    private Vector3 offset;
    public GameObject hurtbox;
    bool looksRight;
    private float distanceFromPlayer;
    public float sightDistance = 8;
    public float attackDistance = 2;
    public float speed = 3;
    private float attackDelay = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        knightAnim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        PlayerSight();
    }

    private void PlayerSight()
    {
        Debug.Log(distanceFromPlayer.ToString());
        Vector3 awayFromPlayer = new Vector3(transform.position.x + player.transform.position.x, transform.position.y);
        if (distanceFromPlayer < sightDistance)
        {
            transform.Translate(awayFromPlayer * Time.deltaTime * 2);
        }
    }

    private void AttackPlayer()
    {
        if (distanceFromPlayer <= attackDistance)
        {
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
            if (Time.time > 1)
            {
                Instantiate(hurtbox, (offset), gameObject.transform.rotation);
            }
            knightAnim.SetTrigger("attackAction");
        }
    }
}


