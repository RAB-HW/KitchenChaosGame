using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance {  get; private set; }//Ϊ����DeliveryCounter������ã����������ɵ���ģʽ

    //����¼��ǵ���������һ��������ʱ��ͻᴥ��
    public event EventHandler OnRecipeSpawned;

    //����¼��ǵ��������һ��������ʱ��ͻᴥ����
    public event EventHandler OnRecipeSuccessed;

    //����¼��ǵ�����û�гɹ����һ��������ʱ��ͻᴥ����
    public event EventHandler OnRecipeFailed;

    [SerializeField] private RecipeListSO recipeSOList;//���ò˵�
    //�µ�����
    [SerializeField] private float orderRate = 2;

    //��������µ�����
   [SerializeField] private int orderMaxCount = 5;

    //���浱ǰ�˿��µĵ����������е�ʳ��
    private List<RecipeSO> orderRecipeSOlist = new List<RecipeSO>();
    //��ʱ����ʱ
    private float orderTimer = 0;

    //��־λ����ʾ�Ƿ�ʼ�µ�/Ӫҵ
    private bool isStartOrder = false;

    private int orderCount = 0;//Ŀǰ�Ѿ��µ�������Ĭ��Ϊ�㣬ÿ���µ�֮������

    private int successDeliveryCount = 0;//�ɹ����������

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;//ע���¼�
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        //�жϵ�ǰ״̬�Ƿ�����Ϸ״̬
        if(GameManager.Instance.IsGamePlayingState())//����ǾͿ�ʼ�µ�
        {
            StartSpawnOrder();//�����µ���ʼ����
        }
    }

    private void Update()
    {
        if (isStartOrder)
        {
            OrderUpdate();
        }
    }

    //��������
    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if(orderTimer >=orderRate)
        {
            orderTimer = 0;
            OrderANewRecipe();//�µ�
        }


    }

    private void OrderANewRecipe()
    {
        if (orderCount >= orderMaxCount)//�ﵽ����µ�������ֹͣ�µ�
        {
            return;
        }
        orderCount++;
        int index=UnityEngine.Random.Range(0, recipeSOList.recipeSOList.Count);//����һ������������Ǽ���recipeSOList������������
        orderRecipeSOlist.Add(recipeSOList.recipeSOList[index]);//���������ʳ��

        //����һ���¼�ȥ���д���
        OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
    }

    //�ṩһ�������������ϲ˺��µ��ĶԱ�,Ҫ��DeliveryCounter.cs����
    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)//Ϊʲô���������ӣ�����Ϊ�����ϱ���������ʳ�ĵļ����б������ж�
    {
        RecipeSO correctionRecipe = null;//��ȷ����
        //Ҫ�����˿��µĵ���ʵ���ϵĲ˵Ĳ����Ƿ���һ�µ�
        foreach(RecipeSO recipe in orderRecipeSOlist)
        {
            if(IsCorrect(recipe, plateKitchenObject))//�������true
            {
                correctionRecipe=recipe; //������ȷ����
                break;

            }
                
        }
        if(correctionRecipe == null)
        {
            print("�ϲ�ʧ��");
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            orderRecipeSOlist.Remove(correctionRecipe);//����ϲ˳ɹ����Ͱ����ӹ˿͵Ĳ�����ȥ��
            OnRecipeSuccessed?.Invoke(this, EventArgs.Empty);
            successDeliveryCount++;//���ϲ˳ɹ�Ҫ�ô���ɹ�����������
            print("�ϲ˳ɹ�");
        }
    }

    //�ṩһ���ȶԵķ���

    private bool IsCorrect(RecipeSO recipeSO,PlateKitchenObject plateKitchenObject)//��һ�������ǹ˿��µĵ����ڶ�������������ʵ�����Ĳ�
    {
        //Ҫ�ȶ���������
        List<KitchenObjectSO>list=recipeSO.kitchenObjectSOList;
        List<KitchenObjectSO>list2=plateKitchenObject.GetKitchenObjectSOList();

        //���ȶԱȳ���
        if (list.Count != list.Count)
        {
            return false;
        }

        //����һ�����ϣ��۲��Ƿ��������һ�����ϵ�����Ԫ��
        foreach(KitchenObjectSO kitchenObjectSO in list)
        {
            if (list2.Contains(kitchenObjectSO)==false)//����в������ľ�˵����һ��
            {
                return false;
            }
        }
        return true;
    }

    //�ṩһ����ȡ�������ϵķ���
    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOlist;
    }

    //�ṩһ���������ڿ�ʼ���ɶ���
    public void StartSpawnOrder()
    {
        isStartOrder = true;
    }

    //�ṩһ�������������Ի��successDeliveryCount
    public int GetSuccessDeliveryCount()
    {
        return successDeliveryCount;
    }
}
