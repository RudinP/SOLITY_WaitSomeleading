using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap2 : MonoBehaviour
{
    public string transferMapName; 

    private Moving_Object thePlayer;
    private NPC_DontDestroy theNPCDont;                           

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
        theNPCDont = FindObjectOfType<NPC_DontDestroy>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player_Anna")
        {
            thePlayer.currentMapName = transferMapName;
            theNPCDont.TransferMap();
            SceneManager.LoadScene(transferMapName);
        }
    }
     

}
