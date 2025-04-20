using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    //首先要持有对两个Button的引用，然后注册两个Button的点击事件，去处理这两个的点击事件
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        //注册点击事件
        //使用匿名函数(lambda表达式)作为点击事件的回调，点击开始后直接进入到游戏开始界面
        //Button 组件有一个名为 onClick 的公共属性
        //AddListener 是 UnityEvent 类的一个方法，用于向事件添加一个回调函数（即“监听器”）。当事件被触发时，这个回调函数会被调用。
        startButton.onClick.AddListener(() =>
        {
            //点击开始之后需要加载下一个场景
            // 这里应该添加加载下一个场景的代码
            // 例如：SceneManager.LoadScene("GameScene");
        });

        quitButton.onClick.AddListener(() =>
        {
            // Application.Quit()方法用于退出应用程序
            // 注意：在Unity编辑器中运行时会停止播放模式，在构建后的应用中会关闭程序
            Application.Quit();//代表退出这个应用
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
