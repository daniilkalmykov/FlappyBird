using UnityEngine;

namespace Sources.GeneratorsSystem.PipesGenerator
{
    internal sealed class PipesGenerator : Pool<Pipe>
    {
        [SerializeField] private float _minSpawnYPosition;
        [SerializeField] private float _maxSpawnYPosition;
        [SerializeField] private Pipe _prefab;
        [SerializeField] private float _delay;
        [SerializeField] private int _count;

        private float _time;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            
            for (var i = 0; i < _count; i++)
                CreateObject(_prefab);
        }
        
        private void Update()
        {
            _time += Time.deltaTime;

            if (TryGetObject(out var pipe) == false || _time < _delay)
                return;
                
            _time = 0;

            var position = transform.position;
            var spawnYPosition = Random.Range(_minSpawnYPosition, _maxSpawnYPosition);
            var spawnPoint = new Vector3(position.x, spawnYPosition, position.z);
                    
            pipe.transform.position = spawnPoint;
            pipe.gameObject.SetActive(true);
            
            TryDisablePipe();
        }

        private void TryDisablePipe()
        {
            const float DisableXPosition = -1f;

            foreach (var pipe in Objects)
            {
                if (pipe.gameObject.activeSelf == false)
                    continue;
                
                var point = _camera.WorldToViewportPoint(pipe.transform.position);
                
                if (point.x < DisableXPosition)
                    pipe.gameObject.SetActive(false);
            }
        }
    }
}