using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame2 : MonoBehaviour
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
        Debug.Log(player.transform.position);
        if ((player.transform.position.z < endTunnel.transform.position.z+100) && (player.transform.position.x > endTunnel.transform.position.x-10)) {
            SceneManager.LoadScene("Transition");
        }
    }
}
