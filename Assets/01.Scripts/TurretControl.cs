using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TurretControl : MonoBehaviour
{
    public int turretCheck = 0;
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
    public int turretTier = 0;

    //텍스트 관련
    public Text levelText;
    public Text levelTextTier;
    public Camera camera;
    private Transform target;
    private RectTransform rect_levelText;
    private RectTransform rect_levelTextTier;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        //텍스트 관련
        target = GetComponent<Transform>();
        Vector2 screenPos = camera.WorldToScreenPoint(target.position);
        float x = screenPos.x;
        levelText.transform.position = new Vector2(x, screenPos.y);
        levelTextTier.transform.position = new Vector2(x, screenPos.y);
        rect_levelText = levelText.GetComponent<RectTransform>();    //티어 위치 변경
        rect_levelTextTier = levelTextTier.GetComponent<RectTransform>();
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


    private void OnMouseDown()
    {
        UpgradeTurret();
    }


    //터렛 생성시 레벨을 확인하고 적용
    public void TurretList()
    {
        switch (turretLevel)
        {
            case 1:
                render.color = new Color(0.1f, 0.5f, 0.9f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "0";
                break;
            case 2:
                render.color = new Color(0.1f, 0.5f, 0.9f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "1";
                break;
            case 3:
                render.color = new Color(0.2f, 0.5f, 0.8f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "2";
                break;
            case 4:
                render.color = new Color(0.3f, 0.5f, 0.7f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "3";
                break;
            case 5:
                render.color = new Color(0.4f, 0.5f, 0.6f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "4";
                break;
            case 6:
                render.color = new Color(0.6f, 0.5f, 0.4f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "5";
                break;
            case 7:
                render.color = new Color(0.7f, 0.5f, 0.3f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "6";
                break;
            case 8:
                render.color = new Color(0.8f, 0.5f, 0.2f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "7";
                break;
            case 9:
                render.color = new Color(0.9f, 0.5f, 0.1f, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "8";
                break;
            case 10:
                render.color = new Color(1, 0.5f, 0, 1);
                damage += damage_Upgrade;
                levelText.GetComponent<Text>().text = "9";
                break;
            default:
                turretTier += 1;
                TierCheck();
                break;
        }
    }

    public void UpgradeTurret()
    {
        turretCheck++;
        this.turretLevel = turretCheck;
        this.TurretList();    //터렛 업그레이드
    }

    private void TierCheck()
    {
        if (turretTier == 1)
        {
            Tile tile = transform.parent.GetComponent<Tile>();
            levelTextTier.GetComponent<Text>().text = "★";
            levelText.GetComponent<Text>().text = "0";
            turretCheck = 1;
            rect_levelText.sizeDelta = new Vector2(160, 21);
        }

        if (turretTier == 2)
        {
            Tile tile = transform.parent.GetComponent<Tile>();
            levelTextTier.GetComponent<Text>().text = "★★";
            levelText.GetComponent<Text>().text = "0";
            turretCheck = 1;
            rect_levelTextTier.sizeDelta = new Vector2(178, 55);
        }
    }


}
