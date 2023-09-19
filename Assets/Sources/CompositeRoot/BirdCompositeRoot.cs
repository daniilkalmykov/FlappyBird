using System;
using System.Collections.Generic;
using Sources.HealthSystem;
using Sources.InputSystem;
using Sources.LevelSettings;
using Sources.MovementSystem;
using Sources.ScoreSystem;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BirdView))]
    internal sealed class BirdCompositeRoot : CompositeRoot
    {
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private List<LevelSettings.LevelSettings> _levelSettings;
        
        private float _speed;
        private Movement _movement;
        private MobileInput _mobileInput;
        private BirdView _birdView;
        private Rigidbody2D _rigidbody;
        private Health _health;
        private Score _score;

        public IScore Score => _score;

        private void Update()
        {
            _mobileInput?.Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _health.Die();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _score.Increase();
        }

        public override void Compose()
        {
            var setting = LevelSettingsGetter.Get(_levelSettings);

            if (setting == null)
                throw new ArgumentNullException();
            
            _speed = setting.PlayerSpeed;

            _movement = new Movement(_speed, _jumpSpeed);
            _mobileInput = new MobileInput();
            _health = new Health();
            _score = new Score();
            
            _birdView = GetComponent<BirdView>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _birdView.Init(_mobileInput, _movement, _rigidbody, _health);
        }
    }
}