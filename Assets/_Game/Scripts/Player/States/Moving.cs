using UnityEngine;

public class Moving : State
{
    PlayerMovement _playerMovement;
    StateMachine _sm;

    public Moving(StateMachine sm, PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
        _sm = sm;
    }

    public override void FixedTick()
    {
        var input = _playerMovement.InputVector;
        _playerMovement.Rb.velocity = new Vector3(input.x * _playerMovement.Speed, _playerMovement.Rb.velocity.y, input.y * _playerMovement.Speed);
    }

    public override void Tick()
    {
        if (_playerMovement.InputVector.magnitude < Mathf.Epsilon)
        {
            _sm.ChangeState(_playerMovement.IdleState);
        }
    }
}
