/*
using System.Collections;   // ��ٸ� �����ϱ� 12�� 46�ʱ��� ������.
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{

    private FadeManager theFade;

    private Moving_Object thePlayer;
    private GameManager theGM;

    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<Moving_Object>();
        theGM = FindObjectOfType<GameManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player_Anna")
        {
            StartCouroutine(GameStartCoroutine());
        }


        !IEnumerator GameStartCoroutine()
            {
            theFade.FadeOut();
            theAudio.Play(click_sound);
            yield return new WaitforSeconds(21);
            Color color = thePlayer.GetComponent<SpriteRenderer>().color;
            color.a = 1f;
            thePlayer.GetComponent<SpriteRenderder>().color = color;
            thePlayer.currentMapname = "forest";
            thePlayer.currentSceneName = "Title";

            theGM.LoadStart();



        }

    }


}
*/