using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonkGeniusAI : MonoBehaviour
{
    GameObject player;
    public float speed = 3;
    public float sightDistance = 8;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerSight();
    }

    private void playerSight()
    {
        float distanceFromPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        Debug.Log(distanceFromPlayer.ToString());
        Vector3 awayFromPlayer = new Vector3(transform.position.x - player.transform.position.x, 0);

        if (distanceFromPlayer < sightDistance)

        {
            transform.Translate(awayFromPlayer * Time.deltaTime * speed);
        }


    }
}
