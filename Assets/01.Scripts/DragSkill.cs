using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSkill : MonoBehaviour
{
    static public DragSkill instance;

    public Slot dragSlot;

    // 아이템 이미지.
    [SerializeField]
    private Image imageSkill;

    void Start()
    {
        instance = this;
    }

	public void DragSetImage(Image _itemSkill)
    {
        imageSkill.sprite = _itemSkill.sprite;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = imageSkill.color;
        color.a = _alpha;
        imageSkill.color = color;
    }
}
