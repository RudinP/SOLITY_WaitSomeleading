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
        theDestroy.Delete();
    }
}
