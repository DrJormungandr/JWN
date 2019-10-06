using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            
            Application.LoadLevel(Application.loadedLevel);
        }

        if (winGame)
        {
         SceneManager.LoadScene(2);
        }
    }
}
