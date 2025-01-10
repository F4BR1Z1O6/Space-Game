using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Importa la librer�a de Unity para trabajar con luces 2D en el sistema Universal Render Pipeline

public class PlayerLight : MonoBehaviour
{
    public Light2D flashlight; // Componente Light2D que representa la linterna
    private Vector3 mousePos; // Variable para almacenar la posici�n del mouse en el mundo del juego

    void Start()
    {
        // No se realiza ninguna acci�n en el inicio, se podr�a usar para inicializaciones si fuera necesario
    }

    // Update se llama una vez por cada frame
    void Update()
    {
        // Si se presiona el bot�n izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Si la intensidad de la linterna es 0 (apagada), la enciende
            if (flashlight.intensity == 0) flashlight.intensity = 1;
            // Si la linterna est� encendida (intensidad = 1), la apaga
            else if (flashlight.intensity == 1) flashlight.intensity = 0;
        }

        // Convierte la posici�n del mouse en la pantalla en una posici�n en el mundo del juego
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula la distancia entre el cursor del mouse y la posici�n del jugador
        Vector3 distance = mousePos - transform.position;

        // Calcula los grados de rotaci�n necesarios para apuntar la linterna hacia el mouse
        float rotZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;

        // Aplica la rotaci�n calculada a la linterna para que apunte hacia el mouse
        flashlight.transform.rotation = Quaternion.Euler(0, 0, rotZ - 90); // Resta 90 para ajustar la rotaci�n de la linterna
    }
}

