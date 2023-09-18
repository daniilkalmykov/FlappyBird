using System;
using UnityEngine;

namespace Sources.Utilities
{
    internal sealed class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Coordinate _coordinate;
        
        private void Update()
        {
            transform.position = GetNewPosition();
        }

        private Vector3 GetNewPosition()
        {
            var position = transform.position;
            
            switch (_coordinate)
            {
                case Coordinate.X:
                    position.x = _target.position.x;
                    break;

                case Coordinate.Y:
                    position.y = _target.position.y;
                    break;

                case Coordinate.Both:
                    position = _target.position;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return position;
        }
    }

    internal enum Coordinate
    {
        X,
        Y,
        Both
    }
}