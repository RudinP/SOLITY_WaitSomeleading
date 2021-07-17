using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Object : MonoBehaviour
{
    static public Moving_Object instance;
    public string currentMapName; // 이동할 맵 이름 저장

    private float moveSpeed = 3.0f;     //이동 속도
    private Vector3 moveDirection = Vector3.zero;   // 이동 방향

    public bool notMove = false;


    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);   /// 나중에 애니메이션이나 boxcollider 여기 위치에 넣어야함!
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (!notMove)
        {
            // Negative left, a : -1
            // Positive right, d : -1
            // Non : 0
            float x = Input.GetAxisRaw("Horizontal");   //좌우 이동
                                                        // Negative down, s : -1
                                                        // Positive up, w : 1
                                                        // non : 0
            float y = Input.GetAxisRaw("Vertical"); //위아래 이동

            //이동방향 설정
            moveDirection = new Vector3(x, y, 0);

            //새로운 위치= 현재 위치 + (방향 * 속도)
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
