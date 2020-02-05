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
    public float enemySpeed= 0.05f;
    public float enemyHp = 10.0f;
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
    // transform.position=Vector2.MoveTowards(transform.position,limitPoint1,enemySpeed*Time.deltaTime);
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
                transform.position=Vector2.MoveTowards(transform.position,firstPoint,enemySpeed*Time.deltaTime);
                yield return null;               
                }
                break;

                case checkPoint.point2:                
                while(nowPoint==checkPoint.point2)
                {
                if(transform.position.x==limitPoint2.x) nowPoint=checkPoint.point3;
                transform.position=Vector2.MoveTowards(transform.position,secondPoint,enemySpeed*Time.deltaTime);
                yield return null;
                }
                break;

                case checkPoint.point3:                
                while(nowPoint==checkPoint.point3)
                {
                if(transform.position.y==limitPoint2.y) nowPoint=checkPoint.point4;
                transform.position=Vector2.MoveTowards(transform.position,finalPoint,enemySpeed*Time.deltaTime);
                yield return null;
                }
                break;

                case checkPoint.point4:                
                while(nowPoint==checkPoint.point4)
                {
                if(transform.position.x==limitPoint1.x) nowPoint=checkPoint.point1;
                transform.position=Vector2.MoveTowards(transform.position,startPoint,enemySpeed*Time.deltaTime);
                yield return null;
                }
                break;
            }

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

}