using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    private enum State
    {
        Roaming
    }

    private State state;
    private ChickenPathfinding chickenPathfinding;

    private void Awake()
    {
        chickenPathfinding = GetComponent<ChickenPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            chickenPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);

        }

    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
