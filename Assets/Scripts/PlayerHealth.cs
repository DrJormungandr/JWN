
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health = 3 ;
    PlayerController playerController;


    // Start is called before the first frame update
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        playerController.isDead = true;
            if (health < 1)
            {
                
            Destroy(gameObject);
            }


    }
}
