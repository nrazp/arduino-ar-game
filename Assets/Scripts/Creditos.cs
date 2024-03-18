using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public Button voltarButton;

    private void Start()
    {
        // Adicione os métodos de callback aos botões
        voltarButton.onClick.AddListener(VoltarMainMenu);
    }

    // Método para voltar ao menu principal do jogo
    private void VoltarMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}