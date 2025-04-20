using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : KitchenObejctHolder
{
    public static Player Instance {  get; private set; }//����ģʽ
    //[SerializeField]���ֶο���������޸�
    //{get,set}������������
    [SerializeField] private float moveSpeed = 7;//�����ƶ��ٶ�
    [SerializeField] private float rotateSpeed = 10;//������ת�ٶ�
    [SerializeField] private GameInput gameInput;//Ϊ�˵���GetMovementDirectionNormalized����

    [SerializeField] private LayerMask counterLayerMask;//LayMask���������֣�counterLayMask�����ǹ�̨��һ�㣬�ǵ�ָ��counter��

    private bool isWalking = false;
    private BaseCounter selectedCounter;//ȥ�洢��ǰ��Counter

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
    //��������Ĵ��룬���������϶���Update����
    private void Update()
    {
        HandleInteraction();
    }
    

    //ֻҪ�漰��������λ�õ��޸ģ�������ת����λһ�����FixedUpdate��������ִ��Ƶ�ʸ�����ִ��Ƶ�ʱ���һ��
    private void FixedUpdate()
    {
        HandleMovement();
    }
    public bool IsWalking//�������Է���iswalking���Եõ����Ƿ�������
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

        isWalking = direction != Vector3.zero;//����ƶ��Ͱ�isWalking��Ϊtrue

        transform.position += direction * Time.deltaTime * moveSpeed;

        //�����ǳ�����ƶ����򱣳�һ��
        if (direction != Vector3.zero)
        {
            //��ֵ����:����תû��ô��Ӳ,Slerp������������Ĳ�ֵ���㣬Lerp�����������Ĳ�ֵ����
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
        //print("1");
    }

    //�������ķ���
    private void HandleInteraction()//ֻ���������̨��ѡ���ȡ��ѡ���״̬
    {
        //���߼��
        //RaycastHit hitinfo;//����������ײ��Ϣ
        bool isCollide = Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f,counterLayerMask);//ֻ���counter�����߼��
        if (isCollide)
        {
            if(hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))//�ж������Ƿ���ClearCounter������ǽ��н���
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

    //�ṩһ�������������ñ�ѡ�е�Counter
    public void SetSelectedCounter(BaseCounter counter)
    {
        //�ж�counter�Ƿ����ı�
        if(counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();//�Ѿɵ�ȡ��ѡ��,?�жϵ�ǰ�����Ƿ�Ϊ�գ������Ϊ�ղŻ���ú���ķ���
            counter?.SelectedCounter();//���µ�ѡ����

            this.selectedCounter = counter;

        }
    }
}

