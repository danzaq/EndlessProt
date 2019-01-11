using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DisplayTime : MonoBehaviour {

    public TextMeshProUGUI textMesh;
    // Use this for initialization
    void Start () {
        StartCoroutine(RestartGame());
        textMesh.text = GameManager.finalTime;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
