using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderListUI : MonoBehaviour
{
    [SerializeField] private Transform recipeParent;//所有的菜单生成的时候都会放到RecipeList里面
    [SerializeField] private RecipeUI recipeUITemplate;//是每一个订单的模板

    //监测事件，每次下了一个订单，就更新UI
    private void Start()
    {
        recipeUITemplate.gameObject.SetActive(false);//模板不需要显示，只需要禁用掉
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

    //提供一个UI更新的功能
    private void UpdateUI()
    {
        //把之前创建的订单列表销毁掉
        foreach (Transform child in recipeParent)//遍历之后销毁掉
        {
            if (child != recipeUITemplate.transform)//不要把模板也销毁了
            {
                Destroy(child.gameObject);
            }
        }

        //开始进行生成
        //生成首先要得到订单列表
       List<RecipeSO> recipeSOList= OrderManager.Instance.GetOrderList();

        foreach (RecipeSO recipeSO in recipeSOList)
        {
            //根据模板实例化
           RecipeUI recipeUI= GameObject.Instantiate(recipeUITemplate);
            recipeUI.transform.parent = recipeParent;//放到recipeParent下方
            recipeUI.gameObject.SetActive(true);//因为默认不显示，所以先把他搞显示
            recipeUI.UpdateUI(recipeSO);//调用方法更新食谱

        }
    }
}
