using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUp : MonoBehaviour
{
    public TMP_Text TextoObjetivo;
    public TMP_Text TextoDescri;
    public Button fecharButton;

    private void Start()
    {
        // Inicialmente, desative o painel do pop-up
        gameObject.SetActive(true);

        // Adicione um ouvinte de clique para o botão de fechar
        fecharButton.onClick.AddListener(ClosePopup);
    }

    public void ShowPopup()
    {
        // Ative o painel do pop-up e defina o texto da mensagem
        gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        // Feche o pop-up desativando o painel
        gameObject.SetActive(false);
    }
}