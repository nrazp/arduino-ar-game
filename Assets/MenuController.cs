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
        // Adicione os métodos de callback aos botões
        jogarButton.onClick.AddListener(AbrirLevelSelect);
        creditosButton.onClick.AddListener(AbrirCreditos);
        sairButton.onClick.AddListener(SairDoJogo);
    }

    // Método para abrir a cena de seleção de níveis
    private void AbrirLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect"); // Substitua "LevelSelect" pelo nome da sua cena de seleção de níveis
    }

    // Método para abrir a cena de créditos
    private void AbrirCreditos()
    {
        SceneManager.LoadScene("Creditos"); // Substitua "Creditos" pelo nome da sua cena de créditos
    }

    // Método para sair do jogo
    private void SairDoJogo()
    {
        Application.Quit();
    }
}