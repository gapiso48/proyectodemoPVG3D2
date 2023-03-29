using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.UI;

public class uimethods : MonoBehaviour
{
    public Canvas canvas_gral;

    private bool UI_enabled;
    public Text texto_puntos;
    public VideoPlayer player;
    public TMP_Text texto_nombre;
    public Toggle habilita;
    private int puntos =0;

    private bool pausa;
    void Start()
    {
        texto_puntos.text = puntos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UI_enabled = !UI_enabled;
            canvas_gral.enabled = UI_enabled;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.Play();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.Pause();
        }


    }

    public void update_ui_1()
    {
        if (pausa == false)
        {
            Time.timeScale = 0;
            pausa = true;
            this.GetComponent<AudioSource>().Pause();
        }
        else {
            Time.timeScale = 1;
            pausa = false;
            this.GetComponent<AudioSource>().Play();
        }
        /*if (habilita.isOn)
        {
            puntos++;
            texto_puntos.text = puntos.ToString();
        }*/
    }
}
