using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private Animator anim;//��ȡ���
    private const string CUT = "Cut";
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerCut()//��cuttingCounter������������
    {
        anim.SetTrigger(CUT);
    }
}
