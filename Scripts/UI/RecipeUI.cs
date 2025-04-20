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
    //�ṩһ���������ڸ���ʳ�ĵ�UI��ʾ
    public void UpdateUI(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;
        foreach(KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
           Image newIcon=GameObject.Instantiate(iconUITemplate);//ʵ����ͼ��
            newIcon.transform.SetParent(kitchenObjectParent);//���ø�����
            newIcon.sprite = kitchenObjectSO.sprite;//����ͼ��
            newIcon.gameObject.SetActive(true);//����
        }
    }
}
