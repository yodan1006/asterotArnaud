using System.Collections.Generic;
using UnityEngine;

namespace AsteroidSysteme.Runtime
{
    public class PoolSmallMeteor : MonoBehaviour
    {
        #region Publics
        
        public List<GameObject> m_prefabs;
        public List<GameObject> m_pool;
        public Transform m_parentTransform;
        public int m_poolSize;
        #endregion


        #region Unity Api

        private void Start()
        {
            GenereatePool();
        }
        
        #endregion


        #region Utils

        public void ReturnToPool(GameObject go)
        {
            go.SetActive(false);
            go.transform.SetParent(m_parentTransform);
        }
        public GameObject GetPoolEnemy()
        {
            int index = Random.Range(0, m_pool.Count);
            for (int i = 0; i < m_pool.Count; i++)
            {
                GameObject asteroid = m_pool[(index + i) % m_pool.Count];
                if (!asteroid.activeInHierarchy) return asteroid;
            }

            int randomIndex = Random.Range(0, m_prefabs.Count);
            GameObject newEnemy = Instantiate(m_prefabs[randomIndex]);
            newEnemy.SetActive(false);
            m_pool.Add(newEnemy);
            return newEnemy;
        }

        #endregion


        #region Main Methode

        void GenereatePool()
        {
            for (int i = 0; i < m_poolSize; i++)
            {
                GenereateAsteroid();
            }
        }
        
        void GenereateAsteroid()
        {
            int randomIndex = Random.Range(0, m_prefabs.Count);
            GameObject asteroid = Instantiate(m_prefabs[(randomIndex)]);
            asteroid.SetActive(false);
            asteroid.transform.SetParent(m_parentTransform);
            m_pool.Add(asteroid);
        }

        #endregion
        
        
        #region Privates
        #endregion
    }
}
