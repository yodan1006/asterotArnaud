using UnityEngine;
using UnityEngine.Serialization;

namespace AsteroidSysteme.Runtime
{
    public class AsteroidMax : MonoBehaviour, IDamage
    {
        #region Publics

        public float m_asteroidSpeed = 1f;
        [FormerlySerializedAs("direction")] public Vector2 m_direction;
        [FormerlySerializedAs("asteroidPool")] public PoolAsteroid m_asteroidPool;
        public PoolMidAsteroid m_midAsteroidPool;
        [FormerlySerializedAs("cam")] public Camera m_cam;

        #endregion


        #region Unity Api

        private void OnEnable()
        {
            if (m_asteroidPool == null)
            {
                m_asteroidPool = FindFirstObjectByType<PoolAsteroid>();
            }
            if (m_midAsteroidPool == null)
            {
                m_midAsteroidPool = FindFirstObjectByType<PoolMidAsteroid>();
            }

            if (m_cam == null)
            {
                m_cam = Camera.main;
            }

        }


        private void Start()
        {
            m_direction =  new Vector2(Random.Range(-5,5), Random.Range(-5,5));
            _screenWith = m_cam.orthographicSize;
            _screenWidth = m_cam.orthographicSize * m_cam.aspect;
        }

        private void Update()
        {
            transform.Translate(m_direction * (Time.deltaTime * m_asteroidSpeed));
           CheckEnemyOutScreen();
            if (_OnDestroyed)
            {
                DivideOnTwo();
            }
        }

        #endregion


        #region Utils

        public void Damage()
                {
                   gameObject.SetActive(false);
                   m_asteroidPool.ReturnToPool(gameObject);
                   _OnDestroyed = true;
                }

        #endregion


        #region Main Methode

        private void CheckEnemyOutScreen()
                {
                    Vector2 screenPos = m_cam.WorldToScreenPoint(transform.position);
                    if (screenPos.x < 0|| screenPos.y < 0) DesactivateEnemy();
                    if (screenPos.x > Screen.width || screenPos.y > Screen.height) DesactivateEnemy();
                }
        
                private void DesactivateEnemy()
                {
                    gameObject.SetActive(false);
                    if (m_asteroidPool != null) m_asteroidPool.ReturnToPool(gameObject);
                }

                private void DivideOnTwo()
                {
                    for (int i = 0; i < 2; i++)
                    {
                        GameObject asteroid = m_midAsteroidPool.GetPoolEnemy();
                        if (asteroid != null)
                        {
                            asteroid.transform.position = transform.position;
                            asteroid.SetActive(true);
                        }
                    }
                }

        #endregion
        
        
        #region Privates

        private float _screenWith;
        private bool _OnDestroyed;
        private float _screenWidth;

        #endregion


    }
}
