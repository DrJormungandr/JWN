using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private PlayerController PlayerStats;
    public int health = 2;
    private Animator enemyAnim;
    float delay = 0.5F;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyAnim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            delay = Time.time + 2;
            enemyAnim.SetTrigger("death");
           
            if (PlayerStats.mana < PlayerStats.maxMana)
            {
                PlayerStats.mana += 2;
            }
            gameObject.SetActive(false);
            if (Time.time > delay)
            {
                Destroy(gameObject);
            }
        }
    }
    
}
