using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

    public Dialogue[] dialogues;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private WaitForSeconds waitTime = new WaitForSeconds(0.5f);

    private bool endCheck = false;

    static public Ending instance2;
    public GameObject Alvin;
    public GameObject Anna;
    public GameObject RememberPanel;
    public GameObject Black;

    bool EndCheck()
    {
        if (EventPoint1.event1 && EventPoint2.event2 && EventPoint3.event3)
            return true;
        else
            return false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance2 == null)
        {
            DontDestroyOnLoad(this.gameObject);   
            instance2 = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        theOrder = FindObjectOfType<OrderManager>();
        theDM = FindObjectOfType<DialogueManager>();
        //endCheck = EndCheck();
        endCheck = true;
        Alvin = GameObject.Find("Player_Alvin");
        Anna = GameObject.Find("Player_Anna");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EndCheck())
        {
            StartCoroutine(StartEnding());
        }
    }

    // Update is called once per frame
    IEnumerator StartEnding()
    {
        //SceneManager.LoadScene("Forest_Field");
        //GameObject ChildA = GameObject.Find("ChildA");
        //GameObject ChildB = GameObject.Find("ChildB");
        //ChildA.SetActive(false);
        //ChildB.SetActive(false);

        theOrder.NotMove();
        yield return waitTime;

        Black.SetActive(true);
        yield return waitTime;

        CameraManager camera = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        camera.SetBound(GameObject.Find("bound_Cliff").GetComponent<BoxCollider2D>());

        Alvin.transform.position = new Vector3(44,-10, 2);
        Anna.transform.position = new Vector3(46,-10,2);
        Black.SetActive(false);
        RememberPanel.SetActive(true);
        yield return waitTime;

        theOrder.TurnLeft();
        yield return waitTime;

        theDM.ShowDialogue(dialogues[0]);
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Left(1.0f);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[1]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[2]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[3]);
        yield return new WaitUntil(() => !theDM.talking);


        Black.SetActive(true);
        yield return waitTime;

        Alvin.transform.position = new Vector3(56, -19, 1);
        Anna.transform.position = new Vector3(57, -19, 1);

        Black.SetActive(false);
        yield return waitTime;


        theDM.ShowDialogue(dialogues[4]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[5]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[6]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[7]);
        theOrder.Left(1.0f);
        yield return new WaitUntil(() => !theDM.talking);
        Black.SetActive(true);
        yield return waitTime;
        Alvin.SetActive(false);
        Black.SetActive(false);
        yield return waitTime;

        RememberPanel.SetActive(false);
        Black.SetActive(true);
        yield return waitTime;


        Alvin.SetActive(false);

        camera.SetBound(GameObject.Find("bound_Village").GetComponent<BoxCollider2D>());
        Anna.transform.position = new Vector3(-21, 6, 0);
        Black.SetActive(false);
        yield return waitTime;

        theDM.ShowDialogue(dialogues[8]);
        yield return new WaitUntil(() => !theDM.talking);


        //SceneManager.LoadScene("Village");
        

        theDM.ShowDialogue(dialogues[9]);
        yield return new WaitUntil(() => !theDM.talking);

        RememberPanel.SetActive(true);

        Black.SetActive(true);
        yield return waitTime;

        Anna.transform.position = new Vector3(-7, -10, 1);
        Black.SetActive(false);

        theDM.ShowDialogue(dialogues[10]);
        yield return new WaitUntil(() => !theDM.talking);

        


        theDM.ShowDialogue(dialogues[11]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[12]);
        yield return new WaitUntil(() => !theDM.talking);

        Black.SetActive(true);
        yield return waitTime;

        RememberPanel.SetActive(false);


        Anna.transform.position = new Vector3(-21, 6, 0);
        Black.SetActive(false);
        yield return waitTime;

        theDM.ShowDialogue(dialogues[13]);
        yield return new WaitUntil(() => !theDM.talking);


        

        theDM.ShowDialogue(dialogues[14]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[15]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[16]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[17]);
        yield return new WaitUntil(() => !theDM.talking);

        theDM.ShowDialogue(dialogues[18]);
        yield return new WaitUntil(() => !theDM.talking);




        endCheck = false;
        theOrder.Move();
    }
}
