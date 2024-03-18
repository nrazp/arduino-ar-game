using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button jogarButton;
    public Button creditosButton;
    public Button sairButton;

    private void Start()
    {
        // Adicione os m�todos de callback aos bot�es
        jogarButton.onClick.AddListener(AbrirLevelSelect);
        creditosButton.onClick.AddListener(AbrirCreditos);
        sairButton.onClick.AddListener(SairDoJogo);
    }

    // M�todo para abrir a cena de sele��o de n�veis
    private void AbrirLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect"); // Substitua "LevelSelect" pelo nome da sua cena de sele��o de n�veis
    }

    // M�todo para abrir a cena de cr�ditos
    private void AbrirCreditos()
    {
        SceneManager.LoadScene("Creditos"); // Substitua "Creditos" pelo nome da sua cena de cr�ditos
    }

    // M�todo para sair do jogo
    private void SairDoJogo()
    {
        Application.Quit();
    }
}