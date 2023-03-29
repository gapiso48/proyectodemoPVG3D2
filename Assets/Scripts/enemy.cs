using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject endPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<NavMeshAgent>().SetDestination(endPoint.transform.position);
        Debug.Log(this.GetComponent<NavMeshAgent>().GetAreaCost(3));
    }

    // Update is called once per frame
    void Update()
    {
        float costo = this.GetComponent<NavMeshAgent>().GetAreaCost(3);
        //this.GetComponent<NavMeshAgent>().speed = 10 - costo;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "meta")
        {
            Destroy(this.gameObject);
        }
    }

}
