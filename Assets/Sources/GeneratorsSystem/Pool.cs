using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sources.GeneratorsSystem
{
    internal abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        private readonly List<T> _pool = new();

        protected IReadOnlyList<T> Objects => _pool;

        protected void CreateObject(T objectToCreate)
        {
            var newObject = Instantiate(objectToCreate, null);
            newObject.gameObject.SetActive(false);

            _pool.Add(newObject);
        }

        protected bool TryGetObject(out T t)
        {
            t = _pool.FirstOrDefault(result => result.gameObject.activeSelf == false);

            return t != null;
        }
    }
}