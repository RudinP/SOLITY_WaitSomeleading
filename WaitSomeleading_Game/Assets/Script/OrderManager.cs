using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{

    private Moving_Object thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<Moving_Object>();
    }

    public void NotMove()
    {
        thePlayer.notMove = true;
    }

    public void Move()
    {
        thePlayer.notMove = false;
    }
}
