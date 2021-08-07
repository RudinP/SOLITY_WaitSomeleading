using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleContinue : MonoBehaviour
{
    private SaveLoad theSaveLoad;
    private Moving_Object thePlayer;

    void Start()
    {
        theSaveLoad = FindObjectOfType<SaveLoad>();
        thePlayer = FindObjectOfType<Moving_Object>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player_Anna")
        {
            thePlayer.callLoad = true;
            theSaveLoad.CallLoad();
        }
    }
}
