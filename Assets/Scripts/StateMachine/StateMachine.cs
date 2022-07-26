namespace MovementSystem
{
    public abstract class StateMachine 
    {
        protected IState currentState;//from istate to refer current state
        public void ChangeState(IState newState)
        {
            currentState?.Exit();//Exit from old state if its null you wont get
            currentState = newState;//Enter the new state
            currentState.Enter();
        }
        public void Update()
        {
            currentState?.Update();
        }

        public void HandleInput()
        {
            currentState?.HandleInput();
        }
        public void PhysicsUpdate()
        {
            currentState?.PhysicsUpdate();
        }
    }
}
