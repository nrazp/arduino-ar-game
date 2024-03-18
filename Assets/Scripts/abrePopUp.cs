using UnityEngine;
using UnityEngine.UI;

public class OpenPopupButton : MonoBehaviour
{
    public PopUp popup; // Referência ao objeto que contém o script PopUp
    public Button popUpButton;

    private void Start()
    {
        // Adicione um ouvinte de clique para o botão "popUpButton"
        popUpButton.onClick.AddListener(OpenPopup);
    }

    private void OpenPopup()
    {
        // Abra o pop-up de mensagem de objetivo
        popup.ShowPopup();
    }
}