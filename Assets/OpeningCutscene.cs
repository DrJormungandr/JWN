using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpeningCutscene : MonoBehaviour {
    public bool isLoad = false;

    private void Start()
    {

        Invoke("Go", 20);
    }

    void Go()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
   
    if(isLoad == true)
    {
        SceneManager.LoadScene(1);
    }
                
    }
}
