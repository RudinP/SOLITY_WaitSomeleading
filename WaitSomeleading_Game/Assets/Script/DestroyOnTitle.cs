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
    private Ending theEnding;
    private SpriteRenderer _sprite;
    private Color color;

    private bool ShowAlvin = true;

    void Start()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
        DestroyObject[0] = GameObject.Find("Player_Alvin");
        _sprite = DestroyObject[0].GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!DestroyObject[5])
        {
            DestroyObject[1] = GameObject.Find("VIllage_NPC");
            DestroyObject[2] = GameObject.Find("EventPoint3");
            DestroyObject[3] = GameObject.Find("EndPoint");
            DestroyObject[4] = GameObject.Find("event1");
            DestroyObject[5] = GameObject.Find("event2");
        }

        if (thePlayer.currentMapName == "Title2")
        {
            color = _sprite.color;
            color.a = 0.0f;
            _sprite.color = color;
        }
    }

    public void Delete()
    {
        for (int i = 1; i < DestroyObject.Length; i++)
        {
            Destroy(DestroyObject[i]);
        }

        StartCoroutine(ActiveAlvin());
    }

    public void Continue()
    {
        StartCoroutine(ActiveAlvin());
    }

    IEnumerator ActiveAlvin()
    {
        yield return new WaitForSeconds(1f);
        color = _sprite.color;
        color.a = 255;
        _sprite.color = color;
    }
}
