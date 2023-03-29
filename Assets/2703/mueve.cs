using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mueve : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 pos;
    float y_ini;
    float y;
    void Start()
    {
        pos = this.transform.position;
        y_ini = pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        y = 2 * Mathf.Sin(2 * Mathf.PI * Time.time * 2);
        pos.y = y_ini + y;
        this.transform.position = pos;
    }
}
