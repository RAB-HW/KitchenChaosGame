using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private Animator anim;//获取组件
    private const string CUT = "Cut";
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerCut()//在cuttingCounter里调用这个方法
    {
        anim.SetTrigger(CUT);
    }
}
