using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;

public class toweradmin : MonoBehaviour
{
    public int puntos;
    public Text textoPuntos;
    public int estado = 0;
    public GameObject enemigo;
    public GameObject enemigoGrupo;
    public GameObject puntoInicio;
    public DataJSON misDatos;
    public Text t_nombreJugador;
    public InputField i_nombreNuevo;
    // Start is called before the first frame update
    void Start()
    {
        string filePat = Application.streamingAssetsPath + "/" + "data1.json";

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            t_nombreJugador.text = misDatos.nombre_jugador;
            Color32 col = misDatos.updateColor();
            enemigo.GetComponent<MeshRenderer>().materials[0].color = col;
        }
        else
        {
            misDatos = new DataJSON(10, "Nuevo juego", "Random", true);
            string s = JsonUtility.ToJson(misDatos, true);
            //Debug.Log(s);
            File.WriteAllText(filePat, s);
            t_nombreJugador.text = misDatos.nombre_jugador;
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
    public void changeName()
    {
        misDatos.nombre_jugador = i_nombreNuevo.text;
        string filePat = Application.streamingAssetsPath + "/" + "data1.json";
        string s = JsonUtility.ToJson(misDatos, true);
        File.WriteAllText(filePat, s);
    }
}
