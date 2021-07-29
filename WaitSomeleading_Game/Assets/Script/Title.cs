/*
using System.Collections;   // 쯔꾸르 제작하기 12분 46초까지 따라함.
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{

    private FadeManager theFade;

    private PlayerManager thePlayer;
    private GameManager theGM;



    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
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