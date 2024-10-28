using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Vector3 TargetPosition { get; private set; }

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float stoppingDistance = .1f;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    public float StoppingDistance
    {
        get => stoppingDistance;
        set => stoppingDistance = value;
    }


    private void Update()
    {

        if (Vector3.Distance(transform.position, TargetPosition) > StoppingDistance)
        {
            Vector3 moveDirection = (TargetPosition - transform.position).normalized;
            transform.position += MoveSpeed * Time.deltaTime * moveDirection;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(TargetPosition);
        }
    }

    private void Move(Vector3 targetPosition)
    {
        Debug.Log("Going to " + targetPosition.ToString());
        this.TargetPosition = MouseWorld.GetPosition();
    }

}
