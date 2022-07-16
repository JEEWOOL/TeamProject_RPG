using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HOGUS.Scripts.Data;
using HOGUS.Scripts.Manager;
using HOGUS.Scripts.DP;

namespace HOGUS.Scripts.Character
{
    /// <summary>
    /// ĳ������ ���̽� Ŭ����
    /// </summary>
    public abstract class Character : MonoBehaviour, IUpdatableObject
    {
        public string Name;         // ĳ������ �̸�
        public Vector3 moveDir;     // ĳ������ �̵� ����

        // �⺻ �پ� ���� ������Ʈ
        #region Base Component
        protected Animator animator;  // ĳ������ �ִϸ�����
        protected Rigidbody rigid;    // ĳ������ rigidbody
        #endregion

        public StateMachine stateMachine;  // ���� �ӽ�

        #region IUpdatableObject Interface
        public void OnEnable()
        {
            ComponenetSet();
            UpdateManager.Instance.RegisterUpdatableObject(this);
        }

        public void OnDisable()
        {
            if(UpdateManager.Instance != null)
                UpdateManager.Instance.DeregisterUpdatableObject(this);
        }

        public abstract void OnFixedUpdate();
        public abstract void OnUpdate();
        public abstract void OnUpdate(float deltaTime);
        #endregion

        protected void ComponenetSet()
        {
            animator = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody>();
        }

        #region Base Function
        public abstract void Move();    // �̵� �Լ�
        #endregion
    }
}
