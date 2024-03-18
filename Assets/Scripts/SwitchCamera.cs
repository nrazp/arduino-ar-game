using UnityEngine;
using TMPro;

public class SwitchCamera : MonoBehaviour
{
    public Camera arCamera; // Arraste a c�mera ARCamera para esta vari�vel no Inspector
    public Camera cameraArduino; // Arraste a c�mera CameraArduino para esta vari�vel no Inspector
    public GameObject modelToClick; // Arraste o modelo 3D alvo para esta vari�vel no Inspector
    public GameObject[] spheresToActivate; // Arraste as esferas que devem ser ativadas no Inspector
    public TMP_Text nameText; // Refer�ncia ao objeto de TextMeshPro para exibir o nome
    public GameObject panel; // Arraste o painel para esta vari�vel no Inspector
    public TMP_Text textMeshPro; // Arraste o TextMeshPro Pro para esta vari�vel no Inspector


    // Esta fun��o � chamada uma vez quando o objeto � inicializado
    void Awake()
    {
        // Desative a c�mera CameraArduino no in�cio do jogo
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
        // Desative a c�mera ARCamera
        arCamera.enabled = false;

        // Ative a c�mera CameraArduino
        cameraArduino.enabled = true;

        textMeshPro.text = "Passo 2 - Clique nas Esferas que representam os pinos que ser�o utilizados (5V, 5V e GND) - A ponte H deve ser conectada a dois pinos de alimenta��o (5V e GND) que ser�o conectadas as portas Vcc e GND da Ponte H. Enquanto que o outro pino 5V entrar� na porta Vl da Ponte H";
        panel.SetActive(true);

        // Ative as esferas quando o modelo 3D � clicado
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