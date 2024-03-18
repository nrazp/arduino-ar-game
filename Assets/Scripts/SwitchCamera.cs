using UnityEngine;
using TMPro;

public class SwitchCamera : MonoBehaviour
{
    public Camera arCamera; // Arraste a câmera ARCamera para esta variável no Inspector
    public Camera cameraArduino; // Arraste a câmera CameraArduino para esta variável no Inspector
    public GameObject modelToClick; // Arraste o modelo 3D alvo para esta variável no Inspector
    public GameObject[] spheresToActivate; // Arraste as esferas que devem ser ativadas no Inspector
    public TMP_Text nameText; // Referência ao objeto de TextMeshPro para exibir o nome
    public GameObject panel; // Arraste o painel para esta variável no Inspector
    public TMP_Text textMeshPro; // Arraste o TextMeshPro Pro para esta variável no Inspector


    // Esta função é chamada uma vez quando o objeto é inicializado
    void Awake()
    {
        // Desative a câmera CameraArduino no início do jogo
        cameraArduino.enabled = false;
    }

    private void Start()
    {
        // Desative inicialmente as esferas
        foreach (var sphere in spheresToActivate)
        {
            sphere.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        // Desative a câmera ARCamera
        arCamera.enabled = false;

        // Ative a câmera CameraArduino
        cameraArduino.enabled = true;

        textMeshPro.text = "Passo 2 - Clique nas Esferas que representam os pinos que serão utilizados (5V, 5V e GND) - A ponte H deve ser conectada a dois pinos de alimentação (5V e GND) que serão conectadas as portas Vcc e GND da Ponte H. Enquanto que o outro pino 5V entrará na porta Vl da Ponte H";
        panel.SetActive(true);

        // Ative as esferas quando o modelo 3D é clicado
        foreach (var sphere in spheresToActivate)
        {
            sphere.SetActive(true);
            // Configure o nome da esfera no objeto TextMeshPro
            string sphereName = sphere.name;
            nameText.text = sphereName;
            nameText.gameObject.SetActive(true);
        }
    }
}