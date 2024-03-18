using UnityEngine;
using TMPro;

public class ShowSphereNameOnHover : MonoBehaviour
{
    public TMP_Text nameText; // Referência ao objeto de TextMeshPro para exibir o nome
    public string sphereName; // Nome da esfera associada a este objeto
    public bool isSelected = false; // Indica se a esfera está selecionada



    private void Start()
    {
        // Desative o texto inicialmente
        nameText.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        // Mostrar o nome da esfera quando o mouse passar por cima
        nameText.text = sphereName;
        nameText.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        // Ocultar o nome quando o mouse sair da esfera
        nameText.gameObject.SetActive(false);
    }

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