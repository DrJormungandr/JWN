﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameOver = false;
    public bool winGame = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            gameOver = true;
        }
        if (GameObject.Find("Altar") == null)
        {
            winGame = true;   
        }
        if (gameOver)
        {
            //INSERT HERE
        }

        if (winGame)
        {
            //INSERT HERE
        }
    }
}