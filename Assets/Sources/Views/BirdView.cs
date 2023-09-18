using System;
using System.Runtime.CompilerServices;
using Sources.HealthSystem;
using Sources.InputSystem;
using Sources.MovementSystem;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.Views
{
    internal sealed class BirdView : MonoBehaviour
    {
        [SerializeField] private float _minRotationZ;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _rotationSpeed;

        private Quaternion _minRotation;
        private Quaternion _maxRotation;
        private IInput _input;
        private IMovable _movable;
        private Rigidbody2D _rigidbody;
        private IHealth _health;

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }

        private void Update()
        {
            if (_movable == null || _input == null)
                return;

            if (_input.IsJumpButtonClicked)
                MoveUp();
            else
                MoveDown();
        }

        public void Init(IInput input, IMovable movable, Rigidbody2D currentRigidbody, IHealth health)
        {
            _input = input ?? throw new ArgumentNullException();
            _movable = movable ?? throw new ArgumentNullException();
            _health = health ?? throw new ArgumentNullException();

            _rigidbody = currentRigidbody;
            
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

            _health.Died += OnDied;
        }

        private void OnDied()
        {
            gameObject.SetActive(false);
        }

        private void MoveUp()
        {
            _rigidbody.velocity = new Vector2(_movable.Speed, 0);
            _rigidbody.AddForce(Vector2.up * _movable.JumpSpeed, ForceMode2D.Force);
            
            transform.rotation = _maxRotation;
        }

        private void MoveDown()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}