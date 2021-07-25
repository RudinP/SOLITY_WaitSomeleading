using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvin_Follow : MonoBehaviour
{
    private Vector2 distance;
    private Vector2 dir;
    static public Alvin_Follow instance2;
    public string currentMapName;

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
        Alvin.transform.position = Anna.transform.position;

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
        distance = Anna.transform.position-Alvin.transform.position;

        if (distance.x >= 1)
        {
            anim.SetBool("Walking", true);
            dir.x = 1;
            dir.y = 0;
            Alvin.transform.position = new Vector3(Alvin.transform.position.x + distance.x-1, Alvin.transform.position.y, 0);
            
        }
        else if (distance.x <= -1)
        {
            anim.SetBool("Walking", true);
            dir.x = -1;
            dir.y = 0;
            Alvin.transform.position = new Vector3(Alvin.transform.position.x + distance.x+1, Alvin.transform.position.y, 0);
        }
        else if (distance.y >= 1)
        {
            anim.SetBool("Walking", true);
            dir.x = 0;
            dir.y = 1;
            Alvin.transform.position = new Vector3(Alvin.transform.position.x, Alvin.transform.position.y + distance.y-1, 0);
            sprite.sortingOrder = 1;
        }
        else if (distance.y <= -1)
        {
            anim.SetBool("Walking", true);
            dir.x = 0;
            dir.y = -1;
            Alvin.transform.position = new Vector3(Alvin.transform.position.x, Alvin.transform.position.y + distance.y+1, 0);
            sprite.sortingOrder = -1;
        }
        else
        {
            anim.SetBool("Walking", false);

        }

        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);

    }
}
