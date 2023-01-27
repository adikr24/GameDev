using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

    public GameObject player;
    public GameObject endTunnel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > endTunnel.transform.position.x-40) {
            SceneManager.LoadScene("YouWin");

        }
    }
}
