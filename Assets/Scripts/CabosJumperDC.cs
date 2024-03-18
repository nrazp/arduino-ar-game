using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaboJumperDC : MonoBehaviour
{
    public GameObject[] cabosToActivate; // Arraste os cabos jumper que devem ser ativados no Inspector

    private bool cabosAtivados = false;
    public Drag PonteH;

    // Start is called before the first frame update
    private void Start()
    {
        // Desative inicialmente os cabos
        foreach (var cabo in cabosToActivate)
        {
            cabo.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verifique se as três esferas corretas foram selecionadas
        if (!cabosAtivados && PonteH != null && !PonteH.isDraggable)
        {
            // Ative os cabos jumper
            foreach (var cabo in cabosToActivate)
            {
                cabo.SetActive(true);
            }

            cabosAtivados = true; // Evita que os cabos sejam ativados novamente
        }
    }
}