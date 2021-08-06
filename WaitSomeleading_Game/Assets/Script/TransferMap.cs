using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName; 

    private Moving_Object thePlayer;
    private FadeManager theFade;
    private NPC_DontDestroy theNPCDont;                           

    void Start()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
        theNPCDont = FindObjectOfType<NPC_DontDestroy>();
        theFade = FindObjectOfType<FadeManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player_Anna")
        {
          StartCoroutine(TransferCoroutine());
        }
    }
     
     IEnumerator TransferCoroutine()
     {
        theFade.FadeOut();
        yield return new WaitForSeconds(1f);

        thePlayer.futurefutureMapName = thePlayer.futureMapName;
        thePlayer.futureMapName = thePlayer.currentMapName;
        thePlayer.currentMapName = transferMapName;
        
        theNPCDont.TransferMap();
        SceneManager.LoadScene(transferMapName);
        theFade.FadeIn();

     }

}
