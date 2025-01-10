using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    public float speed; // Velocidad a la que la bala se mueve
    private Rigidbody2D rb; // Componente Rigidbody2D para controlar la física de la bala

    void Start()
    {
        // Obtiene el componente Rigidbody2D del objeto que contiene este script
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Establece la velocidad de la bala en el eje Y, haciendo que se mueva hacia arriba o hacia abajo dependiendo de la velocidad
        rb.velocity = new Vector2(0, speed);
    }

    // Este método es llamado cuando la bala sale de la pantalla (es invisible)
    private void OnBecameInvisible()
    {
        // Destruye el objeto (la bala) cuando ya no es visible en la pantalla
        Destroy(this.gameObject);
    }
}

