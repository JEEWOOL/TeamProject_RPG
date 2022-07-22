using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Data;
using HOGUS.Scripts.CustomSystem;

/// <summary>
/// ĳ���͵��� ���� ��Ʈ�ڽ�
/// </summary>
public class AttackCollision : MonoBehaviour
{
    private CombatSystem combatSystem;

    private void Start()
    {
        combatSystem = GetComponentInParent<CombatSystem>();
    }

    void OnEnable()
    {
        StartCoroutine("coDisable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            var targetStat = other.GetComponent<Stat>();

            if (combatSystem.CheckTargetHit(targetStat))
            {
                // targetStat.TakeDamage() ������ ����?
                Debug.Log("target Hitted");
            }
        }
    }

    private IEnumerator coDisable()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
