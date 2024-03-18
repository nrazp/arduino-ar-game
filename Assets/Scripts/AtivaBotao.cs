using UnityEngine;

public class ToggleCameraButton : MonoBehaviour
{
    public Camera arCamera; // Arraste a câmera ARCamera para esta variável no Inspector
    public Camera cameraArduino; // Arraste a câmera CameraArduino para esta variável no Inspector

    private void Start()
    {
        // Verifique qual câmera está ativa no início e ative/desative o botão adequadamente
        UpdateButtonVisibility();
    }

    private void Update()
    {
        // Verifique qual câmera está ativa continuamente e ative/desative o botão adequadamente
        UpdateButtonVisibility();
    }

    private void UpdateButtonVisibility()
    {
        // Verifique qual câmera está ativa
        bool isARCameraActive = arCamera.enabled;
        bool isCameraArduinoActive = cameraArduino.enabled;

        // Ative ou desative o botão com base na câmera ativa
        gameObject.SetActive(isCameraArduinoActive);
    }
}