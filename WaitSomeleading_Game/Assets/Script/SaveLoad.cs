using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {

    [System.Serializable]
    public class Data
    {
        public float playerX;
        public float playerY;
        public float playerZ;

        public float AlvinX;
        public float AlvinY;
        public float AlvinZ;

        public float CameraX;
        public float CameraY;
        public float CameraZ;

        public string mapName;
        public string futureMapName; 
        public string futurefutureMapName; 

        //public bool eventSave1;
    }

    private Moving_Object thePlayer;
    private FadeManager theFade;
    private Alvin_Follow theAlvin;
    private CameraManager theCamera;
    public Data data;
    private Vector3 vector;


    public void CallSave()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
        theAlvin = FindObjectOfType<Alvin_Follow>();
        theCamera = FindObjectOfType<CameraManager>();

        data.playerX = thePlayer.transform.position.x;
        data.playerY = thePlayer.transform.position.y;
        data.playerZ = thePlayer.transform.position.z;

        data.AlvinX = theAlvin.transform.position.x;
        data.AlvinY = theAlvin.transform.position.y;
        data.AlvinZ = theAlvin.transform.position.z;

        data.CameraX = theCamera.transform.position.x;
        data.CameraY = theCamera.transform.position.y;
        data.CameraZ = theCamera.transform.position.z;

        data.mapName = thePlayer.currentMapName;
        data.futureMapName = thePlayer.futureMapName;
        data.futurefutureMapName = thePlayer.futurefutureMapName;

        //data.eventSave1 = EventPoint1.event1;

        Debug.Log("저장 성공");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");

        bf.Serialize(file, data);
        file.Close();

        Debug.Log(Application.dataPath + "의 위치에 저장했습니다.");

    }

    public void CallLoad()
    {
        thePlayer = FindObjectOfType<Moving_Object>();

        BinaryFormatter bf = new BinaryFormatter();
        string strFile = Application.dataPath + "/SaveFile.dat";
        FileInfo fileInfo = new FileInfo(strFile);

        if(!fileInfo.Exists)
        {
            Debug.Log("저장된 세이브 파일이 없습니다");
            thePlayer.callLoad = false;
        }

        else
        {
            FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);

            if (file != null && file.Length > 0)
            {
                data = (Data)bf.Deserialize(file);

                StartCoroutine(LoadCoroutine());
            }

            file.Close();
        }
    }

    IEnumerator LoadCoroutine()
    {
        
        thePlayer = FindObjectOfType<Moving_Object>();
        theFade = FindObjectOfType<FadeManager>();
        theAlvin = FindObjectOfType<Alvin_Follow>();
        theCamera = FindObjectOfType<CameraManager>();

        theFade.FadeOut();
        yield return new WaitForSeconds(1f);

        thePlayer.currentMapName = data.mapName;
        thePlayer.futureMapName = data.futureMapName;
        thePlayer.futurefutureMapName = data.futurefutureMapName;

        //EventPoint1.event1 = data.eventSave1;

        vector.Set(data.playerX, data.playerY, data.playerZ);
        thePlayer.transform.position = vector;

        theAlvin.transform.position = new Vector3(data.AlvinX, data.AlvinY, data.AlvinY);

        theCamera.transform.position = new Vector3(data.CameraX, data.CameraY, data.CameraZ);

        GameManager theGM = FindObjectOfType<GameManager>();
        theGM.LoadStart();

        SceneManager.LoadScene(data.mapName);
        theFade.FadeIn();

         Debug.Log("로드 성공");

        
    }
}
