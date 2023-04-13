public class StateMachine
{
	public State CurrentState { get; private set; }
	public State PreviousState { get; private set; }

	bool _inTransition = false;
#region public
	// pass down Update ticks to States, since they won't have a MonoBehaviour
	public void Tick()
	{
		// simulate update ticks in states
		if (CurrentState != null && !_inTransition)
			CurrentState.Tick();
	}

	public void FixedTick()
	{
		// simulate fixedUpdate ticks in states
		if (CurrentState != null && !_inTransition)
			CurrentState.FixedTick();
	}

	public void ChangeState(State newState)
	{
		// ensure we're ready for a new state
		if (CurrentState == newState || _inTransition)
			return;

		ChangeStateRoutine(newState);
	}

	public void RevertState()
	{
		if (PreviousState != null)
			ChangeState(PreviousState);
	}
	#endregion

#region private
	void ChangeStateRoutine(State newState)
	{
		_inTransition = true;
		// begin our exit sequence, to prepare for new state
		if (CurrentState != null)
			CurrentState.Exit();
		// save our current state, in case we want to return to it
		if (PreviousState != null)
			PreviousState = CurrentState;

		CurrentState = newState;

		// begin our new Enter sequence
		if (CurrentState != null)
			CurrentState.Enter();

		_inTransition = false;
	}
#endregion
}
