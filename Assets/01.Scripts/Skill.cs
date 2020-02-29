using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Skill", menuName = "New Skill/skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite skillImage;
    public SkillType skillType;
    public GameObject skillPrefab;

    public enum SkillType
    {
        Active,
        Passive
    }

}
