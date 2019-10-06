using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;
    private Rigidbody2D otherRb;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            otherRb.AddForce(new Vector2(20, 25), ForceMode2D.Impulse);
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.health -= damage;

        }
    }
}
