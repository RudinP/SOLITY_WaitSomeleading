using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; 
    public string transferMapName; 

    public GameObject StartPoint0;
    public GameObject StartPoint1;
    public GameObject StartPoint2;
    public GameObject StartPoint3;
  
    private Moving_Object thePlayer;
    private CameraManager theCamera;


    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<Moving_Object>();

        StartPoint0 = GameObject.Find("StartPoint0");
        StartPoint1 = GameObject.Find("StartPoint1");
        StartPoint2 = GameObject.Find("StartPoint2");
        StartPoint3 = GameObject.Find("StartPoint3");

        if(thePlayer.futureMapName == "Village" && startPoint == thePlayer.currentMapName) 
        {
            theCamera.transform.position = new Vector3(StartPoint1.transform.position.x, StartPoint1.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint1.transform.position;
        }

        else if(thePlayer.futurefutureMapName == "Village" && thePlayer.futureMapName == "Forest_Field" && startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(StartPoint3.transform.position.x, StartPoint3.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint3.transform.position;
        }

        else if(thePlayer.futureMapName == "Forest_Field" && startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(StartPoint0.transform.position.x, StartPoint0.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint0.transform.position;
        }


        else if(thePlayer.futureMapName == "Cliff" && startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(StartPoint2.transform.position.x, StartPoint2.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint2.transform.position;
        }
    }

}
