using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image progressImage;//��������Image��ͨ����ק��ʽ
    public void Show()
    {
        gameObject.SetActive(true);//��ʾ
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateProgress(float progress)//������ṩһ�������������ý��ȣ�������0-1֮�� ��float
    {
        Show();//ÿ����ʾ֮ǰ������Show��ʾ��Ȼ����ƽ���
        progressImage.fillAmount = progress;//��FillAmount��������Ϊprogress

        //�и���֮��������أ���һ��ʱ������
        if (progress == 1)
        {
            Invoke("Hide", 0.5f);//��0.5s����
        }
    }
}
