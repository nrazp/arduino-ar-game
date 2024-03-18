using UnityEngine;
using TMPro;

public class SwitchCameraNvl2 : MonoBehaviour
{
    public Camera arCamera; // Arraste a câmera ARCamera para esta variável no Inspector
    public Camera cameraArduino; // Arraste a câmera CameraArduino para esta variável no Inspector
    public GameObject modelToClick; // Arraste o modelo 3D alvo para esta variável no Inspector
    public GameObject[] spheresToActivate; // Arraste as esferas que devem ser ativadas no Inspector
    public TMP_Text nameText; // Referência ao objeto de TextMeshPro para exibir o nome
    public GameObject panel; // Arraste o painel para esta variável no Inspector
    public TMP_Text textMeshPro; // Arraste o TextMeshPro Pro para esta variável no Inspector
    public bool isStep3Complete = false;
    public bool isStep4Complete = false;
    public GameObject[] cabosToActivate;

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
        nameText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Desative a câmera ARCamera
        arCamera.enabled = false;

        // Ative a câmera CameraArduino
        cameraArduino.enabled = true;

        if (isStep3Complete == false)
        {
            textMeshPro.text = "Passo 2 - Clique nas Esferas que representam os pinos que serão utilizados (5V, GND e D6) - O servomotor se utiliza de dois pinos de alimentação (5V e GND) e um pino de saída de onda PWM";

        }
        else
        {

            textMeshPro.text = "Passo 5 - Clique nas Esferas que representam os pinos que serão utilizados (5V, GND, D7 e D5) - O sensor ultrassônico se utiliza de dois pinos de alimentação (5V e GND) e dois pinos de saídas digitais";
            // Desative inicialmente os cabos
            foreach (var cabo in cabosToActivate)
            {
                cabo.SetActive(false);
            }
            isStep4Complete= true;
        }

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