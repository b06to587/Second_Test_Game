using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInven : MonoBehaviour
{
    //슬로의 부모 객체
    [SerializeField]
    private GameObject go_SlotsParent;

    //슬롯들
    private Slot[] slots;

    //sampleskill
    [SerializeField]
    private Skill skill1;

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();   
    }

    // Update is called once per frame
    void Update()
    {
        AddSampleSkills(skill1);        
    }

    //샘플 a키 눌렀을 때 스킬 삽입 
    //진동- 이부분 디버깅시 T는뜨는데 슬롯이 작동안함... 
    private void AddSampleSkills(Skill _skill)
    {
        if(Input.GetKeyDown(KeyCode.A))
        {            
            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i].skill == null)
                {
                    slots[i].AddSkill(_skill);
                    return;
                }
            }
        }
    }
}
