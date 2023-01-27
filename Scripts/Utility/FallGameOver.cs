using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallGameOver : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position.y < 2) && (player.transform.position.z > 350)){
            GameObject.Find("Player")
                .GetComponent<EquipmentManager>()
                .Reset();

            GameEnder.SetGameEnd(GameEndType.WASTED);
            SceneManager.LoadScene("GameOver");
        }
    }
}
