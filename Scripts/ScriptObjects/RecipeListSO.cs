using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeListSO : ScriptableObject
{
    //用来管理ReipeSO的一个集合
    public List<RecipeSO> recipeSOList;
}
