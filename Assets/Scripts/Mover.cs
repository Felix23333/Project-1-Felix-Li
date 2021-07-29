using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float xMax;
    public float xMin;
    public float speed = 10;
    bool trigger = false;
    int count;
    bool isLock = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count >= 50)
        {
            isLock = false;
        }
        if (trigger)
        {
            speed = -speed;
            trigger = false;
        }
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x > xMax || transform.position.x < xMin)
        {
            if (!isLock)
            {
                trigger = true;
                isLock = true;
                count = 0;
            }
        }
    }

    public void SavePos()
    {
        PlayerPrefs.SetFloat("x", transform.position.x);
    }

    public void LoadPos()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("x"), transform.position.y, transform.position.z);
    }
}
