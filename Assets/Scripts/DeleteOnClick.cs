using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeleteOnClick : MonoBehaviour
{
    public Vector2 initialVelocity = new Vector2(1.0f, 10.0f);
   
    Tilemap tilemap;
    Tilemap NothingTilemap;
    public Tile nothingTile;
    // Start is called before the first frame update
    void Start()
    {
        NothingTilemap = GameObject.Find("NOTHING").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Nothing"))
        {
            if (collision.gameObject.GetComponent<Tilemap>() == null)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Vector3 hitPosition = Vector3.zero;
                tilemap = collision.gameObject.GetComponent<Tilemap>();
                foreach (ContactPoint2D hit in collision.contacts)
                {
                    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                    NothingTilemap.SetTile(tilemap.WorldToCell(hitPosition), nothingTile);
                }
            }
        }
    }
}
