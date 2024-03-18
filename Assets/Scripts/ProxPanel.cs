using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProxPanel : MonoBehaviour
{
    public TMP_Text textMeshPro; // Arraste o TextMeshPro Pro para esta vari�vel no Inspector
    public Button buttonChangeText; // Arraste o bot�o de troca de texto no Inspector
    public Button closeButton; // Arraste o bot�o de fechamento no Inspector
    public GameObject panel; // Arraste o painel para esta vari�vel no Inspector

    private bool isTextButtonActive = true;

    private void Start()
    {
        // Adicione ouvintes de clique aos bot�es
        buttonChangeText.onClick.AddListener(ChangeText);
        closeButton.onClick.AddListener(ClosePanel);
        closeButton.gameObject.SetActive(false);
    }

    private void ChangeText()
    {
        // Altere o texto do TextMeshPro Pro para o novo conte�do desejado
        textMeshPro.text = "Passo 1 - Clicar no Arduino UNO para escolha da pinagem que ser� utilizada para conex�o na Ponte H";

        // Troque a visibilidade dos bot�es
        buttonChangeText.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);

        isTextButtonActive = false;
    }

    public void ClosePanel()
    {
        // Desative o painel
        panel.SetActive(false);
    }
}