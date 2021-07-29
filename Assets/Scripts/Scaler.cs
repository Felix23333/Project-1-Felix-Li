using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public float maxScale = 2f;
    public float minScale = 0.2f;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > maxScale)
        {
            transform.localScale = new Vector3(minScale, minScale, minScale);
        }
        transform.localScale = transform.localScale + new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
    }
}
