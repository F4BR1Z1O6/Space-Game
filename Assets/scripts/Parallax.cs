using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed; // Velocidad de movimiento de la textura para crear el efecto de parallax
    private Renderer rnd; // Componente Renderer para acceder a la textura del objeto
    private float value; // Valor acumulado para mover la textura

    void Start()
    {
        // Inicializa el componente Renderer para poder acceder a la textura
        rnd = GetComponent<Renderer>();
    }

    void Update()
    {
        // Acumula el valor de "value" sumando la velocidad multiplicada por el tiempo
        value += (speed / 10 * Time.deltaTime);

        // Actualiza la posición de la textura en el eje X para crear el movimiento de parallax
        rnd.material.mainTextureOffset = new Vector2(value, 0);
    }
}
