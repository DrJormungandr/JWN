using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpeningCutscene : MonoBehaviour {
    public bool isLoad = false;


    void Update()
    {
   
    if(isLoad == true)
    {
        SceneManager.LoadScene(1);
    }
                
    }
}
