using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TransitionText : MonoBehaviour
{

    public Text textObject;

    private float letterDelay = 0.03f;
    private float slideDelay = 1.5f;
	private string currentText = "";

    private string text1 = "After successfully leaving the mountains, you must deliver the loot within the city.";
    private string text2 = "The authorities are on high alert and will try to stop you at all costs.";
    private string text3 = "Drive to the tunnel on the opposite side of the city, where the police can't follow you.";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowSlide());
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.Space)) {
            SceneManager.LoadScene("AlphaScene");
        }
    }

    IEnumerator ShowSlide()
    {
        textObject.text = "";

		for(int i = 0; i < text1.Length+1; i++){
			currentText = text1.Substring(0,i);
			textObject.text = currentText;
			yield return new WaitForSeconds(letterDelay);
        }
        yield return new WaitForSeconds(slideDelay);
        currentText = "";
        textObject.text = "";

		for(int i = 0; i < text2.Length+1; i++){
			currentText = text2.Substring(0,i);
			textObject.text = currentText;
			yield return new WaitForSeconds(letterDelay);
        }
        yield return new WaitForSeconds(slideDelay);
        currentText = "";
        textObject.text = "";

		for(int i = 0; i < text3.Length+1; i++){
			currentText = text3.Substring(0,i);
			textObject.text = currentText;
			yield return new WaitForSeconds(letterDelay);
        }
        yield return new WaitForSeconds(slideDelay);
        SceneManager.LoadScene("AlphaScene");
    }
}
