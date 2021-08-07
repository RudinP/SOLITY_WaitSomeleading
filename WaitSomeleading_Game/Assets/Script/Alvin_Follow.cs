using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvin_Follow : MonoBehaviour
{
    private Vector2 distance;
    private Vector2 dir;
    static public Alvin_Follow instance2;
    public string currentMapName;
    private Moving_Object thePlayer;

    GameObject Anna;
    GameObject Alvin;
    Animator anim;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Anna = GameObject.Find("Player_Anna");
        Alvin = GameObject.Find("Player_Alvin");
        sprite = GetComponent<SpriteRenderer>();
        Alvin.transform.position = new Vector3(Anna.transform.position.x - 1, Anna.transform.position.y, 0);
        thePlayer = FindObjectOfType<Moving_Object>();

        if (instance2 == null)
        {
            DontDestroyOnLoad(this.gameObject);   /// 나중에 애니메이션이나 boxcollider 여기 위치에 넣어야함!
            instance2 = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(thePlayer.currentMapName != currentMapName)
        {
            Alvin.transform.position = new Vector3(Anna.transform.position.x + 1, Anna.transform.position.y, 0);
            currentMapName = thePlayer.currentMapName;
        }

        else
        {
            distance = Anna.transform.position - Alvin.transform.position;

            if (distance.y > 0)
            {
                sprite.sortingOrder = 1;
            }

            else
            {
                sprite.sortingOrder = -1;
            }

            if (distance.x > 1 || distance.x < -1 || distance.y > 1 || distance.y < -1)
            {
                anim.SetBool("Walk", true);

                if (distance.y > 1)
                {
                    dir.x = 0;
                    dir.y = 1;

                    anim.SetFloat("x", dir.x);
                    anim.SetFloat("y", dir.y);

                    Alvin.transform.position += new Vector3(dir.x, dir.y, 0) * 3.0f * Time.deltaTime;
                }
                if (distance.y < -1)
                {
                    dir.x = 0;
                    dir.y = -1;

                    anim.SetFloat("x", dir.x);
                    anim.SetFloat("y", dir.y);

                    Alvin.transform.position += new Vector3(dir.x, dir.y, 0) * 3.0f * Time.deltaTime;
                }

                if (distance.x > 1)
                {
                    dir.x = 1;
                    dir.y = 0;
                    anim.SetFloat("x", dir.x);
                    anim.SetFloat("y", dir.y);

                    Alvin.transform.position += new Vector3(dir.x, dir.y, 0) * 3.0f * Time.deltaTime;
                }
                if (distance.x < -1)
                {
                    dir.x = -1;
                    dir.y = 0;
                    anim.SetFloat("x", dir.x);
                    anim.SetFloat("y", dir.y);

                    Alvin.transform.position += new Vector3(dir.x, dir.y, 0) * 3.0f * Time.deltaTime;
                }
            }

            else
            {

                anim.SetBool("Walk", false);

            }
        }
    }
}


