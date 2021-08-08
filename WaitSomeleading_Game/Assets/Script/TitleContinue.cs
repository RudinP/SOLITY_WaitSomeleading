using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleContinue : MonoBehaviour
{
    private SaveLoad theSaveLoad;
    private Moving_Object thePlayer;
    private DestroyOnTitle theDestroy;

    void Start()
    {
        theSaveLoad = FindObjectOfType<SaveLoad>();
        thePlayer = FindObjectOfType<Moving_Object>();
        theDestroy = FindObjectOfType<DestroyOnTitle>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player_Anna")
        {
            thePlayer.callLoad = true;
            theSaveLoad.CallLoad();
            if(thePlayer.callLoad)
                theDestroy.Continue();
        }
    }
}
