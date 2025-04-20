using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectGridUI : MonoBehaviour
{
    [SerializeField] private KitchenObjectIconUI iconTemplateUI;//通过拖拽对iconTemplateUI进行引用

    //默认第一个模板iconTemplateUI是作为模板的，不会显示，用来引出其他图标的
   
    private void Start()
    {
        iconTemplateUI.Hide();
        //iconTemplateUI.gameObject.SetActive(false);
    }
    public void ShowKitchenObjectUI(KitchenObjectSO kitchenObjectSO)
    {
        //当我们要指定一个图标的时候，通过IconTemplate实例化一个新的
       KitchenObjectIconUI newIconUI= GameObject.Instantiate(iconTemplateUI,transform);//新的图标要放到网格下方

        //newIconUI.transform.SetParent(transform);跟上面的第二个参数效果一样
        newIconUI.Show(kitchenObjectSO.sprite);
    }
}
