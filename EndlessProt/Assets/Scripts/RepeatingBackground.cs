using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D roadCollider;
    private float roadLength;
    // Start is called before the first frame update
    void Start()
    {
        roadCollider = GetComponent<BoxCollider2D>();
        roadLength = roadCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.y < -roadLength)
        //{
        //    RepeatBackground();
        //}
    }

    private void RepeatBackground()
    {
        Vector2 roadOffset = new Vector2(0, roadLength * 2f);
        transform.position = (Vector2)transform.position + roadOffset;
    }

    private void OnBecameInvisible()
    {
        RepeatBackground();
    }
}
