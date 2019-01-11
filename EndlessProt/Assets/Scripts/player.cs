using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float speed = 15f;

	public float mapWidth = 2f;
	
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();	
	}
	void FixedUpdate()
	{
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
             Touch touch = Input.GetTouch(0);
             Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
             float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
             touchPos.z = 0f;
             Vector3 newPosition = touchPos + Vector3.right * x;

             newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
             newPosition.y = Mathf.Clamp(newPosition.y, -2, -2);

             rb.MovePosition(newPosition);
         }
		//float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        //Vector3 newPosition = rb.position + Vector3.right * x;
        //newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        //rb.MovePosition(newPosition);
	} 

	
	void OnCollisionEnter()
	{
		FindObjectOfType<GameManager>().EndGame();
	}
}
