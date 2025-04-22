using System.Collections.Generic;
using UnityEngine;

namespace Player.Runtime
{
    public class Shooter : MonoBehaviour
    {
        [Header("Tir")]
        public GameObject projectilePrefab;
        public Transform firePoint;
        public float fireRate = 0.5f;
        public int poolSize = 20;

        private List<GameObject> projectilePool = new List<GameObject>();
        private float nextFireTime;

        void Start()
        {
            // Initialisation de la pool
            for (int i = 0; i < poolSize; i++)
            {
                GameObject proj = Instantiate(projectilePrefab);
                proj.SetActive(false);
                projectilePool.Add(proj);
            }
        }

        void Update()
        {
            if (Input.GetMouseButton(1) && Time.time >= nextFireTime) 
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }

        }

        void Shoot()
        {
            GameObject projectile = GetPooledProjectile();
            if (projectile != null)
            {
                projectile.transform.position = firePoint.position;
                projectile.transform.rotation = firePoint.rotation;
                projectile.SetActive(true);
                
            }
        }

        GameObject GetPooledProjectile()
        {
            foreach (var proj in projectilePool)
            {
                if (!proj.activeInHierarchy)
                    return proj;
            }
            
            GameObject newProj = Instantiate(projectilePrefab);
            newProj.SetActive(false);
            projectilePool.Add(newProj);
            return newProj;
        }
    }
}