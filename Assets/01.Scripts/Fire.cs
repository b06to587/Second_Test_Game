﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class Fire : MonoBehaviour
{
    public List<GameObject> FoundObjects;
    private GameObject enemy;
    private string TagName = "Enemy";
    private float shortDis;

    private float damage;

    public float speed = 50f;

    public Skill Skill7777;

    private Vector2 endPosition;
    private Vector2 startPosition;

    void Start()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName));
        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position); // 첫번째를 기준으로 잡아주기 

        enemy = FoundObjects[0]; // 첫번째를 먼저 
        Bullet_State();
   //     Debug.Log(damage);
     //   Debug.Log(gameObject.tag);
    }

    public void Update()
    {
        try
        {
            foreach (GameObject found in FoundObjects)
            {
                float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

                if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
                {
                    enemy = found;
                    shortDis = Distance;
                }
            }

            //현재위치
            startPosition = transform.position;
            //적위치
            endPosition = new Vector2(enemy.transform.position.x, enemy.transform.position.y);

            float step = speed * Time.deltaTime;
            //발사!
            transform.position = Vector2.MoveTowards(startPosition, endPosition, step);
        }

        catch(MissingReferenceException)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    // 터렛 정보 얻기
    public void Bullet_State()
    {
        TurretControl state = transform.parent.GetComponent<TurretControl>();
        damage = state.damage;
        Tag();
    }

    //태그 변경
    //스킬일경우 체크 스킬이아니면 터렛ㅌㅐ그
    //스킬이면 스킬태그로 파이어함
    private void Tag()
    {
        if(this.gameObject.tag=="Skill")
        {
            gameObject.tag = string.Format(Skill7777.skillName);
        }
        else
        {
        TurretControl state = transform.parent.GetComponent<TurretControl>();
        switch (state.turretLevel)
        {
                case 2:
                    gameObject.tag = "Bullet1";
                    break;
                case 3:
                    gameObject.tag = "Bullet2";
                    break;
                case 4:
                    gameObject.tag = "Bullet3";
                    break;
                case 5:
                    gameObject.tag = "Bullet4";
                    break;
                case 6:
                    gameObject.tag = "Bullet5";
                    break;
                case 7:
                    gameObject.tag = "Bullet6";
                    break;
                case 8:
                    gameObject.tag = "Bullet7";
                    break;
                case 9:
                    gameObject.tag = "Bullet8";
                    break;
                case 10:
                    gameObject.tag = "Bullet9";
                    break;
            }
    }
    }

}
