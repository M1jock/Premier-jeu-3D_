using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    WaypointsPathController waypointsPathController;
    [SerializeField]
    Animator animator;

    Vector3 startPos;

    public int currentHealth;
    public int maxHealth;

    private bool isDead;

    GameObject playerGo;
    Coroutine activeCorout;

    private void Start()
    {
        currentHealth = maxHealth;
        startPos = transform.position;
        EnnemiAi();
    }
    public void EnnemiAi()
    {
        StartCoroutine(PatrolCorout());

    }
    IEnumerator PatrolCorout()
    {
        int currentWaypointIndex = 0;
        WaypointsPathController.WaypointInfo waypointInfo;
        while (true)
        {
            waypointInfo = waypointsPathController.GetNextWaypoint(currentWaypointIndex);
            currentWaypointIndex = waypointInfo.index;
            agent.SetDestination(waypointInfo.target.position);
            while (agent.pathPending) yield return null;
            if (agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                while (agent.remainingDistance > 1.8f)
                {
                    yield return null;
                }

            }
            yield return null;

        }
    }
    IEnumerator ChaseCorout(GameObject player)
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, startPos) > 25)
                break;
            agent.SetDestination(player.transform.position);
            yield return null;
        }
        activeCorout = StartCoroutine(PatrolCorout());
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0)
        {
            isDead = true;
            if (isDead == true)
            {
                animator.SetBool("isDead", true);
            }
            Kill();
            //Destroy(this.gameObject);
        }


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (activeCorout != null) return;
            activeCorout = StartCoroutine(ChaseCorout(collision.gameObject));
        }
    }

    IEnumerator checkPlayerOnTop()
    {
        Vector3 playerPos, pos;

        while (playerGo != null)
        {
            playerPos = playerGo.transform.position;
            playerPos.y = 0;
            pos = transform.position;
            pos.y = 0;
            float distanceXZ = Vector3.Distance(playerPos, pos);
            if (distanceXZ < 25)
            {
                float distanceY = playerGo.transform.position.y - transform.position.y;
                if (distanceY < 0.05f)
                {
                    TakeDamage(1);
                }
            }
        }
        yield return null;
    }
    void Kill()
    {
        EnnemyKillCount.AddKill();
    }

}
