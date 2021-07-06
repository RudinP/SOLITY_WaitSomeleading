using UnityEngine;

public class Moving_Object : MonoBehaviour
{
    private float moveSpeed = 3.0f;     //�̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero;   // �̵� ����

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
  