using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager.Runtime
{
    public class ManageScene : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
        }

        public void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
