using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public int numOfHearts = 3;
    public int numOfManas = 4;
    public Image[] hearts;
    public Image[] manaies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numOfHearts = GameObject.Find("Player").GetComponent<PlayerHealth>().health;
        numOfManas = GameObject.Find("Player").GetComponent<PlayerController>().mana;
        Debug.Log(numOfHearts.ToString());
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
        for (int i = 0; i < manaies.Length; i++)
        {
            if (i < numOfManas)
            {
                manaies[i].enabled = true;
            }
            else
            {
                manaies[i].enabled = false;
            }
        }
    }
}
