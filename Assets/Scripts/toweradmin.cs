using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class toweradmin : MonoBehaviour
{
    public int puntos;
    public Text textoPuntos;
    public int estado = 0;
    public GameObject enemigo;
    public GameObject enemigoGrupo;
    public GameObject puntoInicio;
    // Start is called before the first frame update
    void Start()
    {
        enemigo.GetComponent<enemy>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case 0: //reposo
                break;
            case 1: //reposo
                spawn();
                estado = 2;
                break;
            case 2: //reposo
                break;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Inicia");
            estado = 1;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            estado = 2;
        }
    }

    private void spawn()
    {
        if (estado == 1 || estado==2)
        {
            GameObject nuevoEnemigo =  Instantiate(enemigo, puntoInicio.transform.position, enemigo.transform.rotation, enemigoGrupo.transform);
            nuevoEnemigo.GetComponent<enemy>().enabled = true;
            Invoke("spawn", 10);
        }
    }

    public void sumarpuntos(int score)
    {
        puntos = puntos + score;
        textoPuntos.text = puntos.ToString();
    }

}
