using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]//�������Կ���ͨ���Ҽ�����
public class KitchenObjectSO : ScriptableObject
    //ScriptableObject�ĺô��ǿ���ֱ����Unity��ͨ���Ҽ��ķ�ʽ����һ�����󣬿���ֱ���ڱ��ؽ���ʵ�廯�ı���
{
    public GameObject prefab;
    public Sprite sprite;//����ʳ������ʱ������ֲ˵�����ͼ��
    public string objectname;
}
