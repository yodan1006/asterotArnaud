using System;
using UnityEngine;

namespace Laser.Runtime
{
    public class LaserMove : MonoBehaviour
    {
        #region Public
        
        
        public int m_speed;
        public int m_damage;
        public float m_timer;
        
        
        #endregion
        
        
        #region API Unity
        void Start()
        {
            m_timer = 2.0f;
        }

        void Update()
        {
            transform.Translate(Vector3.up * (m_speed * Time.deltaTime));
            m_timer -= Time.deltaTime;
            if (m_timer <= 0)
            {
                gameObject.SetActive(false);
                m_timer = 2.0f;
            }
        }
        #endregion
        
        
        #region Private and protected Methods
        private void OnTriggerEnter2D(Collider2D other)
        {
            print(other.gameObject.name);
            other.gameObject.SetActive(false);
            
        }
        #endregion
    }
}
