using System;
using UnityEngine;

namespace Sources.Utilities
{
    internal sealed class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Coordinate _coordinate;
        
        private Vector3 _position;
        private Vector3 _offence;

        private void Start()
        {
            var targetPosition = _target.position;
            
            _offence = new Vector3(_position.x - targetPosition.x, _position.y - targetPosition.y, _position.z - targetPosition.z);
        }

        private void Update()
        {
            SetPosition();
            
            transform.position = _position;
        }

        private void SetPosition()
        {
            _position = transform.position;
            
            switch (_coordinate)
            {
                case Coordinate.X:
                    _position.x = _target.position.x + _offence.x;
                    break;

                case Coordinate.Y:
                    _position.y = _target.position.y +  + _offence.y;
                    break;

                case Coordinate.Both:
                    var targetPosition = _target.position;
                    _position = new Vector3(targetPosition.x + _offence.x, targetPosition.y + +_offence.y,
                        targetPosition.z + +_offence.z);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    internal enum Coordinate
    {
        X,
        Y,
        Both
    }
}