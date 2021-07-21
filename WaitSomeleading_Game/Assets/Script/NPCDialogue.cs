using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager theDM;
    private OrderManager theOrder;

    [SerializeField]
    public bool talkRepeat = true;
    private bool talkOn = true;

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder = FindObjectOfType<OrderManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(talkOn)
        {
            theOrder.NotMove();
            theDM.ShowDialogue(dialogue);
            if (!talkRepeat)
                talkOn = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitUntil(() => !theDM.talking);
        theOrder.Move();
    }
}
