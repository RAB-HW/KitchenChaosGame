using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator anim;//�������
    // Start is called before the first frame update
    void Start()
    {
        //�õ����
        anim = GetComponent<Animator>();
        
    }

    //�����ṩһ���������������Ŷ���
    public void PlayerOpen()
    {
        anim.SetTrigger("OpenClose");
    }
}
