using UnityEngine;

public class ToggleCameraButton : MonoBehaviour
{
    public Camera arCamera; // Arraste a c�mera ARCamera para esta vari�vel no Inspector
    public Camera cameraArduino; // Arraste a c�mera CameraArduino para esta vari�vel no Inspector

    private void Start()
    {
        // Verifique qual c�mera est� ativa no in�cio e ative/desative o bot�o adequadamente
        UpdateButtonVisibility();
    }

    private void Update()
    {
        // Verifique qual c�mera est� ativa continuamente e ative/desative o bot�o adequadamente
        UpdateButtonVisibility();
    }

    private void UpdateButtonVisibility()
    {
        // Verifique qual c�mera est� ativa
        bool isARCameraActive = arCamera.enabled;
        bool isCameraArduinoActive = cameraArduino.enabled;

        // Ative ou desative o bot�o com base na c�mera ativa
        gameObject.SetActive(isCameraArduinoActive);
    }
}