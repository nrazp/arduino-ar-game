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
        // Adicione os métodos de callback aos botões
        nivel1Button.onClick.AddListener(AbrirNivel1);
        nivel2Button.onClick.AddListener(AbrirNivel2);
        voltarButton.onClick.AddListener(VoltarMainMenu);
    }

    // Método para abrir a cena de seleção de níveis
    private void AbrirNivel1()
    {
        SceneManager.LoadScene("Nivel1"); // Substitua "LevelSelect" pelo nome da sua cena de seleção de níveis
    }

    // Método para abrir a cena de créditos
    private void AbrirNivel2()
    {
        SceneManager.LoadScene(4);//SceneManager.LoadScene("Creditos"); // Substitua "Creditos" pelo nome da sua cena de créditos
    }

    // Método para voltar ao menu principal do jogo
    private void VoltarMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}