using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler
{
    private Vector3 oriPos;
    public Skill skill; //획득한 스킬
    public Image skillImage;

    [SerializeField]
    private Text text_Number;
    [SerializeField]
    private GameObject go_SkillImage;
    
    //스킬 추가
    public void AddSkill(Skill _skill)
    {
        skill = _skill;
        skillImage.sprite = skill.skillImage;

        go_SkillImage.SetActive(true);
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
        oriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //테두리 색 안보이게 하는 
    private void SetColor(float _alpha)
    {
        Color color = skillImage.color;
        color.a = _alpha;
        skillImage.color = color;
    }

    //드래그를 시작할때
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(skill != null)
        {
            DragSkill.instance.dragSlot = this;
            DragSkill.instance.DragSetImage(skillImage);
            DragSkill.instance.dragSlot.SetColor(0);

            DragSkill.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (skill != null)
        {
            DragSkill.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSkill.instance.SetColor(0);
        DragSkill.instance.dragSlot = null;
        ClearSlot();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ClearSlot();
    }
}
