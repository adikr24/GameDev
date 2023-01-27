using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        GameObject.Find("Player")
            .GetComponent<EquipmentManager>()
            .Reset();
        
        SceneManager.LoadScene("Mountain");
        Time.timeScale = 1f;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void ExitGame() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}
