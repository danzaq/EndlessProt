using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public float massScale = 20f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().mass += Time.timeSinceLevelLoad / massScale;

		//GetComponent<Rigidbody>().velocity = Vector3.down * gamemanager.current.gameSpeed;
	}
	
	void OnBecameInvisible()
	{
		GameManager.current.UnregisterBlock(this);
	}
}
