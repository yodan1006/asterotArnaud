using UnityEngine;
using UnityEngine.Serialization;

namespace AsteroidSysteme.Runtime
{
    public class AsteroidMax : MonoBehaviour
    {
        #region Publics

        public float m_asteroidSpeed = 1f;
        [FormerlySerializedAs("direction")] public Vector2 m_direction;
        [FormerlySerializedAs("asteroidPool")] public PoolAsteroid m_asteroidPool;
        [FormerlySerializedAs("cam")] public Camera m_cam;

        #endregion


        #region Unity Api

        private void OnEnable()
        {
            if (m_asteroidPool == null)
            {
                m_asteroidPool = FindFirstObjectByType<PoolAsteroid>();
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
        }

        private void Update()
        {
            transform.Translate(m_direction * (Time.deltaTime * m_asteroidSpeed));
           CheckEnemyOutScreen();
        }

        #endregion


        #region Utils

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

        #endregion


        #region Main Methode

        

        #endregion
        
        
        #region Privates

        private float _screenWith;

        #endregion
    }
}
