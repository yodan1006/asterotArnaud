using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager.Runtime
{
    public class GameManager : MonoBehaviour
    {
        #region Publics

        public int m_life = 3;

        #endregion


        #region Unity Api

        private void Start()
        {
            
        }

        private void Update()
        {
            if (m_life <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        #endregion


        #region Utils

        

        #endregion


        #region Main Methode

        

        #endregion
        
        
        #region Privates
        #endregion
    }
}
