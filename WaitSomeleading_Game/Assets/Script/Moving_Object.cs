using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Object : MonoBehaviour
{
    static public Moving_Object instance;
    public string currentMapName; // �̵��� �� �̸� ����

    private float moveSpeed = 3.0f;     //�̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero;   // �̵� ����


    void Start ()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);   /// ���߿� �ִϸ��̼��̳� boxcollider ���� ��ġ�� �־����!
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        // Negative left, a : -1
        // Positive right, d : -1
        // Non : 0
        float x = Input.GetAxisRaw("Horizontal");   //�¿� �̵�
        // Negative down, s : -1
        // Positive up, w : 1
        // non : 0
        float y = Input.GetAxisRaw("Vertical"); //���Ʒ� �̵�

        //�̵����� ����
        moveDirection = new Vector3(x, y, 0);

        //���ο� ��ġ= ���� ��ġ + (���� * �ӵ�)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
  