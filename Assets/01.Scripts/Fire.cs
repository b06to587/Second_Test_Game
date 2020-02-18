using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Fire : MonoBehaviour
{
    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public string TagName;
    public float shortDis;

    public float speed = 50f;
    private float startTime;
    private float distanceLength;

    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Vector3 currPosition;

    public void Update()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName));
        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position); // 첫번째를 기준으로 잡아주기 

        enemy = FoundObjects[0]; // 첫번째를 먼저 

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                enemy = found;
                shortDis = Distance;
            }

        }
        //Debug.Log(enemy.transform.position);

        StartPosition = transform.position;
        EndPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0);

        startTime = Time.time;
        distanceLength = Vector3.Distance(StartPosition, EndPosition);


        transform.Translate(Vector3.up * Time.deltaTime);

        currPosition = transform.position;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(currPosition, EndPosition, step);
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
