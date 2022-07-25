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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾�� ����� ���
        if(collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.GetCurrentStatus().TakeDamage(damage);       // �÷��̾ ������ ��ŭ�� �������� ����
            Debug.Log("Player Hit");
        }
    }
}
