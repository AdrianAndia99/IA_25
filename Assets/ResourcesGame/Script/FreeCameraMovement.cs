using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    // Variables para el movimiento
    public float velocidadMovimiento = 5f;
    public float sensibilidadMouse = 2f;

    // Variables para el giro de la cámara
    private float rotacionVertical = 0f;
    private float rotacionHorizontal = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
    void Update()
    {
        // Movimiento (WASD o teclas de flecha)
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;

        // Movimiento del jugador (cámara se mueve junto con el jugador)
        transform.Translate(movimientoHorizontal, 0, movimientoVertical);

        // Rotación del mouse (cámara mirando alrededor)
        rotacionHorizontal += Input.GetAxis("Mouse X") * sensibilidadMouse;
        rotacionVertical -= Input.GetAxis("Mouse Y") * sensibilidadMouse;

        // Limitar la rotación vertical de la cámara (para evitar un giro completo)
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90f, 90f);

        // Rotación horizontal (el jugador puede mirar de izquierda a derecha)
        transform.rotation = Quaternion.Euler(0, rotacionHorizontal, 0);

        // Rotación vertical (la cámara se mueve hacia arriba y hacia abajo)
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionVertical, rotacionHorizontal, 0);
    }
}
