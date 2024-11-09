using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables para las teclas de movimiento configurables desde Unity
    [Header("Controles")]
    public KeyCode teclaIzquierda = KeyCode.A;
    public KeyCode teclaDerecha = KeyCode.D;
    public KeyCode teclaPatear = KeyCode.Space;

    // Variables de configuración
    [Header("Configuración de Movimiento")]
    public float velocidadMovimiento = 5f;
    public float anguloPateo = 35f; // Ángulo de rotación al patear
    public float tiempoPateo = 0.5f; // Tiempo que dura la animación de pateo

    private bool estaPateando = false; // Controla si está en acción de pateo

        void Update()
    {
        if (!estaPateando)
        {
            // Movimiento a la izquierda
            if (Input.GetKey(teclaIzquierda))
            {
                transform.Translate(Vector2.left * velocidadMovimiento * Time.deltaTime);
            }
            // Movimiento a la derecha
            else if (Input.GetKey(teclaDerecha))
            {
                transform.Translate(Vector2.right * velocidadMovimiento * Time.deltaTime);
            }
        }

        // Acción de pateo
        if (Input.GetKeyDown(teclaPatear) && !estaPateando)
        {
            StartCoroutine(Patear());
        }
    }

    // Corrutina para simular el movimiento de pateo
    private IEnumerator Patear()
    {
        estaPateando = true;

        // Guardamos la rotación original para restaurarla después
        Quaternion rotacionOriginal = transform.rotation;

        // Rotamos el botín hacia adelante para simular el pateo
        Quaternion rotacionPateo = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, anguloPateo);
        transform.rotation = rotacionPateo;

        // Esperamos el tiempo de pateo
        yield return new WaitForSeconds(tiempoPateo);

        // Volvemos a la rotación original
        transform.rotation = rotacionOriginal;
        estaPateando = false;
    }
}
