using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text textMeshPro;
    public TMP_Text Titulo;
    public GameObject panel;
    public Erro errorTextObject;
    public float novoTamanho = 100f;
    public Button nivelButton;
    public Button closeButton;

    public Camera arCamera;
    public Camera cameraArduino;
    public int selectedSpheres = 0;
    public int popUp = 0;
    public int n = 3;
    public string currentSceneName;

    public Drag PonteH;
    public Drag MotorDc;
    public Drag Servo;
    public Drag SU;

    public string[] correctSphereNames;
    public int correctSpheresSelected = 0;

    public SwitchCameraNvl2 switchCameraScript;

    private void Start()
    {
        nivelButton.onClick.AddListener(ChangeScene);
        nivelButton.gameObject.SetActive(false);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        currentSceneName = SceneManager.GetActiveScene().name;

        // Defina o array correto com base na cena atual
        if (currentSceneName == "Nivel1")
        {
            correctSphereNames = new string[] { "5V", "5V 2", "GND", "GND 2" };
        }
        else if (currentSceneName == "Nivel2")
        {
            correctSphereNames = new string[] { "5V", "5V 2", "GND", "GND 2", "D6" };
        }
    }

    private void Update()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        if (string.IsNullOrEmpty(currentSceneName))
        {
            Debug.LogError("currentSceneName is null or empty.");
            return;
        }

        if (selectedSpheres == n)
        {
            int correctSpheresSelected = 0;

            foreach (var sphere in GameObject.FindGameObjectsWithTag("Sphere"))
            {
                var sphereNameComponent = sphere.GetComponent<ShowSphereNameOnHover>();

                if (sphereNameComponent != null)
                {
                    Debug.Log("Sphere: " + sphere.name + " isSelected: " + sphereNameComponent.isSelected);

                    if (sphereNameComponent.isSelected && IsCorrectSphere(sphere))
                    {
                        correctSpheresSelected++;
                    }
                }
                else
                {
                    Debug.LogError("Sphere: " + sphere.name + " does not have ShowSphereNameOnHover component!");
                }
            }


            if (correctSpheresSelected == n)
            {

                if (popUp == 0)
                {
                    panel.SetActive(true);
                    // Ativa a c�mera ARCamera
                    arCamera.enabled = true;

                    // Desativa a c�mera CameraArduino
                    cameraArduino.enabled = false;

                    // Altere o texto do TextMeshPro Pro para o novo conte�do desejado
                    if (currentSceneName == "Nivel1")
                    {
                        textMeshPro.text = "Passo 3 - Arrastar a ponte H com o mouse para conecta-la aos cabos jumpers do Arduino UNO";
                    }
                    else
                    {
                        textMeshPro.text = "Passo 3 - Arrastar o Servomotor com o mouse para conecta-la aos cabos jumpers do Arduino UNO";
                    }
                    popUp++;
                }
                else
                {
                    if (popUp == 1)
                    {
                        if (PonteH != null && !PonteH.isDraggable)
                        {
                            // Se isDraggable for falso no objeto espec�fico, incremente a vari�vel popUp
                            popUp++;
                        }
                        if (Servo != null  && !Servo.isDraggable)
                        {
                            switchCameraScript.isStep3Complete = true;
                            popUp++;
                            selectedSpheres = 0;
                            // Deselecionar todas as esferas
                            foreach (var sphere in GameObject.FindGameObjectsWithTag("Sphere"))
                            {
                                var sphereNameComponent = sphere.GetComponent<ShowSphereNameOnHover>();

                                if (sphereNameComponent != null && sphereNameComponent.isSelected)
                                {
                                    sphereNameComponent.isSelected = false;
                                    // Restaure a cor original da esfera (outra cor)
                                    sphere.GetComponent<Renderer>().material.color = Color.red;
                                }
                            }
                            correctSpheresSelected = 0;
                            correctSphereNames = new string[] { "5V", "5V 2", "GND", "GND 2", "D5", "D7"};
                            n = 4;
                        }
                    }
                    if (popUp == 2)
                    {
                        if (currentSceneName == "Nivel1")
                        {
                            textMeshPro.text = "Passo 4 - Arrastar o Motor DC com o mouse para conecta-lo aos cabos jumpers da Ponte H - Esses cabos jumpers est�o conectados as portas out + e out - da ponte H";
                        }
                        else
                        {
                            textMeshPro.text = "Passo 4 - Clique no Arduino para escolha da pinagem a ser utilizada no Sensor Ultrass�nico";
                        }
                        panel.SetActive(true);
                        popUp++;
                    }
                    if (popUp == 3)
                    {
                        if (currentSceneName == "Nivel1")
                        {
                            if (MotorDc != null && !MotorDc.isDraggable)
                            {
                                // Se isDraggable for falso no objeto espec�fico, incremente a vari�vel popUp
                                popUp++;
                            }
                        }
                        else
                        {
                            if (switchCameraScript.isStep4Complete == true)
                            {
                                textMeshPro.text = "Passo 6 - Arraste o Sensor Ultrass�nico com o mouse para conecta-lo aos cabos jumpers do Arduino UNO";
                                panel.SetActive(true);
                                // Ativa a c�mera ARCamera
                                arCamera.enabled = true;

                                // Desativa a c�mera CameraArduino
                                cameraArduino.enabled = false;
                                popUp++;
                            }
                        }
                    }
                    if (popUp == 4)
                    {
                        if (currentSceneName == "Nivel1")
                        {
                            Titulo.text = "Parab�ns";
                            Titulo.fontSize = 80f;
                            textMeshPro.text = "Voc� Concluiu o n�vel! Nesse n�vel voc� aprendeu que para controlar um motor DC com um Arduino � necess�rio um intermediador, conhecido como driver (Ponte H). Esse driver � respons�vel pelo controle da dire��o da corrente e da tens�o entregue ao motor DC, desta maneira poder� controlar a velocidade e dire��o do motor.";
                            panel.SetActive(true);
                            // Troque a visibilidade dos bot�es
                            nivelButton.gameObject.SetActive(true);
                            closeButton.gameObject.SetActive(false);
                        }
                        if (currentSceneName == "Nivel2")
                        {
                            if(SU != null && !SU.isDraggable)
                            {
                                Titulo.text = "Parab�ns";
                                Titulo.fontSize = 80f;
                                textMeshPro.text = "Voc� Concluiu o n�vel! Nesse n�vel voc� aprendeu as conex�es que devem ser realizadas para se concetar um servo motor e um sensor ultrass�nico a um Arduino UNO";
                                // Troque a visibilidade dos bot�es
                                panel.SetActive(true);
                                nivelButton.gameObject.SetActive(true);
                                closeButton.gameObject.SetActive(false);
                            }
                        }
                    }
                }
            }
            else
            {
                // Mostra a mensagem de erro com um atraso de 5 segundos
                errorTextObject.ShowError("Voc� selecionou as esferas erradas! Tente Novamente");

                // Desativa todas as esferas selecionadas
                foreach (var sphere in GameObject.FindGameObjectsWithTag("Sphere"))
                {
                    Debug.Log("popUp: " + popUp);
                    Debug.Log("PonteH is null: " + (PonteH == null));
                    if (sphere.GetComponent<ShowSphereNameOnHover>().isSelected)
                    {
                        sphere.GetComponent<ShowSphereNameOnHover>().isSelected = false;
                        // Restaure a cor original da esfera (outra cor)
                        sphere.GetComponent<Renderer>().material.color = Color.red;
                    }
                }

                // Redefina a contagem de esferas selecionadas
                selectedSpheres = 0;
            }
        }
    }

    private bool IsCorrectSphere(GameObject sphere)
    {
        // Verifique se o nome da esfera est� na lista de nomes corretos
        return System.Array.Exists(correctSphereNames, name => name == sphere.name);
    }


    public void ChangeScene()
    {
        if (currentSceneName == "Nivel1")
        {
            selectedSpheres = 0;
            // Deselecionar todas as esferas
            foreach (var sphere in GameObject.FindGameObjectsWithTag("Sphere"))
            {
                var sphereNameComponent = sphere.GetComponent<ShowSphereNameOnHover>();

                if (sphereNameComponent != null && sphereNameComponent.isSelected)
                {
                    sphereNameComponent.isSelected = false;
                    // Restaure a cor original da esfera (outra cor)
                    sphere.GetComponent<Renderer>().material.color = Color.red;
                }
            }
            popUp = 0;
            nivelButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
            selectedSpheres = 0;
            correctSpheresSelected = 0;
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

