using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    //* ��һ�����ƣ�ֻ�п��Ա����ʳ�Ĳ��ܷŵ���̨��
    //������Ҫ��ʳ�ķŵ���̨�����ʱ��Ҫ�鿴ʳ�ף��ж�ʳ���Ƿ������ʳ�����棬������ڣ��ſ��Էţ������ھͲ����Է�
    [SerializeField] private FryingRecipeListSO fryingRecipeList;//ͨ����ק�ķ�ʽ���ж�ʳ�׵�����
    [SerializeField] private FryingRecipeListSO burningRecipeList;//ͨ����ק�ķ�ʽ���ж�ʳ�׵�����
    [SerializeField] private StoveCounterVisual stoveCounterVisual;//ͨ����ק�ķ�ʽ���жԿ��ӻ�������
    [SerializeField] private ProgressBarUI progressBarUI;//ͨ����ק�ķ�ʽ���жԽ�����������

    [SerializeField] private AudioSource Sound;//��ȡ��Ч���

    //ͨ��һ��ö�����ͣ���ʾ�����״̬���п��к͹���״̬
    public enum StoveState
    {
        Idle,
        Frying,
        Burning,
    }

    //���Ƽ�Ĳ���
    private FryingRecipe fryingRecipe;//����ʳ��
    private float fryingTimer = 0;
    private StoveState state = StoveState.Idle;//Ĭ����һ������״̬

    public override void Interact(Player player)//��������
    {
        if (player.IsHaveKitchenObject())
        {
            //���������ʳ��
            if (IsHaveKitchenObject() == false)
                
            {
                if(fryingRecipeList.TryGetFryingRecipe(
                    player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe fryingRecipe))
                //��һ�����������ϵ�ʳ�ģ��ڶ��������Ƕ�Ӧ��ʳ�ף�����һ��ָ����ʳ��ȥ�õ����ʳ�ף�
                //����õ�����˵�����ϵ�ʳ�Ĵ����ڼ��ʳ�ף���ʾ���Լ壬Ϊtrue���Ϳ��Լ������ú���ķ���
                //�ж����Ƿ���Լ�
                {
                    //��ǰ��̨û��ʳ�ģ�Ϊ�գ�����ת��
                    TransferKitchenObject(player, this);
                    StartFrying(fryingRecipe);//����
                }
                else if(burningRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe burningRecipe))
                    //�Ƿ������
                {
                    //��ǰ��̨û��ʳ�ģ�Ϊ�գ�����ת��
                    TransferKitchenObject(player, this);
                    StartBurning(burningRecipe);//����
                }
                else//�����Լ�Ҳ��������
                {

                }
                

            }
            else
            {
                //��ǰ��̨��ʳ�ģ���Ϊ��,ת�Ƶ����ǵ�����
            }
        }
        else
        {
            //�������û��ʳ��
            if (IsHaveKitchenObject() == false)
            {
                //��ǰ��̨û��ʳ�ģ�Ϊ�գ�����ת��
            }
            else
            {
                //��ǰ��̨��ʳ�ģ���Ϊ��,ת�Ƶ����ǵ�����
                TurnToIdle();

                TransferKitchenObject(this, player);
            }

        }
    }

    private void Update()
    {
        switch (state)
        {
            case StoveState.Idle://����״̬�²���Ҫ���κ�����
                break;
            case StoveState.Frying:
                //�ü��ʱ������
                fryingTimer += Time.deltaTime;
                //���н������ĸ���
                progressBarUI.UpdateProgress(fryingTimer/fryingRecipe.fryingTime);
                //�жϼ��ʱ���Ƿ񵽴�
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();//�ѵ�ǰʳ�����ٵ�
                    //����һ����֮���ʳ��
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    //state=StoveState.Burning;//��δ��벻��Ҫ��
                    burningRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(), 
                        out FryingRecipe newfryingRecipe);//�ж���burningRecipeList���ܷ�õ�һ��ʳ�ף�����õ��Ϳ�ʼ��
                    StartBurning(newfryingRecipe);

                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                //���н������ĸ���
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.fryingTime);

                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();//�ѵ�ǰʳ�����ٵ�
                    //����һ����֮���ʳ��
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    TurnToIdle();
                    //����֮���Զ��ص�Idle״̬
                }
                break;
            default:
                break;
        }
    }

    //����һ��������ר��������
    private void StartFrying(FryingRecipe fryingRecipe)
    {
        fryingTimer = 0;//������ʱ��
        this.fryingRecipe = fryingRecipe;//������ʳ��
        //����Ϳ�����Update���Ƽ��ʱ�������
        state = StoveState.Frying;//��ʼ���ʱ�򣬰�״̬�޸�ΪFrying
        stoveCounterVisual.ShowStoveEffect();//����Show������ʾ��Ч
        Sound.Play();//��ʼ��Ч�Ĳ���
    }
    //����һ��������ר���������
    private void StartBurning(FryingRecipe fryingRecipe)
    {
        if(fryingRecipe == null)//��ȫУ��
        {
            Debug.LogWarning("�޷����Burning��ʳ�ף��޷�����Burning");
            TurnToIdle();
            return;
        }
        stoveCounterVisual.ShowStoveEffect();//����Show������ʾ��Ч

        fryingTimer = 0;//������ʱ��
        this.fryingRecipe = fryingRecipe;//������ʳ��
        state = StoveState.Burning;//��ʼ���ʱ�򣬰�״̬�޸�ΪFrying


    }
    //������Ч״̬��ת��
    private void TurnToIdle()
    {
        progressBarUI.Hide();//ת����Idle�����ؽ�����
        state=StoveState.Idle;
        stoveCounterVisual.HideStoveEffect();
        Sound.Pause();//��ͣ��Ч�Ĳ���
    }
}
