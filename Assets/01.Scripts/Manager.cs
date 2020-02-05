using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TileSize);
        CreateTile();
    }

    public float TileSize
    {
        get{ return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateTile()
    {
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2));
        Debug.Log(worldStart);

        float tileSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                PlaceTile(x,y, worldStart);             
            }
            
        }
      
    }

    private void PlaceTile(int x, int y, Vector3 worldStart)
    {
        GameObject newTile = Instantiate(tile);
         newTile.transform.position = new Vector3(worldStart.x + TileSize * x - TileSize*2, worldStart.y - TileSize * y + TileSize*6 ,0);
    }
}
