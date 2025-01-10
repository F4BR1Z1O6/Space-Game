using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpForce; // Velocidad y fuerza del salto
    public Transform floorDetector; // Detector de piso para verificar si el jugador est� en el suelo
    public LayerMask layer; // Capa para verificar si el jugador est� tocando el suelo
    private float axisX; // Direcci�n horizontal de movimiento (izquierda/derecha)
    private Rigidbody2D rb; // Componente Rigidbody2D para la f�sica del jugador
    private Animator anim; // Componente Animator para controlar las animaciones
    private bool canJump; // Verifica si el jugador puede saltar (est� en el suelo)
    public int dJump = 0; // Cuenta los saltos dobles (0 = en el suelo, 1 = primer salto, 2 = segundo salto)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D
        anim = GetComponent<Animator>(); // Obtiene el componente Animator
    }

    void Update()
    {
        // Obtiene la entrada del jugador para el movimiento horizontal
        axisX = Input.GetAxisRaw("Horizontal");

        // Modifica la velocidad en el eje X manteniendo la velocidad en el eje Y (ca�da o salto)
        rb.velocity = new Vector2(axisX * speed, rb.velocity.y);

        // Cambia la direcci�n del jugador seg�n la entrada horizontal (gira el sprite)
        if (axisX > 0) transform.localScale = new Vector2(1, 1); // Mirar a la derecha
        else if (axisX < 0) transform.localScale = new Vector2(-1, 1); // Mirar a la izquierda

        // Control de animaciones si el jugador puede saltar
        if (canJump == true)
        {
            // Si el jugador se mueve horizontalmente, se pone la animaci�n de correr
            if (axisX != 0) anim.SetInteger("state", 1);
            else if (axisX == 0) anim.SetInteger("state", 0); // Si est� quieto, animaci�n de idle
        }
        else
        {
            // Si el jugador est� saltando o cayendo, cambia las animaciones
            if (rb.velocity.y > 0)
            {
                if (dJump == 1) anim.SetInteger("state", 2); // Primer salto
                else if (dJump == 2) anim.SetInteger("state", 3); // Segundo salto
            }
            else if (rb.velocity.y < 0) anim.SetInteger("state", 4); // Animaci�n de ca�da
        }

        // Verifica si el jugador est� tocando el suelo usando un Linecast
        canJump = Physics2D.Linecast(transform.position, floorDetector.position, layer);

        // Si el jugador se mueve, pon la animaci�n de correr
        if (axisX != 0) anim.SetInteger("state", 1);
        else if (axisX == 0) anim.SetInteger("state", 0); // Si est� quieto, pon la animaci�n de idle

        // Si se presiona la tecla de salto y no se ha alcanzado el l�mite de saltos dobles
        if (Input.GetKeyDown(KeyCode.Space) && dJump < 2)
        {
            StartCoroutine(AddJump()); // Inicia una corrutina para contar el salto
            rb.velocity = new Vector2(rb.velocity.x, 0); // Reinicia la velocidad vertical
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Aplica una fuerza de salto
        }

        // Si el jugador est� en el suelo, restablece los saltos disponibles
        if (canJump == true) { dJump = 0; }
    }

    // Corrutina para aumentar el contador de saltos
    IEnumerator AddJump()
    {
        yield return new WaitForSeconds(0.1f); // Espera un corto tiempo
        dJump++; // Incrementa el contador de saltos
    }
}
