using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class DataJSON : System.Object
{

    [SerializeField]
    private int id;
    [SerializeField]
    public string nombre_juego;
    [SerializeField]
    public string nombre_jugador;
    [SerializeField]
    public bool activo;
    [SerializeField]
    private int puntos;
    [SerializeField]
    public int r,g,b;


    public DataJSON()
    {
    }

    public DataJSON(int id, string juego, string jugador, bool act)
    { //, Date created_at, Date updated_at) {
        this.id = id;
        this.nombre_juego = juego;
        this.nombre_jugador = jugador;
        this.activo = act;
    }
    public int getId()
    {
        return this.id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public Color32 updateColor()
    {
        Color32 color = new Color32((byte) r,(byte) g,(byte) b,255);
        return color;
    }
}
