using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    public float cameraZoom = 100;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        offset = new Vector3(0, -2, cameraZoom);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = (Player.transform.position - offset);
        }

    }
}
