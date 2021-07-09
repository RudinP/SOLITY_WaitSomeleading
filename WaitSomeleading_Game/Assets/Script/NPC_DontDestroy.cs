using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_DontDestroy : MonoBehaviour
{
    public static NPC_DontDestroy instance;
    public string MapName; //npc가 위치한 맵 이름
    public Moving_Object thePlayer;

    public GameObject[] NPC;

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

    public void TransferMap()
    {
        if (thePlayer.currentMapName == MapName)
        {
            for (int i = 0; i <= NPC.Length - 1; i++)
            {
                NPC[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i <= NPC.Length - 1; i++)
            {
                NPC[i].SetActive(false);
            }
        }
    }
}
