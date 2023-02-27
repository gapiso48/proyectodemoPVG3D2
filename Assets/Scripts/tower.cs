using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activeEnemy;
    public GameObject bala;
    public int estado = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == 1)
        {
            shoot();
            estado = 2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (estado == 0) { 
            if (other.tag == "enemigo")
            {
                activeEnemy = other.gameObject;
                estado = 1;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        estado = 0;
    }
    private void shoot()
    {
        GameObject nuevabala = Instantiate(bala, bala.transform.position, bala.transform.rotation);
        nuevabala.GetComponent<bala>().objetivo = activeEnemy;
        nuevabala.GetComponent<bala>().enabled =true;
        Invoke("shoot", 3);
    }
}
