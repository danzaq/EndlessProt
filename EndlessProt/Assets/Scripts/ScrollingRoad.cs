using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRoad : MonoBehaviour
{
    private Rigidbody2D road;
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        road = GetComponent<Rigidbody2D>();
        road.velocity = new Vector2(0, -scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
