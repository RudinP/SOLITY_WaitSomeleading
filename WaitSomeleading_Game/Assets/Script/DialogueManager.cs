using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

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

    public Text text; //��ȭ �ؽ�Ʈ
    public Text Name; //�̸�

    private List<string> listSentences;
    private List<string> listNames;

    private int count; // ��ȭ ���� ��Ȳ ī��Ʈ

    public bool talking = false;
    private bool keyActivated = false;

    public GameObject DPanel;
    private Animator panelAnimator;

    void Start()
    {
        count = 0;
        text.text = "";
        Name.text = "";
        listSentences = new List<string>();
        listNames = new List<string>();
        panelAnimator = DPanel.GetComponent<Animator>();
    }

    public void ShowDialogue(Dialogue dialogue) // ��ȭ ���
    {
        if(!talking)
        {
            talking = true;

            for (int i = 0; i < dialogue.sentences.Length; i++)
            {
                listSentences.Add(dialogue.sentences[i]);
                listNames.Add(dialogue.name[i]);
            }

            StartCoroutine(StartDialogueCoroutine());
        }        
    }

    public void ExitDialogue() // ��ȭ ����
    {
        text.text = "";
        Name.text = "";
        count = 0;
        listSentences.Clear();
        listNames.Clear();
        talking = false;
    }

    IEnumerator StartDialogueCoroutine()
    {
        Name.text = listNames[count];
        keyActivated = true;
        panelAnimator.SetBool("Appear", true);
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i]; // 1���ھ� ���
            yield return new WaitForSeconds(0.01f);
        }
    }

    void Update()
    {
        if (talking && keyActivated)
        {
            if (Input.GetKeyDown(KeyCode.Z)) // zŰ �Է½� ���� ��� ���
            {
                keyActivated = false;
                count++;
                text.text = "";
                Name.text = "";

                if (count == listSentences.Count)
                {
                    StopAllCoroutines();
                    panelAnimator.SetBool("Appear", false);
                    ExitDialogue();
                }

                else
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            }
        }
    }
}
