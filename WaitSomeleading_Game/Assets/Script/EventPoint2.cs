using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPoint2 : MonoBehaviour
{
    public static EventPoint2 instance;

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
    private WaitForSeconds waitTime = new WaitForSeconds(0.5f);
    private bool flag;



    void Start()
    {
        theOrder = FindObjectOfType<OrderManager>();
        theDM = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flag && Input.GetKey(KeyCode.UpArrow))
        {
            flag = true;
            StartCoroutine(StartEvent2());
        }
    }

    IEnumerator StartEvent2()
    {
        // theOrder.NotMove();
        // yield return waitTime;

        theDM.ShowDialogue(dialogue1);
        yield return new WaitUntil(() => !theDM.talking);
        
        theDM.ShowDialogue(dialogue2);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogue3);
        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Down(2f);
        yield return new WaitUntil(() => !theOrder.doEvent);

        theDM.ShowDialogue(dialogue4);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogue5);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogue6);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Move();
    }
}
