using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCapsuleManager : MonoBehaviour
{
    public static TimeCapsuleManager instance;

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

    public GameObject TimePanel;
    public GameObject TimeText;

    public Animator animPanel;
    public Animator animText;

    public bool letter = false;

    public void ShowTimeCapsule()
    {
        letter = true;
        TimePanel.SetActive(true);
        TimeText.SetActive(true);
        StartCoroutine(StartTimeCapsuleCoroutine());
    }

    IEnumerator StartTimeCapsuleCoroutine()
    {
        animPanel.SetBool("Appear", true);
        yield return new WaitForSeconds(0.2f);
        animText.SetBool("Appear", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && letter)
        {
            animPanel.SetBool("Appear", false);
            animText.SetBool("Appear", false);
            StopAllCoroutines();
            letter = false;
        }
    }
}
