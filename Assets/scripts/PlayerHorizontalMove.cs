using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMover : MonoBehaviour
{
    public float speed, minX, maxX; // Velocidad de movimiento, límites mínimo y máximo en el eje X
    private float axisX; // Entrada horizontal del jugador (izquierda/derecha)
    public Rigidbody2D rb; // Componente Rigidbody2D del jugador para aplicar física
    public GameObject BalaPrefab; // Prefabricado de la bala que el jugador disparará
    public Transform shooter; // Posición desde donde se dispara la bala (generalmente una mano o el cañón del jugador)

    void Start()
    {
        // Este método está vacío, pero puedes usarlo para inicializar variables si fuera necesario
    }

    // Update se llama una vez por cada frame
    void Update()
    {
        // Movimiento horizontal:
        // Captura la entrada horizontal (izquierda o derecha) del jugador
        axisX = Input.GetAxisRaw("Horizontal");

        // Aplica la velocidad al Rigidbody2D en el eje X, manteniendo la velocidad en el eje Y en 0 (sin movimiento vertical)
        rb.velocity = new Vector2(speed * axisX, 0);

        // Limitar el movimiento del jugador dentro de los límites especificados por minX y maxX:
        // Utiliza Mathf.Clamp para restringir la posición en el eje X entre los valores mínimo y máximo
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);

        // Disparo de la bala:
        // Si el jugador presiona el botón izquierdo del mouse (código 0)
        if (Input.GetMouseButtonDown(0))
        {
            // Instancia el prefab de la bala en la posición del "shooter" (desde donde se dispara), con la rotación original de la bala
            Instantiate(BalaPrefab, shooter.position, BalaPrefab.transform.rotation);
        }
    }
}
