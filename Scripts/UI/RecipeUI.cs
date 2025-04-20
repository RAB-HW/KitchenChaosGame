using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform kitchenObjectParent;
    [SerializeField] private Image iconUITemplate;

    private void Start()
    {
        iconUITemplate.gameObject.SetActive(false);
    }
    //提供一个方法用于更新食材的UI显示
    public void UpdateUI(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;
        foreach(KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
           Image newIcon=GameObject.Instantiate(iconUITemplate);//实例化图标
            newIcon.transform.SetParent(kitchenObjectParent);//设置父物体
            newIcon.sprite = kitchenObjectSO.sprite;//更新图标
            newIcon.gameObject.SetActive(true);//激活
        }
    }
}
