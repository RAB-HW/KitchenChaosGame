using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public string recipeName;
    //ʳ���б�
    public List<KitchenObjectSO> kitchenObjectSOList;
}
