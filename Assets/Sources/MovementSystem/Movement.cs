namespace Sources.MovementSystem
{
    internal class Movement : IMovable
    {
        public Movement(float speed, float jumpSpeed)
        {
            Speed = speed;
            JumpSpeed = jumpSpeed;
        }

        public float Speed { get; }
        public float JumpSpeed { get; }
    }
}