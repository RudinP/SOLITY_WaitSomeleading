using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public GameObject go; //Menu�� �޴� ����

    private bool activated;//Menu�� on off Ȯ�ο� bool

    public void Exit()//����
    {
        Application.Quit();
    }

    public void Continue()//���
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
        if(Input.GetKeyDown(KeyCode.Escape))//escŰ ������ ����ǵ���
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
