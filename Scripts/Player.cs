using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : KitchenObejctHolder
{
    public static Player Instance {  get; private set; }//单例模式
    //[SerializeField]让字段可以在面板修改
    //{get,set}可以让外界访问
    [SerializeField] private float moveSpeed = 7;//控制移动速度
    [SerializeField] private float rotateSpeed = 10;//控制旋转速度
    [SerializeField] private GameInput gameInput;//为了调用GetMovementDirectionNormalized方法

    [SerializeField] private LayerMask counterLayerMask;//LayMask代表层的遮罩，counterLayMask代表是柜台这一层，记得指定counter层

    private bool isWalking = false;
    private BaseCounter selectedCounter;//去存储当前的Counter

    // Start is called before the first frame update
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnOperateAction += GameInput_OnOperateAction;
    }

    

    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    //除物理方面的代码，其他基本上都在Update里面
    private void Update()
    {
        HandleInteraction();
    }
    

    //只要涉及物体物理位置的修改，朝向，旋转，方位一般放在FixedUpdate，让物体执行频率跟引擎执行频率保持一致
    private void FixedUpdate()
    {
        HandleMovement();
    }
    public bool IsWalking//让外界可以访问iswalking属性得到他是否在行走
    {
        get
        {
            return isWalking;
        }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        //HandleInteraction();
        selectedCounter?.Interact(this);
    }

    private void GameInput_OnOperateAction(object sender, System.EventArgs e)
    {
        selectedCounter?.InteractOperate(this);
    }
    private void HandleMovement()
    {
        Vector3 direction = gameInput.GetMovementDirectionNormalized();

        isWalking = direction != Vector3.zero;//如果移动就把isWalking设为true

        transform.position += direction * Time.deltaTime * moveSpeed;

        //让主角朝向跟移动方向保持一致
        if (direction != Vector3.zero)
        {
            //插值运算:让旋转没那么生硬,Slerp针对两个向量的插值运算，Lerp针对两个坐标的插值运算
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
        //print("1");
    }

    //处理交互的方法
    private void HandleInteraction()//只用来处理柜台的选择和取消选择的状态
    {
        //射线检测
        //RaycastHit hitinfo;//用来保存碰撞信息
        bool isCollide = Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f,counterLayerMask);//只会跟counter层射线检测
        if (isCollide)
        {
            if(hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))//判断物体是否是ClearCounter，如果是进行交互
            {
                //counter.Interact();
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);

            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    //提供一个方法用来设置被选中的Counter
    public void SetSelectedCounter(BaseCounter counter)
    {
        //判断counter是否发生改变
        if(counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();//把旧的取消选择,?判断当前对象是否为空，如果不为空才会调用后面的方法
            counter?.SelectedCounter();//把新的选择上

            this.selectedCounter = counter;

        }
    }
}

