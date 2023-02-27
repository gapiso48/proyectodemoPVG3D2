using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objetivo;
    int estado;
    public float step;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = 10 * Time.deltaTime; // calculate distance to move
        this.transform.position = Vector3.MoveTowards(this.transform.position, objetivo.transform.position, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemigo")
        {
            Destroy(this.gameObject);
        }
    }
}
