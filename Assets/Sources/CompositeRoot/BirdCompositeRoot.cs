using Sources.HealthSystem;
using Sources.InputSystem;
using Sources.MovementSystem;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BirdView))]
    internal sealed class BirdCompositeRoot : CompositeRoot
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        
        private Movement _movement;
        private MobileInput _mobileInput;
        private BirdView _birdView;
        private Rigidbody2D _rigidbody;
        private Health _health;

        private void Update()
        {
            _mobileInput?.Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _health.Die();
        }

        public override void Compose()
        {
            _movement = new Movement(_speed, _jumpSpeed);
            _mobileInput = new MobileInput();
            _health = new Health();
            
            _birdView = GetComponent<BirdView>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _birdView.Init(_mobileInput, _movement, _rigidbody, _health);
        }
    }
}