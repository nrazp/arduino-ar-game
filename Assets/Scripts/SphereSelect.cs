using UnityEngine;
using TMPro;

public class SphereSelection : MonoBehaviour
{
    public TMP_Text nameText; // Referência ao objeto de TextMeshPro para exibir o nome

    private bool isSelected = false; // Indica se a esfera está selecionada

    private void OnMouseDown()
    {
        // Verifique se a esfera não foi selecionada
        if (!isSelected)
        {
            // Marque a esfera como selecionada
            isSelected = true;

            // Mude a cor da esfera para amarelo (ou outra cor)
            GetComponent<Renderer>().material.color = Color.yellow;

            // Adicione à contagem de esferas selecionadas
            GameManager.instance.selectedSpheres++;

            // Exiba o nome da esfera
            nameText.gameObject.SetActive(true);
        }
        else
        {
            // A esfera já foi selecionada, desmarque-a
            isSelected = false;

            // Restaure a cor original da esfera (ou outra cor)
            GetComponent<Renderer>().material.color = Color.white;

            // Subtraia da contagem de esferas selecionadas
            GameManager.instance.selectedSpheres--;

            // Oculte o nome da esfera
            nameText.gameObject.SetActive(false);
        }
    }
}