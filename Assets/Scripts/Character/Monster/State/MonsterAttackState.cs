using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Enums;
using HOGUS.Scripts.Interface;
using HOGUS.Scripts.Character;

namespace HOGUS.Scripts.State
{
    public class MonsterAttackState : IState
    {
        private readonly MonsterBase monster;
        public MonsterAttackState(MonsterBase monster)
        {
            this.monster = monster;
        }

        public void StateEnter()
        {
            Debug.Log("���� ���� ����");
        }

        public void StateExit()
        {
            Debug.Log("���� ���� ���� ����");
        }

        public void StateFixedUpdate()
        {            
        }

        public void StateUpdate()
        {
            
        }
    }
}