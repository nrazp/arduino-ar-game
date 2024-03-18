using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;
    public bool isDraggable = true;
    public bool isConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetDraggable(bool draggable)
    {
        isDraggable = draggable;
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (!isConnected)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            // Adicione a entrada do scroll do mouse ao eixo Z da posição do objeto
            Vector3 newPosition = new Vector3(
                transform.position.x + Input.GetAxis("Mouse X"),
                transform.position.y,
                transform.position.z + Input.GetAxis("Mouse Y")
            );

            // Atualize a posição do objeto
            transform.position = newPosition;

            // Defina o Rigidbody como cinemático enquanto arrasta
            rb.isKinematic = true;
        }
    }

    private void OnMouseUp()
    {
        // Restaure a cinemática do Rigidbody quando o mouse for solto
        rb.isKinematic = false;
    }
}