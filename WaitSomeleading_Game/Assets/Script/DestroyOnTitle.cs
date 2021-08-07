using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTitle : MonoBehaviour
{
    public static DestroyOnTitle instance;

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

    [SerializeField]
    GameObject[] DestroyObject;

    private Moving_Object thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
    }

    void Update()
    {
        if(!DestroyObject[5])
        {
            DestroyObject[0] = GameObject.Find("Player_Alvin");
            DestroyObject[1] = GameObject.Find("VIllage_NPC");
            DestroyObject[2] = GameObject.Find("EventPoint3");
            DestroyObject[3] = GameObject.Find("EndPoint");
            DestroyObject[4] = GameObject.Find("event1");
            DestroyObject[5] = GameObject.Find("event2");
        }

        if(thePlayer.currentMapName == "Title2")
        {
            for(int i = 0; i < DestroyObject.Length; i++)
            {
                Destroy(DestroyObject[i]);
            }
        }
    }
}
