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

    //스킬 추가
    public void AddSkill(Skill _skill)
    {
        this.skill = _skill;
        GameObject skillprefab =  Instantiate(_skill.skillPrefab,transform.position,Quaternion.identity);
        skillprefab.transform.localScale =  new Vector3(0.2f,0.2f,0);
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



    //테두리 색 안보이게 하는 
    private void SetColor(float _alpha)
    {
        Color color = skillImage.color;
        color.a = _alpha;
        skillImage.color = color;
    }

    
}
