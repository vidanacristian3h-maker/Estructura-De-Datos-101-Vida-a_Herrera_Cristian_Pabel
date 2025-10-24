using System.Collections;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public Animator animator;

    private Rigidbody2D rb;
    private JugadorStats stats;
    private Vector3 ultimaPosicion;
    private float distanciaMinimaPaso = 1f;

    [Header("Estado")]
    public bool estaMuerto = false;
    public bool invulnerable = false; // invulnerabilidad temporal tras respawn

    private SpriteRenderer spriteRenderer; // opcional para parpadear al reaparecer

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<JugadorStats>();
        ultimaPosicion = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (stats == null)
            Debug.LogError("Movimiento requiere JugadorStats en el mismo objeto");
    }

    void Update()
    {
        if (estaMuerto) return;

        // Lectura de input
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        // Movimiento físico
        rb.linearVelocity = new Vector2(movX * speed, movY * speed);

        // Animaciones
        if (animator != null)
        {
            animator.SetFloat("movementX", movX);
            animator.SetFloat("movementY", movY);
            animator.SetBool("isMoving", movX != 0 || movY != 0);
        }

        // Flip horizontal
        if (movX > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (movX < 0) transform.localScale = new Vector3(-1, 1, 1);

        // Contar pasos para energía
        float distancia = Vector3.Distance(transform.position, ultimaPosicion);
        if (distancia >= distanciaMinimaPaso && stats != null)
        {
            stats.SumarPasoSinChocar();
            ultimaPosicion = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared") && stats != null)
        {
            stats.PerderEnergiaPorChoque();
        }
    }

    // -------------------- REAPARECER --------------------
    public void RespawnJugador()
    {
        GeneradorMapa generador = FindObjectOfType<GeneradorMapa>();
        if (generador != null && generador.spawnPoint != null)
            transform.position = generador.spawnPoint.position;
        else
            transform.position = Vector3.zero;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        if (stats != null)
            stats.RestaurarEnergia();

        // Invulnerabilidad temporal para evitar muerte inmediata
        StartCoroutine(InvulnerabilidadTemporal(1.5f));

        Debug.Log("🔄 Jugador reapareció (invulnerable temporalmente)");
    }

    private IEnumerator InvulnerabilidadTemporal(float duracion)
    {
        invulnerable = true;

        // Parpadeo visual opcional
        if (spriteRenderer != null)
        {
            float endTime = Time.realtimeSinceStartup + duracion;
            while (Time.realtimeSinceStartup < endTime)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSecondsRealtime(0.1f);
                spriteRenderer.enabled = true;
                yield return new WaitForSecondsRealtime(0.1f);
            }
            spriteRenderer.enabled = true;
        }
        else
        {
            yield return new WaitForSecondsRealtime(duracion);
        }

        invulnerable = false;
    }
}
