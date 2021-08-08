using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPoint2 : MonoBehaviour
{
    public static EventPoint2 instance;
    public static bool event2 = false;

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
    
    private DialogueManager theDM;
    private OrderManager theOrder;
    private EventPoint3 theEvent3;
    private Moving_Object thePlayer;
    private WaitForSeconds waitTime = new WaitForSeconds(0.5f);
    private bool flag;



    void Start()
    {
        theOrder = FindObjectOfType<OrderManager>();
        theDM = FindObjectOfType<DialogueManager>();
        theEvent3 = FindObjectOfType<EventPoint3>();
        thePlayer = FindObjectOfType<Moving_Object>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flag && Input.GetKey(KeyCode.UpArrow) && thePlayer.currentMapName == "Cliff")
        {
            flag = true;
            StartCoroutine(StartEvent2());
        }
    }

    IEnumerator StartEvent2()
    {
        theOrder.NotMove();
        yield return waitTime;

        theDM.ShowDialogue(dialogue1);
        yield return new WaitUntil(() => !theDM.talking);
        
        theDM.ShowDialogue(dialogue2);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogue3);
        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Right(1f);
        yield return new WaitUntil(() => !theOrder.doEvent);
        theOrder.Down(2f);
        yield return new WaitUntil(() => !theOrder.doEvent);

        theDM.ShowDialogue(dialogue4);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogue5);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogue6);
        yield return new WaitUntil(() => !theDM.talking);

        event2 = true;
        theEvent3.eventOn = true;
        theOrder.Move();
    }
}
