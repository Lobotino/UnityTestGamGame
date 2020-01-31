using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{

    public float dayTime = 1f;
    public float skySpeed = 1f, sunSpeed = 1f;
    public GameObject sky, sun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sky.transform.position.y <= 7)
            sky.transform.Translate(new Vector2(0, skySpeed * Time.deltaTime / dayTime));
        
        if(sun.transform.position.y >= -5.3f)
            sun.transform.Translate(new Vector2(0, -sunSpeed * Time.deltaTime / dayTime));
    }
}
