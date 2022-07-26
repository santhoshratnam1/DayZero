
namespace MovementSystem
{
    public class PlayerMovementStateMachine : StateMachine
    {
        public Player Player { get; }
        public PlayerIdelingState IdelingState { get; }
        public PlayerWalking Walking { get; }
        public PlayerRunning Running { get; }
        public PlayerSprinting Sprinting { get; }

        public PlayerMovementStateMachine(Player player)
        {
            Player = player;
            IdelingState = new PlayerIdelingState(this);
            Walking = new PlayerWalking(this);
            Running = new PlayerRunning(this);
            Sprinting = new PlayerSprinting(this);

        }
    }
}
