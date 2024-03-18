using UnityEngine;

public class SphereConnection : MonoBehaviour
{
    public Transform sphereDestino; // Transform da esfera de destino
    private bool connected = false;
    private Drag dragScript; // Referência ao script Drag

    void Start()
    {
        // Obtém o componente Drag no objeto pai
        dragScript = GetComponentInParent<Drag>();
    }

    void Update()
    {
        if (!connected && dragScript != null && dragScript.isDraggable)
        {
            // Verifique se a esfera de conexão está próxima o suficiente da esfera de destino para ser conectada
            float distance = Vector3.Distance(transform.position, sphereDestino.position);

            if (distance < 0.5f) // Ajuste o valor conforme necessário
            {
                // Conecte a esfera de destino à esfera de conexão
                Connect();

                // Desative o arraste no objeto pai
                dragScript.isDraggable = false;

                // Defina isConnected para true no script Drag
                dragScript.isConnected = true;

                // Debug para verificar a conexão
                Debug.Log("Conexão feita! Arraste desativado.");
            }
        }
    }

    void Connect()
    {
        // Realize as ações necessárias para conectar a esfera de destino à esfera de conexão
        // Por exemplo, ajuste a posição e a hierarquia dos objetos
        sphereDestino.parent = transform;
        sphereDestino.localPosition = Vector3.zero;

        // Marque como conectado para evitar repetidas chamadas
        connected = true;
    }
}