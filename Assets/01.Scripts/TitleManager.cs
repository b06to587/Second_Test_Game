using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬관리

public class TitleManager : MonoBehaviour
{
    public GameObject shopInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //게임시작 누르면 게임씬으로 이동
    public void OnclickGameStart()
    {
         SceneManager.LoadScene("Stage1");//씬번호 이름
    }
    //상점열기버튼
    public void OnclickShop()
    {
        shopInfo.SetActive(true);
    }
    //상점에서 닫기버튼
    public void OnClickShopCheck()
    {
        shopInfo.SetActive(false);
    }
}
