using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Bullet : MonoBehaviour
{
    public LayerMask LayerEnemy;
    public GameObject Bullet;
    Create_Bullet bullet;

    public float tileDamage = 5f;
    private float rangeRadius = 2f;

    public float TimeLeft = 1.0f;
    private float nextTime = 0.0f;

    //Vector2 vector_Test;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }

    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            exploration();
        }
    }


    private void exploration()
    {
        //Bullet.bulletDamage = tileDamage;

        Instantiate(Bullet, this.transform.position, this.transform.rotation);
    }




}
