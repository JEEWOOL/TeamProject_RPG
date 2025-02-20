using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using HOGUS.Scripts.Enums;
using HOGUS.Scripts.State;
using HOGUS.Scripts.Data;
using HOGUS.Scripts.DP;
using HOGUS.Scripts.Interface;


namespace HOGUS.Scripts.Character
{
    public class MonsterBase : Character
    {
        private bool isLooking = false;

        public UnityEngine.Events.UnityEvent onDead;
        public UIManager uIManager;
        public QuestManager questManager;

        public bool IsLooking { get { return isLooking; } set { isLooking = value; } }

        public float targetRadius = 0f;
        public float targetRange = 0f;
        public float targetDistance = 0f;

        public float attackCooltime = 2f;

        public readonly Dictionary<EnemyState, IState> dicState = new Dictionary<EnemyState, IState>();

        public EnemyType enemyType;
        public Stat baseStat;
        Stat currentStat;
        public Player player;
        public Transform targetTr;
        public Transform floatingDamageTr;
        public NavMeshAgent monsterAgent;
        public MeshRenderer[] meshes;
        public GameObject damageText;
        public GameObject dropItem;
        public GameObject weaponGO;
        public GameObject fireballGO;

        public GameObject HPBarPrefab;
        private GameObject hpBar;
        public Vector3 HPBarOffset = new Vector3(0f, 2.5f, 0f);

        private Canvas enemyHPBarCanvas;
        private Slider enemyHPBarSlider;
        private EnemyHP_Bar bar;

        private void Start()
        {
            var state_Idle = new MonsterIdleState(this);
            var state_Chase = new MonsterChaseState(this);
            var state_Attack = new MonsterAttackState(this);

            dicState.Add(EnemyState.Idle, state_Idle);
            dicState.Add(EnemyState.Chase, state_Chase);
            dicState.Add(EnemyState.Attack, state_Attack);

            stateMachine = new StateMachine(state_Idle);
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
            //targetTr = player.gameObject.GetComponent<Transform>();
            targetTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
            monsterAgent = GetComponent<NavMeshAgent>();
            meshes = GetComponentsInChildren<MeshRenderer>();

            currentStat = Instantiate(baseStat);

            monsterAgent.speed = currentStat.Speed;

            SetHPBar();
        }

        public Stat GetCurrentStat()
        {
            return currentStat;
        }

        private void SetHPBar()
        {
            enemyHPBarCanvas = GameObject.Find("HPCanvas").GetComponent<Canvas>();
            if(hpBar == null)
                hpBar = Instantiate<GameObject>(HPBarPrefab, enemyHPBarCanvas.transform);
            enemyHPBarSlider = hpBar.GetComponentInChildren<Slider>();

            bar = hpBar.GetComponent<EnemyHP_Bar>();
            bar.enemyTr = this.gameObject.transform;
            bar.offset = HPBarOffset;  
        }

        public override void Attack()
        {
            if(enemyType == EnemyType.MagicMonster && !IsDead)
            {
                // fireballGO 소환
                GameObject InstantSpell = Instantiate(fireballGO, weaponGO.transform.position, weaponGO.transform.rotation);
                InstantSpell.GetComponent<ProjectileObject>().dir = (targetTr.position - transform.position).normalized;
            }
        }

        IEnumerator coAttack(float cooltime)
        {
            yield return new WaitForSeconds(cooltime);
        }

        readonly float destroyTime = 3f;
        public override void Die()
        {
            IsDead = true;
            onDead.Invoke();
            player.GetCurrentStatus().CurrentEXP += currentStat.KillEXP;
            bar.enabled = false;
            animator.SetTrigger("DoDie");

            var dropItemGO = Instantiate<GameObject>(dropItem);
            dropItemGO.transform.position = transform.position;

            Destroy(hpBar);
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, destroyTime);
        }

        public override void Damaged(int damage)
        {
            StartCoroutine(OnDamageFlickering());

            currentStat.TakeDamage(damage);

            GameObject damageTextGO = Instantiate(damageText);
            damageTextGO.transform.position = floatingDamageTr.position;
            damageTextGO.GetComponent<TextMesh>().text = damage.ToString();

            enemyHPBarSlider.value = bar.UpdateGage(currentStat.CurHP, currentStat.MaxHP);
            if (currentStat.CurHP == 0)
            {                
                Die();
            }

            Debug.Log(currentStat.CurHP);
        }

        public override void OnFixedUpdate(float deltaTime)
        {
            Targeting(deltaTime);

            stateMachine.DoStateFixedUpdate();
        }

        public override void OnUpdate(float deltaTime)
        {
            stateMachine.DoStateUpdate();
        }

        public void LookTarget(float deltaTime)
        {
            IsLooking = true;
            Vector3 direction = (targetTr.position - transform.position).normalized;
            Quaternion lookAt = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, deltaTime * 5f);
        }

        // NavMeshAgent의 이동을 rigid의 물리력이 방해하는 것을 멈추기 위한 함수
        public void FreezeVelocity()
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }

        // 타겟과의 거리 계산
        private void Targeting(float deltaTime)
        {
            targetDistance = Vector3.Distance(transform.position, targetTr.position);

            if (targetDistance <= targetRadius)
            {
                LookTarget(deltaTime);
            }
            else
                IsLooking = false;
        }

        IEnumerator OnDamageFlickering()
        {
            foreach (MeshRenderer mesh in meshes)
            {
                mesh.material.color = Color.red;
            }
            yield return new WaitForSeconds(0.1f);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, targetRadius);
        }
#endif
    }
}