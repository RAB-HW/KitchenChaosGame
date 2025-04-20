using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }//���������¼��������������
   [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Awake()
    {
        Instance = this;
    }
    //ע���¼�
    private void Start()
    {
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenObejctHolder.OnDrop += KitchenObejctHolder_OnDrop;
        KitchenObejctHolder.OnPickUp += KitchenObejctHolder_OnPickUp;
        TrashCounter.OnObjectTrashed += TrashCounter_OnObjectTrashed;
    }

    private void TrashCounter_OnObjectTrashed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.trash);
    }

    private void KitchenObejctHolder_OnPickUp(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup);
    }

    private void KitchenObejctHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectDrop);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliveryFail);
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliverySuccess);
    }
    //���һ���������ƽŲ����Ĳ���
    public void PlayStepSound(float volume=.1f)
    {
        PlaySound(audioClipRefsSO.footstep,volume);
    }
    //���ط���
    private void PlaySound(AudioClip[] clips, float volume = .1f)
    {
        PlaySound(clips, Camera.main.transform.position);
    }
    //����������ͨ�÷���
    private void PlaySound(AudioClip[] clips,Vector3 position,float volume = .1f)
        //��һ�������ǲ��ŵ����֣��ڶ��������ǲ��ŵ�λ�ã������������ǲ��ŵ�����
    {
        int index=Random.Range(0,clips.Length);//����������е�����
        AudioSource.PlayClipAtPoint(clips[index],position,volume);
    }
    
}
