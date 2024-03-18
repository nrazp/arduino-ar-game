using UnityEngine;

public class ActivateSpheresOnModelClick : MonoBehaviour
{
    public GameObject modelToClick; // Arraste o modelo 3D alvo para esta variável no Inspector
    public GameObject[] spheresToActivate; // Arraste as esferas que devem ser ativadas no Inspector

    private void Start()
    {
        // Desative inicialmente as esferas
        foreach (var sphere in spheresToActivate)
        {
            sphere.SetActive(false);
        }
    }

    private void Update()
    {
        // Verifique se o jogador clicou no modelo 3D
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}