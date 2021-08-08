using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName; 

    private Moving_Object thePlayer;
    private FadeManager theFade;
    private BGM_Manager theBGM;
    private OrderManager theOrder;

    void Start()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
        theFade = FindObjectOfType<FadeManager>();
        theBGM = FindObjectOfType<BGM_Manager>();
        theOrder = FindObjectOfType<OrderManager>();
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
        theOrder.NotMove();
        theFade.FadeOut();
        theBGM.FadeOutMusic();
        yield return new WaitForSeconds(1.5f);

        thePlayer.futurefutureMapName = thePlayer.futureMapName;
        thePlayer.futureMapName = thePlayer.currentMapName;
        thePlayer.currentMapName = transferMapName;

        SceneManager.LoadScene(transferMapName);

        theFade.FadeIn();
    }

}
