using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Interface;

namespace HOGUS.Scripts.DP
{
    public class Enemy : MonoBehaviour
    {
        private enum EnemyState
        {
            Idle,
            Move,
            Attack,
            Damaged,
            Die
        }

        private StateMachine stateMachine;
        //���� ����
        private Dictionary<EnemyState, IState> dicState = new Dictionary<EnemyState, IState>();

        private void Start()
        {
            // ���� ����
            IState idle = new StateIdle();
            IState move = new StateMove();
            IState die = new StateDie();

            // ��ųʸ��� ����
            dicState.Add(EnemyState.Idle, idle);
            dicState.Add(EnemyState.Move, move);
            dicState.Add(EnemyState.Die, die);

            stateMachine = new StateMachine(idle);
        }

        private void Update()
        {
            // �������� �����ؾ��ϴ� ���� ȣ��
            stateMachine.DoStateUpdate();
            
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                stateMachine.SetState(dicState[EnemyState.Die]);
            }
        }
    }
}