using UnityEngine;
using UnityEngine.UI;

public class OpenPopupButton : MonoBehaviour
{
    public PopUp popup; // Refer�ncia ao objeto que cont�m o script PopUp
    public Button popUpButton;

    private void Start()
    {
        // Adicione um ouvinte de clique para o bot�o "popUpButton"
        popUpButton.onClick.AddListener(OpenPopup);
    }

    private void OpenPopup()
    {
        // Abra o pop-up de mensagem de objetivo
        popup.ShowPopup();
    }
}