using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VoltaMenu : MonoBehaviour
{
    public Button menuButton;

    private void Start()
    {
        // Adicione um ouvinte de clique para chamar a fun��o VoltarAoMenu quando o bot�o for clicado
        menuButton.onClick.AddListener(VoltarAoMenu);
    }

    private void VoltarAoMenu()
    {
        // Carregue a cena do menu principal
        SceneManager.LoadScene("MainMenu"); // Substitua "MenuPrincipal" pelo nome da sua cena do menu principal
    }
}