using System;
using TMPro;
using UnityEngine;


namespace Manager.Runtime
{
    public class ScoreManager : MonoBehaviour
    {
        private static int m_score = 0;
        private void Awake()
        {
            _instance = this;
        }

        private static ScoreManager _instance;
        [SerializeField] private TMP_Text scoreText;

        public static void UpdateScore()
        {
            m_score++;
            _instance.scoreText.text = m_score.ToString();
        }

        
    }
}

