using UnityEngine;
using TMPro;
using System.Collections;

public class Erro : MonoBehaviour
{
    public TMP_Text errorText;

    private void Start()
    {
        // Desativa o texto de erro no início
        errorText.gameObject.SetActive(false);
    }

    public void ShowError(string message)
    {
        // Define o texto de erro e o ativa
        errorText.gameObject.SetActive(true);

        // Inicia uma coroutine para ocultar o texto após 5 segundos
        StartCoroutine(HideErrorAfterDelay(5f));
    }

    public void HideError()
    {
        // Desativa o texto de erro
        errorText.gameObject.SetActive(false);
    }

    private IEnumerator HideErrorAfterDelay(float delay)
    {
        // Aguarda o período de atraso especificado
        yield return new WaitForSeconds(delay);

        // Oculta o texto de erro após o atraso
        HideError();
    }
}