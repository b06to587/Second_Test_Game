using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//스킬을 실제로 drag 할때를 위해 만든 클래스
public class DragSkill : MonoBehaviour
{
    private string mSkillName;
    private bool isBeingHeld = false;
    private float startPosX;
    private float startPosY;
    private bool inTile = false;




    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
        
        isBeingHeld = true;
    }

    void Update()
    {
       FollowMousePos();
       ChangeSize();
    }

    private void ChangeSize()
    {
        if(SkillinTile(this.transform.position.x, this.transform.position.y))
        {
            this.transform.localScale = new Vector3(0.43f, 0.43f, 0);
        }
        else
        {
           this.transform.localScale =  new Vector3(0.2f,0.2f,0);
        }
    }

    private bool SkillinTile(float x, float y)
    {
        if( (x>-1 && x < 1) && (y >1 && y< 3))
        {
            inTile = true;
        }
        else
        {
            inTile = false;
        }
        return inTile;
    }

    private void FollowMousePos()
    {
        if(isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX,mousePos.y - startPosY,0);
        }
    }
    private void OnMouseUp() 
    {
        isBeingHeld = false;
    }
}
