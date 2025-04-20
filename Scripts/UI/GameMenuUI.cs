using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    //����Ҫ���ж�����Button�����ã�Ȼ��ע������Button�ĵ���¼���ȥ�����������ĵ���¼�
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        //ע�����¼�
        //ʹ����������(lambda���ʽ)��Ϊ����¼��Ļص��������ʼ��ֱ�ӽ��뵽��Ϸ��ʼ����
        //Button �����һ����Ϊ onClick �Ĺ�������
        //AddListener �� UnityEvent ���һ���������������¼����һ���ص��������������������������¼�������ʱ������ص������ᱻ���á�
        startButton.onClick.AddListener(() =>
        {
            //�����ʼ֮����Ҫ������һ������
            // ����Ӧ����Ӽ�����һ�������Ĵ���
            // ���磺SceneManager.LoadScene("GameScene");
        });

        quitButton.onClick.AddListener(() =>
        {
            // Application.Quit()���������˳�Ӧ�ó���
            // ע�⣺��Unity�༭��������ʱ��ֹͣ����ģʽ���ڹ������Ӧ���л�رճ���
            Application.Quit();//�����˳����Ӧ��
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
