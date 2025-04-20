using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamers : MonoBehaviour
{
    
    public enum Mode
    {
        LookAt,//直接面向某一个点
        LookAtInverted,//面向相反方向的点
        CameraForward,//让UI的朝向不受相机左右位移的影响
        CameraForwardInverted
    }

    [SerializeField] private Mode mode;
    
    private void Update()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);//面向相机

                break;
            case Mode.LookAtInverted:
                //相反方向的点可以怎么计算：（柜台坐标-Camera坐标）+柜台坐标
                transform.LookAt( transform.position-Camera.main.transform.position+transform.position);//面向相机相反的点

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
