using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenObjectIconUI : MonoBehaviour
{
    //��Ҫ���ж�������SourceImage������
    [SerializeField] private Image iconImage;//�ǵ���ק��ȥ

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
