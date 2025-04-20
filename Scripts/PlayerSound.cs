using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
     private Player player;
    private float stepSoundRate = 0.13f;
    private float stepSoundTimer = 0;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        stepSoundTimer += Time.deltaTime;
        if(stepSoundTimer > stepSoundRate)
        {
            stepSoundTimer = 0;
            //增加一个条件判断，当我们主角行走的时候才需要脚步声
            if(player.IsWalking)
            {
                float volume = .1f;
                SoundManager.Instance.PlayStepSound(volume);
            }
            
        }
    }
}
