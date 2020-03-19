using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;//씬관리

public class TitleManager : MonoBehaviour
{
    //업그레이드를 위해 필요한 돈
    static int totalMoney;
    //상점정보
    public GameObject shopInfo;
    public Text Money;
    // Start is called before the first frame update
    void Start()
    {
        //임시로 작성
        totalMoney = 300;
    }

    // Update is called once per frame
    void Update()
    {
        showTextMoney();
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
    //보유한 돈 표시 게임내부와 다름!
    private void showTextMoney()
    {
        Money.text ="Money :"+totalMoney.ToString("###,###");
    }
    //상점에서 버튼을 눌렀을시 동작
    public void OnClickBuybutton(GameObject target)
    {
       //텍스트 접근 Debug.Log(target.transform.FindChild("Level").GetComponent<Text>().text);
        target.transform.FindChild("Level").GetComponent<Text>().text+=1;
        
    }
}
