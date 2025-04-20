using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenObjectIconUI : MonoBehaviour
{
    //需要持有对子物体SourceImage的引用
    [SerializeField] private Image iconImage;//记得拖拽进去

    public void Show(Sprite sprite)
    {
        gameObject.SetActive(true);
        iconImage.sprite = sprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);

    }
}
