using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Importa la librería de Unity para trabajar con luces 2D en el sistema Universal Render Pipeline

public class PlayerLight : MonoBehaviour
{
    public Light2D flashlight; // Componente Light2D que representa la linterna
    private Vector3 mousePos; // Variable para almacenar la posición del mouse en el mundo del juego

    void Start()
    {
        // No se realiza ninguna acción en el inicio, se podría usar para inicializaciones si fuera necesario
    }

    // Update se llama una vez por cada frame
    void Update()
    {
        // Si se presiona el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Si la intensidad de la linterna es 0 (apagada), la enciende
            if (flashlight.intensity == 0) flashlight.intensity = 1;
            // Si la linterna está encendida (intensidad = 1), la apaga
            else if (flashlight.intensity == 1) flashlight.intensity = 0;
        }

        // Convierte la posición del mouse en la pantalla en una posición en el mundo del juego
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula la distancia entre el cursor del mouse y la posición del jugador
        Vector3 distance = mousePos - transform.position;

        // Calcula los grados de rotación necesarios para apuntar la linterna hacia el mouse
        float rotZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;

        // Aplica la rotación calculada a la linterna para que apunte hacia el mouse
        flashlight.transform.rotation = Quaternion.Euler(0, 0, rotZ - 90); // Resta 90 para ajustar la rotación de la linterna
    }
}

