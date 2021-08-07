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
    public GameObject StartPoint4;
    public GameObject StartPoint5;

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
        StartPoint4 = GameObject.Find("StartPoint4");
        StartPoint5 = GameObject.Find("StartPoint5");

        if (thePlayer.callLoad)
        {
            thePlayer.callLoad = false;
        }

        else
        {
            SetStartPoint();
        }

    }

    public void SetStartPoint()
    {
        if (thePlayer.currentMapName == "Title2")
        {
            thePlayer.transform.position = StartPoint4.transform.position;
        }

        else if (thePlayer.futureMapName == "Village" && startPoint == thePlayer.currentMapName) 
        {
            theCamera.transform.position = new Vector3(StartPoint1.transform.position.x, StartPoint1.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint1.transform.position;
        }

        else if(thePlayer.futureMapName == "Forest_Field" && startPoint == thePlayer.currentMapName && thePlayer.currentMapName == "Cliff")
        {
            theCamera.transform.position = new Vector3(StartPoint3.transform.position.x, StartPoint3.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint3.transform.position;
        }

        else if(thePlayer.futureMapName == "Forest_Field" && startPoint == thePlayer.currentMapName && thePlayer.currentMapName == "Village")
        {
            theCamera.transform.position = new Vector3(StartPoint0.transform.position.x, StartPoint0.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint0.transform.position;
        }


        else if(thePlayer.futureMapName == "Cliff" && startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(StartPoint2.transform.position.x, StartPoint2.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint2.transform.position;
        }

        else if (thePlayer.futureMapName == "Title2" && thePlayer.currentMapName == "Village")
        {
            theCamera.transform.position = new Vector3(StartPoint5.transform.position.x, StartPoint5.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = StartPoint5.transform.position;
        }
    }

}
