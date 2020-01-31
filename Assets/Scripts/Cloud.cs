using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 10f;
    void Start()
    {
        speed = Random.Range(1, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 10)
            Destroy(gameObject);
        else
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }
}
