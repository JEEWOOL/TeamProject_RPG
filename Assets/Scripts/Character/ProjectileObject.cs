using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Character;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileObject : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;         // �ش� ����ü�� �ӵ�
    public int damage;          // �ش� ����ü�� ���ݷ� ������ �� ����
    public int lifeTime;
    public Vector3 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        rb.AddForce(dir * speed, ForceMode.Impulse);

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� ����� ���
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            var player = other.gameObject.GetComponent<Player>();
            player.Damaged(damage);       // �÷��̾ ������ ��ŭ�� �������� ����
            Destroy(gameObject);
        }

        Debug.Log(other.gameObject.name + " " + other.gameObject.tag);
    }
}
