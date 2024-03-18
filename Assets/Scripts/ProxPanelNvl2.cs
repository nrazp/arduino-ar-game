using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProxPanelNvl2 : MonoBehaviour
{
    public TMP_Text textMeshPro; // Arraste o TextMeshPro Pro para esta variável no Inspector
    public Button buttonChangeText; // Arraste o botão de troca de texto no Inspector
    public Button closeButton; // Arraste o botão de fechamento no Inspector
    public GameObject panel; // Arraste o painel para esta variável no Inspector

    private bool isTextButtonActive = true;

    private void Start()
    {
        // Adicione ouvintes de clique aos botões
        buttonChangeText.onClick.AddListener(ChangeText);
        closeButton.onClick.AddListener(ClosePanel);
        closeButton.gameObject.SetActive(false);
    }

    private void ChangeText()
    {
        // Altere o texto do TextMeshPro Pro para o novo conteúdo desejado
        textMeshPro.text = "Passo 1 - Clicar no Arduino UNO para escolha da pinagem que será utilizada para conexão no Servo Motor";

        // Troque a visibilidade dos botões
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