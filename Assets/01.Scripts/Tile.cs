using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private bool isbuild = false;
    [SerializeField]
    private GameObject turretobj;

    public Vector2 tileOrigianlPos;
    // Start is called before the first frame update
    void Start()
    {
        //타일의 지금 포지션을 구한다
        tileOrigianlPos = new Vector2(this.transform.position.x, this.transform.position.y);
        //Debug.Log(tileOrigianlPos);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //2020.02.23 KBJ
    //마우스 누를때마다 생기는 이벤트 터렛을 만드는 메소드를 실행한다
    private void OnMouseDown()
    {
        CreateTurret();
    }

    //2020.02.23 KBJ
    // 자기자신의 위치에 터렛을 생성하고 부모를 바꾼다
    private void CreateTurret()
    {
        if (!isbuild)
        {   //터렛 무한생성 방지    // 터렛 레벨 확인
            GameObject newturret = Instantiate(turretobj, tileOrigianlPos, Quaternion.identity);
            newturret.transform.SetParent(gameObject.transform, true);
            isbuild = true;
        }
        else
        {
           return;
        }
    }
}
