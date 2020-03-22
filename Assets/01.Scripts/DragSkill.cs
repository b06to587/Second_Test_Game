using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//스킬을 실제로 drag 할때를 위해 만든 클래스
public class DragSkill : MonoBehaviour
{

    private bool isBeingHeld = false;
    private float startPosX;
    private float startPosY;


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
       followMousePos();
    }


    private void followMousePos()
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
