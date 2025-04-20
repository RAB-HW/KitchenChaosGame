using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }//创建单例事件，方便外界引用
   [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Awake()
    {
        Instance = this;
    }
    //注册事件
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
    //添加一个方法控制脚步声的播放
    public void PlayStepSound(float volume=.1f)
    {
        PlaySound(audioClipRefsSO.footstep,volume);
    }
    //重载方法
    private void PlaySound(AudioClip[] clips, float volume = .1f)
    {
        PlaySound(clips, Camera.main.transform.position);
    }
    //播放声音的通用方法
    private void PlaySound(AudioClip[] clips,Vector3 position,float volume = .1f)
        //第一个参数是播放的音乐，第二个参数是播放的位置，第三个参数是播放的音量
    {
        int index=Random.Range(0,clips.Length);//随机播放其中的音乐
        AudioSource.PlayClipAtPoint(clips[index],position,volume);
    }
    
}
