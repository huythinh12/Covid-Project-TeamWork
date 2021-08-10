using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAgent : MonoBehaviour
{
    [SerializeField]
    private Transform[] _points;

    [SerializeField]
    private float _minRemainingDistance = 0.5f;

    [SerializeField]
    private int _destinationPoint = 0;

    [SerializeField]
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        _agent.autoBraking = false;

        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (_points.Length == 0)
        {
            Debug.LogError("You must setup at least one destination point");
            enabled = false;
            return;
        }

        // Set the agent to go to the currently selected destination.
        _agent.destination = _points[_destinationPoint].position;


        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.

        /*
        _destinationPoint++;

        if (_destinationPoint >= _point.Length)
        {
            _destinationPoint = 0;
        }
        */

        _destinationPoint = (_destinationPoint + 1) % _points.Length;
    }


    // Update is called once per frame
    void Update()
    {
        if(!_agent.pathPending && _agent.remainingDistance < _minRemainingDistance)
        {
            GotoNextPoint();
        }
    }
}
