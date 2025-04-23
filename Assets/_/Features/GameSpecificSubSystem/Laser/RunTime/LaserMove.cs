using System;
using UnityEngine;
using AsteroidSysteme;
using AsteroidSysteme.Runtime;
using Manager.Runtime;

namespace Laser.Runtime
{
    public class LaserMove : MonoBehaviour
    {
        #region Public
        
        public int m_speed;
        public int m_damage;
        public float m_timer;
        private int m_score = 0;
      
        
        
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
            var damage = other.gameObject.GetComponent<IDamage>();
            if (damage != null)
            {
                m_score++;
                print(m_score);
                damage.Damage();
                ScoreManager.UpdateScore();
            }
            gameObject.SetActive(false);
        }
        #endregion
    }
}
