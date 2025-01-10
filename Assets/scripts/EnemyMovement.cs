using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed; // Velocidad de movimiento del enemigo
    public float fallUnits; // Cantidad de unidades que el enemigo caer� al cambiar de direcci�n
    private int direction = 1; // Direcci�n inicial de movimiento (1 = derecha, -1 = izquierda)
    private Rigidbody2D rb; // Componente Rigidbody2D que controla la f�sica del enemigo

    void Start()
    {
        // Obtiene el componente Rigidbody2D del objeto al que est� adjunto este script
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Actualiza la velocidad del Rigidbody2D, moviendo al enemigo en la direcci�n especificada por 'direction'
        rb.velocity = new Vector2(speed * direction, 0);
    }

    // M�todo p�blico para cambiar la direcci�n del enemigo
    public void ChangeDirection(int value)
    {
        // Cambia la direcci�n a la que se mover� el enemigo (valor 1 para derecha, -1 para izquierda)
        direction = value;

        // Cambia la posici�n del enemigo en el eje Y, movi�ndolo hacia abajo por la cantidad de 'fallUnits'
        transform.position = new Vector2(transform.position.x, transform.position.y - fallUnits);
    }
}

