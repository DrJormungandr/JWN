using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private PlayerController PlayerStats;
    public int health = 2;
    private Animator enemyAnim;
    float delay = 0.5F;
    bool isDead = false;
    AudioSource enemyPlayAudio;
    AudioClip deathSound;
    AudioClip maslinuPoymal;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyAnim = gameObject.GetComponent<Animator>();
        enemyPlayAudio = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1 & !isDead)
        {
            delay = Time.time + 1;
            isDead = true;
            enemyAnim.SetTrigger("death");
           
            if (PlayerStats.mana < PlayerStats.maxMana)
            {
                PlayerStats.mana += 2;
            }
            enemyPlayAudio.PlayOneShot(deathSound);
        }
        if ((Time.time > delay) & isDead)
        {
            Destroy(gameObject);
        }
    }
    
}
