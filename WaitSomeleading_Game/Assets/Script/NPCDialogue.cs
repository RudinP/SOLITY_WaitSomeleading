using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager theDM;

    [SerializeField]
    public bool talkRepeat = true;
    private bool talkOn = true;

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(talkOn)
        {
            theDM.ShowDialogue(dialogue);
            if (!talkRepeat)
                talkOn = false;
        }
    }
}
