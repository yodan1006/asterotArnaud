using System.Collections.Generic;
using UnityEngine;

namespace AsteroidSysteme.Runtime
{
    public class PoolAsteroid : MonoBehaviour
    {
        #region Publics

        public int m_poolSize;
        public Transform m_parentTransform;
        public List<GameObject> m_prefabEnemy;
        public List<GameObject> pool = new List<GameObject>();

        #endregion


        #region Unity Api

        private void Start()
        {
            GenereatePool();
        }

        private void Update()
        {
            
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
            int index = Random.Range(0, pool.Count);
            for (int i = 0; i < pool.Count; i++)
            {
                GameObject asteroid = pool[(index + i) % pool.Count];
                if (!asteroid.activeInHierarchy) return asteroid;
            }

            int randomIndex = Random.Range(0, m_prefabEnemy.Count);
            GameObject newEnemy = Instantiate(m_prefabEnemy[randomIndex]);
            newEnemy.transform.SetParent(m_parentTransform);
            newEnemy.SetActive(false);
            pool.Add(newEnemy);
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
            int randomIndex = Random.Range(0, m_prefabEnemy.Count);
            GameObject asteroid = Instantiate(m_prefabEnemy[(randomIndex)]);
            asteroid.SetActive(false);
            asteroid.transform.SetParent(m_parentTransform);
            pool.Add(asteroid);
        }

        

        #endregion
        
        
        #region Privates
        
        
        #endregion
    }
}
