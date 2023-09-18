using System;
using Sources.InputSystem;
using Sources.MovementSystem;
using UnityEngine;

namespace Sources.BirdView
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

        private void Update()
        {
            if (_movable == null || _input == null || _rigidbody == null)
                return;

            if (_input.IsJumpButtonClicked)
                MoveUp();
            else
                MoveDown();
        }

        public void Init(IInput input, IMovable movable, Rigidbody2D currentRigidbody)
        {
            _input = input ?? throw new ArgumentNullException();
            _movable = movable ?? throw new ArgumentNullException();

            if (currentRigidbody == null)
                _rigidbody = currentRigidbody;
            
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
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