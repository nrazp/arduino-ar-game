using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeletorNivel : MonoBehaviour
{
    public Button nivel1Button;
    public Button nivel2Button;
    public Button voltarButton;

    private void Start()
    {
        // Adicione os m�todos de callback aos bot�es
        nivel1Button.onClick.AddListener(AbrirNivel1);
        nivel2Button.onClick.AddListener(AbrirNivel2);
        voltarButton.onClick.AddListener(VoltarMainMenu);
    }

    // M�todo para abrir a cena de sele��o de n�veis
    private void AbrirNivel1()
    {
        SceneManager.LoadScene("Nivel1"); // Substitua "LevelSelect" pelo nome da sua cena de sele��o de n�veis
    }

    // M�todo para abrir a cena de cr�ditos
    private void AbrirNivel2()
    {
        SceneManager.LoadScene(4);//SceneManager.LoadScene("Creditos"); // Substitua "Creditos" pelo nome da sua cena de cr�ditos
    }

    // M�todo para voltar ao menu principal do jogo
    private void VoltarMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}