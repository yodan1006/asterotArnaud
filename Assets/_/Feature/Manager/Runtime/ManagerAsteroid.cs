using AsteroidSysteme.Runtime;
using UnityEngine;

namespace Manager.Runtime
{
    public class ManagerAsteroid : MonoBehaviour
    {
        #region Publics

        public PoolAsteroid m_poolAsteroid;
        public Camera m_cameraMain;

        #endregion


        #region Unity Api

        private void Awake()
        {
            m_cameraMain = Camera.main;
        }

        private void Start()
        {
            _screenWidth = m_cameraMain.orthographicSize * m_cameraMain.aspect;
        }

        private void Update()
        {
            _chrono += Time.deltaTime;
            if (_chrono >= _timeForSpawn)
            {
                SpawnAsteroidFromPool();
                _chrono = 0;
            }
        }

        #endregion


        #region Utils



        #endregion


        #region Main Methode

        void SpawnAsteroidFromPool()
        {
            GameObject asteroid = m_poolAsteroid.GetPoolEnemy();
            if (asteroid != null)
            {
                Vector2 spawn = new Vector2(Random.Range(-_screenWidth, _screenWidth), Random.Range(-_screenWidth, _screenWidth));
                Vector2 spawnPosition = spawn;
                asteroid.transform.position = spawnPosition;
                asteroid.SetActive(true);
            }
        }

        #endregion


        #region Privates

            private float _chrono;
            private float _screenWidth;
            [SerializeField]private float _timeForSpawn;
            
            
            #endregion
        }
    }
