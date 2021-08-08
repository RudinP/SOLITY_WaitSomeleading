using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPoint1 : MonoBehaviour
{
    public static EventPoint1 instance;

    public static bool event1 = false;

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
    public Dialogue dialogue5;
    public Dialogue dialogue6;
    public Dialogue dialogue7;
    public Dialogue dialogue8;
    private DialogueManager theDM;
    private OrderManager theOrder;
    private Moving_Object thePlayer;
    private WaitForSeconds waitTime = new WaitForSeconds(0.5f);
    private bool flag;


    
    void Start()
    {
        theOrder = FindObjectOfType<OrderManager>();
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<Moving_Object>();
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!flag && Input.GetKey(KeyCode.UpArrow) && thePlayer.currentMapName == "Forest_Field")
        {
            flag = true;
            StartCoroutine(StartEvent3());
        }
    }

    IEnumerator StartEvent3()
    {
        theOrder.NotMove();
        yield return waitTime;

        theOrder.TurnLeft();
        theDM.ShowDialogue(dialogue1);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Left(2f);
        yield return new WaitUntil(() => !theOrder.doEvent);
        theOrder.Down(0.5f);
        yield return new WaitUntil(() => !theOrder.doEvent);
        theOrder.TurnDown();
        

        theDM.ShowDialogue(dialogue2);
        yield return new WaitUntil(() => !theDM.talking);
        theDM.ShowDialogue(dialogue3);
        yield return new WaitUntil(() => !theDM.talking);


        theDM.ShowDialogue(dialogue4);
        yield return new WaitUntil(() => !theDM.talking);
        theDM.ShowDialogue(dialogue5);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.TurnLeft();
        theDM.ShowDialogue(dialogue6);
        yield return new WaitUntil(() => !theDM.talking);
        theDM.ShowDialogue(dialogue7);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Left(1f);
        yield return new WaitUntil(() => !theOrder.doEvent);

        theDM.ShowDialogue(dialogue8);
        yield return new WaitUntil(() => !theDM.talking);

        event1 = true;
        theOrder.Move();
    }
}
