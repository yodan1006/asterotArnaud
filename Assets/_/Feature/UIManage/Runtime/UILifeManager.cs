using System.Collections.Generic;
using Manager.Runtime;
using UnityEngine;

public class UILifeManager : MonoBehaviour
{
    
    #region Publics
    
        public GameManager gameManager;
        public List<GameObject> uiLife;

    #endregion


    #region Unity Api

    private void Start()
    {
        UpdateHeart();
    }

    

    private void Update()
    {
           UpdateHeart(); 
    }

    #endregion


    #region Utils

        

    #endregion


    #region Main Methode

        private void UpdateHeart()
            {
                for (int i = 0; i < uiLife.Count; i++)
                {
                    uiLife[i].SetActive(i < gameManager.m_life);
                }
            }

    #endregion
        
        
    #region Privates
    #endregion
}
