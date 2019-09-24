using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform _enemy;
    public Transform player;    
    public bool _foundPlayer = false;
    public Vector3 leftScapePoint;
    public Vector3 rightScapePoint;

    private void Awake()
    {
        enemy.SetDestination(player.position);
    }

    void Update()
    {
        SetTarget();
    }

    private void SetTarget()
    {
        if (_foundPlayer == false)
        {
            if (player.position == null)
            {
                enemy.SetDestination(transform.position);
            }
            else
            {
                enemy.SetDestination(player.position);
            }

        }
        else
        {
            enemy.SetDestination(transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _foundPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _foundPlayer = false;
        }
    }
}
