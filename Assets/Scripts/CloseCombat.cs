﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombat : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
    }
}