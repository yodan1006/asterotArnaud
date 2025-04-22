using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Runtime
{
    public class LaserPool : MonoBehaviour
    {
        public static LaserPool m_instance;
        public GameObject m_laserPrefab;
        public int m_poolSize;
        
        private Queue<GameObject> _laserpool = new Queue<GameObject>();
        
        private void Awake()
        {
            m_instance = this;
        }
        void Start()
        {
            for (int i = 0; i < m_poolSize; i++)
            {
                GameObject laser = Instantiate(m_laserPrefab);
                laser.SetActive(false);
                _laserpool.Enqueue(laser);
            }
        }

        public GameObject GetLaser()
        {
            if (_laserpool.Count > 0)
            {
                GameObject laser = _laserpool.Dequeue();
                laser.SetActive(true);
                return laser;
            }
            else
            {
                GameObject newlaser = Instantiate(m_laserPrefab);
                return newlaser;
                
            }
        }

        public void ReturnLaser(GameObject laser)
        {
            laser.SetActive(false);
            _laserpool.Enqueue(laser);
        }

    }
}
