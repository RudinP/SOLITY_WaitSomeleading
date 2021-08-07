using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion Singleton

    private Moving_Object thePlayer;
    private Mover theAnim;

    private float x;
    private float y;

    public GameObject player;
    public Animator playerAnim;

    public bool doEvent = false;

    void Start()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
        theAnim = FindObjectOfType<Mover>();
        player = GameObject.Find("Player_Anna");
        playerAnim = player.GetComponent<Animator>();
    }

    //�÷��̾� ������ ����
    public void NotMove()
    {
        thePlayer.notMove = true;
        theAnim.notMove = true;
    }

    //�÷��̾� ������ �簳
    public void Move()
    {
        thePlayer.notMove = false;
        theAnim.notMove = false;
    }

    //���� _time���� �̵�
    public void Up(float _time)
    {
        doEvent = true;
        x = 0;
        y = 1;
        StartCoroutine(MoveDir(_time));
    }

    //�Ʒ��� _time���� �̵�
    public void Down(float _time)
    {
        doEvent = true;
        x = 0;
        y = -1;
        StartCoroutine(MoveDir(_time));
    }

    //�������� _time���� �̵�
    public void Left(float _time)
    {
        doEvent = true;
        x = -1;
        y = 0;
        StartCoroutine(MoveDir(_time));
    }

    //���������� _time���� �̵�
    public void Right(float _time)
    {
        doEvent = true;
        x = 1;
        y = 0;
        StartCoroutine(MoveDir(_time));
    }

    //���� �ֽ�
    public void TurnUp()
    {
        doEvent = true;
        x = 0;
        y = 1;
        doTurn();
    }

    //�Ʒ��� �ֽ�
    public void TurnDown()
    {
        doEvent = true;
        x = 0;
        y = -1;
        doTurn();
    }

    //���� �ֽ�
    public void TurnLeft()
    {
        doEvent = true;
        x = -1;
        y = 0;
        doTurn();
    }

    //���� �ֽ�
    public void TurnRight()
    {
        doEvent = true;
        x = 1;
        y = 0;
        doTurn();
    }

    private void doTurn()
    {
        playerAnim.SetFloat("x", x);
        playerAnim.SetFloat("y", y);
    }


    IEnumerator MoveDir(float _time)
    {
        thePlayer.moveDirection = new Vector3(x, y, 0);

        //�÷��̾� �ִϸ��̼� �ȱ� ������ ����
        theAnim.eventOn = true;
        playerAnim.SetBool("Walking", true);
        playerAnim.SetFloat("x", x);
        playerAnim.SetFloat("y", y);

        //�̺�Ʈ �� �÷��̾� �̵�
        thePlayer.eventOn = true;

        yield return new WaitForSeconds(_time);

        playerAnim.SetBool("Walking", false);
        thePlayer.eventOn = false;
        theAnim.eventOn = false;

        doEvent = false;
    }
}
