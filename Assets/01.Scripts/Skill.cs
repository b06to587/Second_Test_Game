using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ��ũ��Ʈ
[CreateAssetMenu(fileName ="New Skill", menuName = "New Skill/skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite skillImage;
    public SkillType skillType;
    public GameObject skillPrefab;
    
    public DragSkill dragable;


    public enum SkillType
    {
        Active,
        Passive
    }

}
