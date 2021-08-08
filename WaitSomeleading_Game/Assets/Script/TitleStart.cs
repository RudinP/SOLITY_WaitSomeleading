using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    private DestroyOnTitle theDestroy;

    void Start()
    {
        theDestroy = FindObjectOfType<DestroyOnTitle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventPoint1.flag = false;
        EventPoint2.flag = false;
        EventPoint3.eventOn = false;
        EventPoint3.TCA = false;
        theDestroy.Delete();
    }
}
