using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitScript : MonoBehaviour
{
    [SerializeField] private GameObject unitUI;
    private Coroutine mCurrentState;

    private void Awake()
    {
        if(unitUI == null)
        {
            unitUI = GameObject.Find("Unit_UI");
        }
    }
    private void Start()
    {
        SetState(StateIdle());
    }
    protected void Update()
    {
        //if (mCurrentEnemy != null)
        {
            //Quaternion desiredRotation = Quaternion.LookRotation((mCurrentEnemy.transform.position - transform.position), Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, mRotationRate);
        }
    }

    private void OnMouseUp()
    {
        unitUI.SetActive(true);
    }

    private void SetState(IEnumerator newState)
    {
        if (mCurrentState != null)
        {
            StopAllCoroutines();
        }

        mCurrentState = StartCoroutine(newState);
    }

    //Idle State

    private IEnumerator StateIdle()
    {
        //while (mCurrentOutpost == null)
        {
            //mCurrentOutpost = GameManager.GetRandomOutpost();
            yield return 0;
        }
        //SetState(StateMoveToOutpost());
    }
    public void Die()
    {
        //SetState(State_Dead());
        //mNavMeshAgent.isStopped = true;
        //Destroy(gameObject, 5f);
    }

    private IEnumerator State_Dead()
    {
        yield return 0;
    }

    //private void GetEnemyAroundMe()
    //{
    //    if (IsAlive == false) return;
    //    if (mCurrentEnemy != null && mCurrentEnemy.IsAlive) return;

    //    Collider[] aroundMe = Physics.OverlapSphere(transform.position, mEnemyDetectionRadius, mUnitsLayerMask);
    //    AUnit closestEnemy = null;
    //    foreach (Collider col in aroundMe)
    //    {
    //        if (col.transform == transform) continue; //ignore self

    //        AUnit otherUnit = col.GetComponent<AUnit>();
    //        if (otherUnit != null && otherUnit.IsAlive && otherUnit.TeamNumber != TeamNumber)
    //        {
    //            if (closestEnemy == null)
    //            {
    //                closestEnemy = otherUnit;
    //                continue;
    //            }
    //            Vector3 directionToClosest = closestEnemy.transform.position - transform.position;
    //            Vector3 directionToCurrent = otherUnit.transform.position - transform.position;
    //            if (directionToClosest.sqrMagnitude > directionToCurrent.sqrMagnitude)
    //            {
    //                closestEnemy = otherUnit;
    //            }
    //        }
    //    }
    //    if (closestEnemy != null)
    //    {
    //        mCurrentEnemy = closestEnemy;
    //        SetState(StateShieldEngaged());
    //    }
    //}

    //private IEnumerator StateAttackingEnemy()
    //{
    //    mNavMeshAgent.isStopped = true;

    //    while (mCurrentEnemy != null && mCurrentEnemy.IsAlive)
    //    {
    //        ShootLasersFromEyes(mCurrentEnemy.IsShieldEngaged(), mCurrentEnemy.transform.position + (Vector3.up * mEnemyHitOffset));
    //        //if enemies sheld engaged they don't take damage
    //        mCurrentEnemy.TakeDamage(AttackDamage);
    //        yield return new WaitForSeconds(mAttackCD);
    //    }

    //    mCurrentEnemy = null;
    //    SetState(StateIdle());
    //}

    // MoveToOutpost state
    //private IEnumerator StateMoveToOutpost()
    //{

    //    mNavMeshAgent.SetDestination(mCurrentOutpost.transform.position);
    //    mNavMeshAgent.isStopped = false;
    //    while (mNavMeshAgent.remainingDistance > mNavMeshAgent.stoppingDistance)
    //    {
    //        GetEnemyAroundMe();
    //        yield return 0;
    //    }
    //    SetState(StateCaptureOutpost());
    //}

    
}
