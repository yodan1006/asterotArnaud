using System;
using UnityEngine;

namespace Laser.Runtime
{
    public class LaserMove : MonoBehaviour
    {
        public int m_speed;
        public int m_damage = 10;
        public float m_timer;
        
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            print(other.gameObject.name);
            //TODO Damage to give to astéroid With Interface ( other.GetComponent...) 
        }
    }
}
