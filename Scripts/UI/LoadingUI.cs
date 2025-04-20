using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    //Ҫ��DotText�������ã����޸�����ĵ�
   [SerializeField] private TextMeshProUGUI dotText;
    private float dotRate = 0.3f;

    private void Start()
    {
        //����Э��
        StartCoroutine(DotAnimation());
    }
    //ʹ��Я�̵ķ�ʽ�����в���
    IEnumerator DotAnimation()
    {
        while (true)
        {
            dotText.text = ".";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "..";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "...";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = ".....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "......";
            yield return new WaitForSeconds(dotRate);

        }

    }
}
