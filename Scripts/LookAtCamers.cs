using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamers : MonoBehaviour
{
    
    public enum Mode
    {
        LookAt,//ֱ������ĳһ����
        LookAtInverted,//�����෴����ĵ�
        CameraForward,//��UI�ĳ������������λ�Ƶ�Ӱ��
        CameraForwardInverted
    }

    [SerializeField] private Mode mode;
    
    private void Update()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);//�������

                break;
            case Mode.LookAtInverted:
                //�෴����ĵ������ô���㣺����̨����-Camera���꣩+��̨����
                transform.LookAt( transform.position-Camera.main.transform.position+transform.position);//��������෴�ĵ�

                break;
            case Mode.CameraForward:
                transform.forward= Camera.main.transform.forward;
                break;
            case Mode.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
            default:
                break;
        }





    }
}
