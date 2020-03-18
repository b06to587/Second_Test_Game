using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TurretControl : MonoBehaviour
{
    SpriteRenderer render;
    //    public LayerMask LayerEnemy;
    public GameObject Bullet;

    public List<GameObject> FoundObjects;
    private GameObject enemy;
    private string tagName = "Enemy";
    public float shortDis;

    public float damage = 5f;           //데미지
    float damage_Upgrade = 2f;
    public float attack_Range = 2f;     //사거리
    public float timeLeft = 1.0f;         //공속
    private float nextTime = 0.0f;

    public int turretLevel = 0;

    //텍스트 관련
    public Text elementalText;
    public Camera camera;
    private Transform target;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        //텍스트 관련
        target = GetComponent<Transform>();
        Vector2 screenPos = camera.WorldToScreenPoint(target.position);
        float x = screenPos.x;
        elementalText.transform.position = new Vector2(x, screenPos.y);
    }

    void Update()
    {
        FindEnemy();
    }

    // 가장 가까운 적 찾기
    public void FindEnemy()
    {
        try
        {
            FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
            shortDis = Vector2.Distance(gameObject.transform.position, FoundObjects[0].transform.position); // 첫번째를 기준으로 잡아주기 

            enemy = FoundObjects[0]; // 첫번째를 먼저 적으로 삼고

            foreach (GameObject found in FoundObjects)  //적 오브젝트를 수만큼 반복하며 찾아보리기
            {
                float Distance = Vector2.Distance(gameObject.transform.position, found.transform.position);

                if (Distance < shortDis) // 위에서 잡은 기준으로 거리 비교해서
                {
                    enemy = found;
                    shortDis = Distance;    //더 짧은놈이 적
                }
            }
            if (FoundObjects[0] != null)
            {
                Fire();
            }
        }
        catch (ArgumentOutOfRangeException) { }
    }

    private void Fire()
    {
        if (shortDis <= attack_Range)    // 가장가까운적이 사정거리에 들어와 있으면 총알 발사
        {
            StartCoroutine(Wait());
        }
    }

    //공격속도 제어
    IEnumerator Wait()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + timeLeft;
            Create();
        }
        yield return null;
    }

    //총알 생성
    private void Create()
    {
        GameObject newBullet = Instantiate(Bullet, this.transform.position, this.transform.rotation);
        newBullet.transform.SetParent(gameObject.transform, true);  
    }

    //터렛 생성시 레벨을 확인하고 적용
    public void TurretList()
    {
        switch (turretLevel)
        {
            case 2:
                render.color = new Color(1, 0, 0, 1);
                damage += damage_Upgrade;
                break;
            case 3:
                render.color = new Color(1, 0.5f, 0, 1);
                damage += damage_Upgrade;
                break;
            case 4:
                render.color = new Color(0, 1, 0, 1);
                damage += damage_Upgrade;
                break;
            case 5:
                render.color = new Color(0, 0, 1, 1);
                damage += damage_Upgrade;
                break;
        }
    }


}
