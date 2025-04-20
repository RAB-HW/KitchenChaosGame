using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderListUI : MonoBehaviour
{
    [SerializeField] private Transform recipeParent;//���еĲ˵����ɵ�ʱ�򶼻�ŵ�RecipeList����
    [SerializeField] private RecipeUI recipeUITemplate;//��ÿһ��������ģ��

    //����¼���ÿ������һ���������͸���UI
    private void Start()
    {
        recipeUITemplate.gameObject.SetActive(false);//ģ�岻��Ҫ��ʾ��ֻ��Ҫ���õ�
        OrderManager.Instance.OnRecipeSpawned += OrderManager_OnRecipeSpawned;
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    private void OrderManager_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    //�ṩһ��UI���µĹ���
    private void UpdateUI()
    {
        //��֮ǰ�����Ķ����б����ٵ�
        foreach (Transform child in recipeParent)//����֮�����ٵ�
        {
            if (child != recipeUITemplate.transform)//��Ҫ��ģ��Ҳ������
            {
                Destroy(child.gameObject);
            }
        }

        //��ʼ��������
        //��������Ҫ�õ������б�
       List<RecipeSO> recipeSOList= OrderManager.Instance.GetOrderList();

        foreach (RecipeSO recipeSO in recipeSOList)
        {
            //����ģ��ʵ����
           RecipeUI recipeUI= GameObject.Instantiate(recipeUITemplate);
            recipeUI.transform.parent = recipeParent;//�ŵ�recipeParent�·�
            recipeUI.gameObject.SetActive(true);//��ΪĬ�ϲ���ʾ�������Ȱ�������ʾ
            recipeUI.UpdateUI(recipeSO);//���÷�������ʳ��

        }
    }
}
