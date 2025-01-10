using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed; // Velocidad de movimiento del enemigo
    public float fallUnits; // Cantidad de unidades que el enemigo caerá al cambiar de dirección
    private int direction = 1; // Dirección inicial de movimiento (1 = derecha, -1 = izquierda)
    private Rigidbody2D rb; // Componente Rigidbody2D que controla la física del enemigo

    void Start()
    {
        // Obtiene el componente Rigidbody2D del objeto al que está adjunto este script
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Actualiza la velocidad del Rigidbody2D, moviendo al enemigo en la dirección especificada por 'direction'
        rb.velocity = new Vector2(speed * direction, 0);
    }

    // Método público para cambiar la dirección del enemigo
    public void ChangeDirection(int value)
    {
        // Cambia la dirección a la que se moverá el enemigo (valor 1 para derecha, -1 para izquierda)
        direction = value;

        // Cambia la posición del enemigo en el eje Y, moviéndolo hacia abajo por la cantidad de 'fallUnits'
        transform.position = new Vector2(transform.position.x, transform.position.y - fallUnits);
    }
}

