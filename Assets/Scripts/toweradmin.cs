using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;
using UnityEngine.InputSystem;

public class toweradmin : MonoBehaviour
{
    public int puntos;
    public Text textoPuntos;
    public int estado = 0;
    public GameObject enemigo;
    public GameObject enemigoGrupo;
    public GameObject puntoInicio;
    public DataJSON misDatos;
    public Vector2 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        string filePat = Application.streamingAssetsPath + "/" + "data1.json";

        if (File.Exists(filePat))
        {
           string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            Debug.Log(misDatos.nombre_juego);
            misDatos.nombre_jugador = "Jugador 2";
            s = JsonUtility.ToJson(misDatos, true);
            Debug.Log(s);
            File.WriteAllText(filePat,s);
        }
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
        var step = 1 * Time.deltaTime; // calculate distance to move
        Vector3 pos = new Vector3(movimiento.x, 0, movimiento.y) + GameObject.Find("GameObject").transform.position;
        GameObject.Find("GameObject").transform.position = Vector3.MoveTowards(GameObject.Find("GameObject").transform.position, pos, step);

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
    public void fuego(InputAction.CallbackContext context)
    {
        //Debug.Log("Presionó fuego " + context.control.displayName);
        if (context.phase == InputActionPhase.Started)
        Debug.Log("Hizo click " + " " + context.phase.ToString()+ " - " + context.ReadValueAsButton().ToString() + " " + context.action.type.ToString());
    }
    public void mueve(InputAction.CallbackContext context)
    {
        if (context.action.ReadValue<Vector2>().magnitude > 0.5f)
        {
            Debug.Log("Se movio " + context.action.ReadValue<Vector2>().x + " " + context.action.ReadValue<Vector2>().y);
            movimiento = context.action.ReadValue<Vector2>();
        }
    }
}
