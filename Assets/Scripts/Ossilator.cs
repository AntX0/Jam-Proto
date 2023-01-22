using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ossilator : MonoBehaviour
{
    private void Update()
    {
        float y = Mathf.PingPong(Time.time * 0.5f, 1) * 10 - 3;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}

