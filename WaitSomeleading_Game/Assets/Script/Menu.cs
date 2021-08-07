using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public GameObject go; //Menu를 받는 변수

    private bool activated;//Menu의 on off 확인용 bool

    private FadeManager theFade;
    private Moving_Object thePlayer;
    private OrderManager theOrder;
    private SaveLoad theSaveLoad;

    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<Moving_Object>();
        theSaveLoad = FindObjectOfType<SaveLoad>();
    }

    public void Exit()//종료
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        Application.Quit();
    }

    public void Continue()//계속
    {
        activated = false;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        theOrder.Move();
        go.SetActive(false);
    }

    public void ToTitle()
    {
        StartCoroutine(TitleCoroutine());
    }

    public void Save()
    {
        theSaveLoad.CallSave();
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this; 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        theOrder = FindObjectOfType<OrderManager>();
        if (Input.GetKeyDown(KeyCode.Escape) && thePlayer.currentMapName != "Title2")//esc키 누르면 실행되도록
        {
            activated = !activated;
            if (activated && !thePlayer.notMove)
            {
                go.SetActive(true);
                theOrder.NotMove();
                Time.timeScale = 0.0f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
            else if (!activated && go)
            {
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                theOrder.Move();
                go.SetActive(false);
            }
            else
            {
                activated = !activated;
            }
        }
    }

    IEnumerator TitleCoroutine()
    {
        activated = false;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        go.SetActive(false);
        theFade.FadeOut();

        yield return new WaitForSeconds(1f);

        thePlayer.futurefutureMapName = thePlayer.futureMapName;
        thePlayer.futureMapName = thePlayer.currentMapName;
        thePlayer.currentMapName = "Title2";

        SceneManager.LoadScene("Title2");
        theFade.FadeIn();
        theOrder.Move();
    }
}
