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

    //플레이어 움직임 방지
    public void NotMove()
    {
        thePlayer.notMove = true;
        theAnim.notMove = true;
    }

    //플레이어 움직임 재개
    public void Move()
    {
        thePlayer.notMove = false;
        theAnim.notMove = false;
    }

    //위로 _time동안 이동
    public void Up(float _time)
    {
        doEvent = true;
        x = 0;
        y = 1;
        StartCoroutine(MoveDir(_time));
    }

    //아래로 _time동안 이동
    public void Down(float _time)
    {
        doEvent = true;
        x = 0;
        y = -1;
        StartCoroutine(MoveDir(_time));
    }

    //왼쪽으로 _time동안 이동
    public void Left(float _time)
    {
        doEvent = true;
        x = -1;
        y = 0;
        StartCoroutine(MoveDir(_time));
    }

    //오른쪽으로 _time동안 이동
    public void Right(float _time)
    {
        doEvent = true;
        x = 1;
        y = 0;
        StartCoroutine(MoveDir(_time));
    }

    //위쪽 주시
    public void TurnUp()
    {
        doEvent = true;
        x = 0;
        y = 1;
        doTurn();
    }

    //아래쪽 주시
    public void TurnDown()
    {
        doEvent = true;
        x = 0;
        y = -1;
        doTurn();
    }

    //좌측 주시
    public void TurnLeft()
    {
        doEvent = true;
        x = -1;
        y = 0;
        doTurn();
    }

    //우측 주시
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

        //플레이어 애니메이션 걷기 움직임 가능
        theAnim.eventOn = true;
        playerAnim.SetBool("Walking", true);
        playerAnim.SetFloat("x", x);
        playerAnim.SetFloat("y", y);

        //이벤트 시 플레이어 이동
        thePlayer.eventOn = true;

        yield return new WaitForSeconds(_time);

        playerAnim.SetBool("Walking", false);
        thePlayer.eventOn = false;
        theAnim.eventOn = false;

        doEvent = false;
    }
}
