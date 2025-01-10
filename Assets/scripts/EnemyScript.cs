using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    // Este método se llama cuando el objeto entra en contacto con un trigger (colisionador sin física)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el objeto colisiona con un collider llamado "Left", cambia la dirección del enemigo
        if (collision.name == "Left")
        {
            // Llama al método ChangeDirection en el componente EnemyMovement del padre del enemigo, pasando 1 como argumento para cambiar la dirección
            transform.parent.GetComponent<EnemyMovement>().ChangeDirection(1);
        }

        // Si el objeto colisiona con un collider llamado "Right", cambia la dirección del enemigo
        if (collision.name == "Right")
        {
            // Llama al método ChangeDirection en el componente EnemyMovement del padre del enemigo, pasando -1 como argumento para cambiar la dirección
            transform.parent.GetComponent<EnemyMovement>().ChangeDirection(-1);
        }

        // Si el objeto colisiona con una bala (objeto con la etiqueta "Bala")
        if (collision.tag == "Bala")
        {
            // Destruye el objeto bala
            Destroy(collision.gameObject);

            // Destruye el enemigo
            Destroy(this.gameObject);
        }

        // Si el objeto colisiona con el jugador (objeto con la etiqueta "Player")
        if (collision.tag == "Player")
        {
            // Recarga la escena actual, lo que generalmente se hace cuando el jugador muere o se reinicia la escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

