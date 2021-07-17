using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public GameObject go; //Menu를 받는 변수

    private bool activated;//Menu의 on off 확인용 bool

    public void Exit()//종료
    {
        Application.Quit();
    }

    public void Continue()//계속
    {
        activated = false;
        go.SetActive(false);
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
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
        if(Input.GetKeyDown(KeyCode.Escape))//esc키 누르면 실행되도록
        {
            activated = !activated;
            if (activated)
            {
                go.SetActive(true);
            }
            else 
            {
                go.SetActive(false);
            }
        }
    }
}
