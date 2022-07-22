using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ���͵��� ���� ��Ʈ�ڽ�
/// </summary>
public class AttackCollision : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine("coDisable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Hit ENEMY");
        }
    }

    private IEnumerator coDisable()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
