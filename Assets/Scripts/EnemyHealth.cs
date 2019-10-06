﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private PlayerController PlayerStats;
    public int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            if (PlayerStats.mana < PlayerStats.maxMana)
            {
                PlayerStats.mana += 2;
            }
                Destroy(gameObject);
        }
    }
    
}
