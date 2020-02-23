using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject turretobj;

    public Vector2 tileOrigianlPos;
    // Start is called before the first frame update
    void Start()
    {
        tileOrigianlPos = new Vector2(this.transform.position.x, this.transform.position.y);
        //Debug.Log(tileOrigianlPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        GameObject newturret = Instantiate(turretobj,tileOrigianlPos,Quaternion.identity);
        newturret.transform.parent = gameObject.transform;
    }
}
