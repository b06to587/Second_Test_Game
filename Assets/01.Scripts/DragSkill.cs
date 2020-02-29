using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//스킬을 실제로 drag 할때를 위해 만든 클래스
public class DragSkill : MonoBehaviour
{
    static public DragSkill instance;

    public Slot dragSlot;

    // 아이템 이미지.
    [SerializeField]
    private Image imageSkill;

    //자기자신을 넣어준다
    void Start()
    {
        instance = this;
    }

    //드래그 이미지를 넣어준다 
	public void DragSetImage(Image _itemSkill)
    {
        imageSkill.sprite = _itemSkill.sprite;
        SetColor(1);
    }

    //투명도를 조절한다
    public void SetColor(float _alpha)
    {
        Color color = imageSkill.color;
        color.a = _alpha;
        imageSkill.color = color;
    }
}
