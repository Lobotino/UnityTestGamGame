using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsManager : MonoBehaviour
{
    public GameObject cloudPrefab;
    public Sprite[] sprites;
    public int intensity = 1;
    private int tick = 0;
    void Update()
    {
        if (tick++ >= 70 - intensity - Random.Range(0, 40))
        {
            tick = 0;
            GameObject newCloud = Instantiate(cloudPrefab, new Vector2(-5.5f, Random.Range(0f, -2.5f)), Quaternion.identity);
            newCloud.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
