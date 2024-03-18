using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public Button voltarButton;

    private void Start()
    {
        // Adicione os m�todos de callback aos bot�es
        voltarButton.onClick.AddListener(VoltarMainMenu);
    }

    // M�todo para voltar ao menu principal do jogo
    private void VoltarMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}