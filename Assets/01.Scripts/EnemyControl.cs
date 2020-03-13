using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    //이동체크포인트 제한
    public Vector2 limitPoint1;
    public Vector2 limitPoint2;

    private Vector2 startPoint;
    private Vector2 firstPoint;
    private Vector2 secondPoint;
    private Vector2 finalPoint;
    

    public enum checkPoint
    {
        point1,point2,point3,point4
    }
    public checkPoint nowPoint;




    //에너미 스테이터스 영역
    public Enemy createEnmey;

    //스프라이트 변경
  

    // Start is called before the first frame update
    void Start()
    {
 
         


        nowPoint = checkPoint.point1;
                //리미트포인트 1은 좌상단 2는 우하단
        startPoint= new Vector2(limitPoint1.x, limitPoint2.y);
        firstPoint= new Vector2(limitPoint1.x, limitPoint1.y);
        secondPoint= new Vector2(limitPoint2.x, limitPoint1.y);
        finalPoint= new Vector2(limitPoint2.x, limitPoint2.y);
        transform.position=startPoint;


        

       
        StartCoroutine(moveToPoint());
     
    }

    // Update is called once per frame
    void Update()
    {
        isDestroy();
    }



    IEnumerator moveToPoint()
    {


      
        while(true)
        {
            switch(nowPoint)
            {
                case checkPoint.point1:
                
                while(nowPoint==checkPoint.point1)
                {
                if(transform.position.y==limitPoint1.y) nowPoint=checkPoint.point2;
                transform.position=Vector2.MoveTowards(transform.position,firstPoint,createEnmey.enemySpeed *Time.deltaTime);
                yield return null;               
                }
                break;

                case checkPoint.point2:                
                while(nowPoint==checkPoint.point2)
                {
                if(transform.position.x==limitPoint2.x) nowPoint=checkPoint.point3;
                transform.position=Vector2.MoveTowards(transform.position,secondPoint,createEnmey.enemySpeed *Time.deltaTime);
                yield return null;
                }
                break;

                case checkPoint.point3:                
                while(nowPoint==checkPoint.point3)
                {
                if(transform.position.y==limitPoint2.y) nowPoint=checkPoint.point4;
                transform.position=Vector2.MoveTowards(transform.position,finalPoint,createEnmey.enemySpeed *Time.deltaTime);
                yield return null;
                }
                break;

                case checkPoint.point4:                
                while(nowPoint==checkPoint.point4)
                {
                if(transform.position.x==limitPoint1.x) nowPoint=checkPoint.point1;
                transform.position=Vector2.MoveTowards(transform.position,startPoint,createEnmey.enemySpeed*Time.deltaTime);
                yield return null;
                }
                break;
            }

        }
       
    }




    //오브젝트 상태 점검해서 파괴해줄 함수
    public void isDestroy()
    {
        if(createEnmey.enemyHp <=0)
        {
            Debug.Log("이건 파괴되어야 합니다");
            Destroy(this.gameObject);
        }
    }


    //에너미 이동경로 찍어줌
      private void OnDrawGizmos()
    {
        Vector2 limitPoint3 = new Vector2(limitPoint2.x,limitPoint1.y); 
        Vector2 limitPoint4 = new Vector2(limitPoint1.x,limitPoint2.y);
        Gizmos.color =Color.red;
        Gizmos.DrawLine(limitPoint1,limitPoint3);
        Gizmos.DrawLine(limitPoint3,limitPoint2);
        Gizmos.DrawLine(limitPoint1,limitPoint4);
        Gizmos.DrawLine(limitPoint4,limitPoint2);
    }


    //충돌처리
    //블렛 태그 확인해서 충돌처리한다 
    void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.gameObject.tag.Equals("Bullet0"))
        // {
        //     Debug.Log("총알에 맞았다!");
        // }
        switch(other.tag)
        {
            case "Bullet0":
            Debug.Log(" 0총알에 맞았다!");
            createEnmey.enemyHp -=5; 
            break;

            case "Bullet1":
            Debug.Log(" 1총알에 맞았다!");
            createEnmey.enemyHp -=5; 
            slowBullet();
            break;

            case "Bullet2":
            Debug.Log(" 2총알에 맞았다!");
            break;

            case "Bullet3":
            Debug.Log("3총알에 맞았다!");
            break;

            case "Bullet4":
            Debug.Log("4총알에 맞았다!");
            break;

            case "Bullet5":
            Debug.Log("5총알에 맞았다!");
            break;

            case "Bullet6":
            Debug.Log("6총알에 맞았다!");
            break;

            case "Bullet7":
            Debug.Log("7총알에 맞았다!");
            break;

            case "Bullet8":
            Debug.Log("8총알에 맞았다!");
            break;

            case "Bullet9":
            Debug.Log("9총알에 맞았다!");
            break;

        }
        
    }


    //스킬 효과들을 정의합니다
    public void slowBullet()
    {
        if(createEnmey.enemySpeed >= 1.0f)
        {
            createEnmey.enemySpeed -=2.0f;
        }
    }


}
   


[System.Serializable]
public class Enemy{
    //에너미 스테이터스 영역
    public float enemySpeed;
    public float enemyHp;
    public float enemyMoney;
    public SpriteRenderer mySprite;

    

    
    
    
}