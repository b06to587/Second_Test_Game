﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //싱글톤 구현 (다른 스크립트에서 참조 가능하도록)
    public static Manager gm;
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject baseGroud;
    [SerializeField]
    private int gameMoney;

    //적 오브젝트
    public GameObject EnemyPrefabs;
    //현재 스테이지 리스트를 관리
    public enum nowStageList
    {
        stage1,stage2,stage3
    }
    public nowStageList nowStage;
    // Start is called before the first frame update
    void Awake()
    {
        gm = this;// 싱글톤 구현 완료
    }
    void Start()
    {
       //Debug.Log(TileSize);
        CreateTile();
       
        
        //시작 스테이지 입력
        nowStage =nowStageList.stage1;
        
        //스테이지 매니저 시작(스포너 실행)
        StartCoroutine(StageManager());
 
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
        //Debug.Log(worldStart);

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
        newTile.transform.parent = baseGroud.transform;
    }


    //스포너
    public void spawnDefaultEnemy()
    {
        Enemy defaultE = new Enemy();
        defaultE.enemyHp =10;
        defaultE.enemySpeed= 3.0f;
        EnemyPrefabs.GetComponent<EnemyControl>().createEnmey =defaultE; 
        Instantiate(EnemyPrefabs);
    }


        public void spawnSpeedEnemy()
    {
        Enemy speedE = new Enemy();
        speedE.enemySpeed= 15.0f;
        speedE.enemyHp = 10;
        EnemyPrefabs.GetComponent<EnemyControl>().createEnmey =speedE; 
        Instantiate(EnemyPrefabs);
    }



    //스테이지 매니저
    IEnumerator StageManager()
    {
        switch(nowStage)
        {
            case nowStageList.stage1:
            Debug.Log("현재스테이지는 1입니다");
            for(int i = 0; i<=5 ; i++)
            {
                spawnDefaultEnemy();
                yield return new WaitForSeconds(2.0f);
            }
            for(int i = 0; i<=2 ; i++)
            {
                spawnSpeedEnemy();
                yield return new WaitForSeconds(1.0f);
            }
            
            yield return null; 
            break;
        }
    }
    






}
