
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health = 3 ;


    // Start is called before the first frame update


    void Update()
    {
        
            if (health < 1)
            {
                Destroy(gameObject);
            }


    }
}
