using UnityEngine;

public class SphereConnection : MonoBehaviour
{
    public Transform sphereDestino; // Transform da esfera de destino
    private bool connected = false;
    private Drag dragScript; // Refer�ncia ao script Drag

    void Start()
    {
        // Obt�m o componente Drag no objeto pai
        dragScript = GetComponentInParent<Drag>();
    }

    void Update()
    {
        if (!connected && dragScript != null && dragScript.isDraggable)
        {
            // Verifique se a esfera de conex�o est� pr�xima o suficiente da esfera de destino para ser conectada
            float distance = Vector3.Distance(transform.position, sphereDestino.position);

            if (distance < 0.5f) // Ajuste o valor conforme necess�rio
            {
                // Conecte a esfera de destino � esfera de conex�o
                Connect();

                // Desative o arraste no objeto pai
                dragScript.isDraggable = false;

                // Defina isConnected para true no script Drag
                dragScript.isConnected = true;

                // Debug para verificar a conex�o
                Debug.Log("Conex�o feita! Arraste desativado.");
            }
        }
    }

    void Connect()
    {
        // Realize as a��es necess�rias para conectar a esfera de destino � esfera de conex�o
        // Por exemplo, ajuste a posi��o e a hierarquia dos objetos
        sphereDestino.parent = transform;
        sphereDestino.localPosition = Vector3.zero;

        // Marque como conectado para evitar repetidas chamadas
        connected = true;
    }
}