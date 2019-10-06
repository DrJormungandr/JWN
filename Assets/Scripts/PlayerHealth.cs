
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;

    // Start is called before the first frame update


    void Update()
    {
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
            if (health < 1)
            {
                Destroy(gameObject);
            }
        }

    }
}
