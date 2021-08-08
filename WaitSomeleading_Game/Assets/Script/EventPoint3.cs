using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPoint3 : MonoBehaviour
{
    public static EventPoint3 instance;
    public static bool event3 = false;
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

    [SerializeField]
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;

    public GameObject TCarea; //타임캡슐 위치
    public GameObject Anna;
    public GameObject Alvin;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private TimeCapsuleManager theTCM;
    private FadeManager theFade;
    private Moving_Object thePlayer;

    private WaitForSeconds waitTime = new WaitForSeconds(0.5f);

    public bool eventOn = false; //true일 때 이벤트 실행 가능

    void Start()
    {
        theOrder = FindObjectOfType<OrderManager>();
        theTCM = FindObjectOfType<TimeCapsuleManager>();
        theDM = FindObjectOfType<DialogueManager>();
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<Moving_Object>();
        Anna = GameObject.Find("Player_Anna");
        Alvin = GameObject.Find("Player_Alvin");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(eventOn && thePlayer.currentMapName == "Village")
        {
            StartCoroutine(StartEvent3());
        }
    }

    IEnumerator StartEvent3()
    {
        eventOn = false;
        theOrder.NotMove();

        theFade.FadeOut();
        yield return waitTime;
        Anna.transform.position = new Vector3(-11, 4, 0);
        Alvin.transform.position = new Vector3(-10, 4, 0);
        yield return waitTime;
        theFade.FadeIn();
        yield return waitTime;
        yield return waitTime;

        theOrder.TurnLeft();
        theDM.ShowDialogue(dialogue1);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Left(1.0f);
        yield return new WaitUntil(() => !theOrder.doEvent);

        theOrder.Up(0.5f);
        yield return new WaitUntil(() => !theOrder.doEvent);

        theDM.ShowDialogue(dialogue2);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.TurnLeft();
        yield return waitTime;
        theOrder.TurnRight();
        yield return waitTime;
        theOrder.TurnUp();

        yield return new WaitForSeconds(2f);
        TCarea.SetActive(true);
        yield return waitTime;

        theDM.ShowDialogue(dialogue3);
        yield return new WaitUntil(() => !theDM.talking);

        yield return waitTime;
        theTCM.ShowTimeCapsule();
        yield return new WaitUntil(() => !theTCM.letter);

        yield return waitTime;
        theDM.ShowDialogue(dialogue4);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Left(2f);
        yield return new WaitUntil(() => !theOrder.doEvent);

        event3 = true;
        theOrder.Move();
    }
}
