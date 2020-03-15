using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Vector3 oriPos;
    public Skill skill; //획득한 스킬
    public SpriteRenderer skillImage;

    [SerializeField]
    private GameObject go_SkillImage;
    private bool isBeingHeld = false;
    private float startPosX;
    private float startPosY;
    //스킬 추가
    public void AddSkill(Skill _skill)
    {
        skill = _skill; 
        Debug.Log(skill);
        Debug.Log(skill.skillImage.GetType());
        skillImage.sprite = skill.skillImage;
        go_SkillImage = _skill.skillPrefab;
    }

    //스킬 슬롯 전체 초기화
    private void ClearSlot()
    {
        skill = null;
        skillImage.sprite = null;
        go_SkillImage.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        skillImage = GetComponent<SpriteRenderer>();
        oriPos = transform.position;
    }

    // Update is called once per frame
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

    //테두리 색 안보이게 하는 
    private void SetColor(float _alpha)
    {
        Color color = skillImage.color;
        color.a = _alpha;
        skillImage.color = color;
    }

    private void OnMouseDown() 
    {
        Debug.Log("moused");
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

    private void OnMouseUp() 
    {
        Debug.Log("mup");
        isBeingHeld = false;
    }

}
