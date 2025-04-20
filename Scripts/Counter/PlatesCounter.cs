using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    //���ж��������ݶ�������ã���קһ��
    [SerializeField] private KitchenObjectSO plateSO;
    //Ҫ�Զ��������ӣ�����Ҫ�м�ʱ��
    [SerializeField] private float spawnRate = 2;//�������ӵ�����
    [SerializeField] private int plateCountMax = 5;//�����������ɵ��������

    //���ɵ�����Ҫ���ŵ�һ���������汣��
    private List<KitchenObject> platesList= new List<KitchenObject>();

    private float timer = 0;

    private void Update()
    {
        if(platesList.Count < plateCountMax)
        {
            timer += Time.deltaTime;
            //ֻ�е���������С���������ʱ�����Ӳ������ӣ�Ϊ�˷�ֹ��ʱ��һֱ���ӣ�Ȼ��ĳһ�̸�����󵽴�ֵ�����������

        }
        if (timer > spawnRate)
        {
            timer = 0;
            //��һ�����ӵ�Prefab����
            SpawnPlate();
        }
    }

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject()==false)
        {
            //���������ʳ�ģ�����ȡ����
            //�������û��ʳ�ģ�����ȡ����
            if (platesList.Count > 0)
            {
                player.AddKitchenObject(platesList[platesList.Count - 1]);//�Ѽ����������һ����������
                platesList.RemoveAt(platesList.Count - 1);//�Ƴ����һ��
            }

        }
        
    }

    //���������ӵķ���
    public void SpawnPlate()//��������ָ����Prefab����һ��ʳ��
    {
        if(platesList.Count>=plateCountMax)//������������ﵽ���������ֹͣ����
        {
            timer = 0;//���������ɵ��������ʱ���Ѽ�ʱ�����㣬Ϊ�˷�ֹ��ʱ��һֱ���ӣ�Ȼ��ĳһ�̸�����󵽴�ֵ�����������
            return;
        }
        KitchenObject kitchenObject = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();//��ȡkitchenObject�����

        //��ÿһ�������ɵ����Ӷ�����������һ��λ��
        kitchenObject.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * platesList.Count;//ÿ����һ�����ӣ�������ƫ��0.1m

        //���ɵ�����Ҫ�ŵ���������
        platesList.Add(kitchenObject);


    }
}
