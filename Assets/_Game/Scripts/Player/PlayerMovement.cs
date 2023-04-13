using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    StateMachine _sm;
    public Idle IdleState;
    public Moving MovingState;

    public Vector2 InputVector { get; private set; }
    public float Speed = 6;

    public Rigidbody Rb;
    

    private void Awake()
    {
        _sm = new StateMachine();
        IdleState = new Idle(_sm, this);
        MovingState = new Moving(_sm, this);

        Rb = GetComponent<Rigidbody>();

        _sm.ChangeState(IdleState);
    }

    public float GetCurrentSpeed()
    {
        return Rb.velocity.magnitude;
    }

    void Update()
    {
        _sm.Tick();

        SetInputVector();
    }

    private void FixedUpdate()
    {
        _sm.FixedTick();
    }

        void SetInputVector()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            InputVector = new Vector2(horizontalInput, verticalInput);
        }
}
