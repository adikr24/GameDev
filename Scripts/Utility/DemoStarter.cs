using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartDemo()
    {
        SceneManager.LoadScene("Demo");
        Time.timeScale = 1f;
    }

}
