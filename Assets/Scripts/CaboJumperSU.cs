using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaboJumperSU : MonoBehaviour
{
    public GameObject[] cabosToActivate; // Arraste os cabos jumper que devem ser ativados no Inspector

    private bool cabosAtivados = false;

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
        if (!cabosAtivados && GameManager.instance.selectedSpheres == 4)
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