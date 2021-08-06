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

        
        public string mapName;
        public string futureMapName; 
        public string futurefutureMapName; 

        //public bool eventSave1;
    }

    private Moving_Object thePlayer;
    private FadeManager theFade;
    public Data data;
    private Vector3 vector;


    public void CallSave()
    {
        thePlayer = FindObjectOfType<Moving_Object>();

        data.playerX = thePlayer.transform.position.x;
        data.playerY = thePlayer.transform.position.y;
        data.playerZ = thePlayer.transform.position.z;

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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);

        if(file != null && file.Length > 0)
        {
            data = (Data)bf.Deserialize(file);

            StartCoroutine(LoadCoroutine());
        }
        else
        {
            Debug.Log("저장된 세이브 파일이 없습니다");
        }

        file.Close();
    }

    IEnumerator LoadCoroutine()
    {
        
        thePlayer = FindObjectOfType<Moving_Object>();
        theFade = FindObjectOfType<FadeManager>();

        theFade.FadeOut();
        yield return new WaitForSeconds(1f);

        thePlayer.currentMapName = data.mapName;
        thePlayer.futureMapName = data.futureMapName;
        thePlayer.futurefutureMapName = data.futurefutureMapName;

        //EventPoint1.event1 = data.eventSave1;

        vector.Set(data.playerX, data.playerY, data.playerZ);
        thePlayer.transform.position = vector;

        GameManager theGM = FindObjectOfType<GameManager>();
        theGM.LoadStart();

        SceneManager.LoadScene(data.mapName);
        theFade.FadeIn();

         Debug.Log("로드 성공");

        
    }
}
