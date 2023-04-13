using UnityEngine;

public class Idle : State
{
    PlayerMovement _playerMovement;
    StateMachine _sm;

    public Idle(StateMachine sm, PlayerMovement playerMovement)
    {
        _sm = sm;
        _playerMovement = playerMovement;
    }

    public override void Enter()
    {
        _playerMovement.Rb.velocity = new Vector3(0, _playerMovement.Rb.velocity.y, 0);
    }

    public override void Tick()
    {
        if(_playerMovement.InputVector.magnitude > Mathf.Epsilon)
        {
            _sm.ChangeState(_playerMovement.MovingState);
        }
    }
}
