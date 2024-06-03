using System;
using UnityEngine;
using UnityEngine.AI;

public class EMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float radiusDetect;

    private NavMeshAgent _agent;
    private GameObject _player;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) <= radiusDetect)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_player.transform.position);
        }
        else
        {
            _agent.isStopped = true;
        }
    }
}