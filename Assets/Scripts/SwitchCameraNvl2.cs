using UnityEngine;
using TMPro;

public class SwitchCameraNvl2 : MonoBehaviour
{
    public Camera arCamera; // Arraste a c�mera ARCamera para esta vari�vel no Inspector
    public Camera cameraArduino; // Arraste a c�mera CameraArduino para esta vari�vel no Inspector
    public GameObject modelToClick; // Arraste o modelo 3D alvo para esta vari�vel no Inspector
    public GameObject[] spheresToActivate; // Arraste as esferas que devem ser ativadas no Inspector
    public TMP_Text nameText; // Refer�ncia ao objeto de TextMeshPro para exibir o nome
    public GameObject panel; // Arraste o painel para esta vari�vel no Inspector
    public TMP_Text textMeshPro; // Arraste o TextMeshPro Pro para esta vari�vel no Inspector
    public bool isStep3Complete = false;
    public bool isStep4Complete = false;
    public GameObject[] cabosToActivate;

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
        nameText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Desative a c�mera ARCamera
        arCamera.enabled = false;

        // Ative a c�mera CameraArduino
        cameraArduino.enabled = true;

        if (isStep3Complete == false)
        {
            textMeshPro.text = "Passo 2 - Clique nas Esferas que representam os pinos que ser�o utilizados (5V, GND e D6) - O servomotor se utiliza de dois pinos de alimenta��o (5V e GND) e um pino de sa�da de onda PWM";

        }
        else
        {

            textMeshPro.text = "Passo 5 - Clique nas Esferas que representam os pinos que ser�o utilizados (5V, GND, D7 e D5) - O sensor ultrass�nico se utiliza de dois pinos de alimenta��o (5V e GND) e dois pinos de sa�das digitais";
            // Desative inicialmente os cabos
            foreach (var cabo in cabosToActivate)
            {
                cabo.SetActive(false);
            }
            isStep4Complete= true;
        }

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