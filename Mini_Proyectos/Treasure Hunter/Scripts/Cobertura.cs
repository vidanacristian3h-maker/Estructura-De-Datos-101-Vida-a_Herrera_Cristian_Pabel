using UnityEngine;

public class Cobertura : MonoBehaviour
{
    public float rangoDescubrimiento = 1.5f;
    private Transform jugador;

    void Start()
    {
        GameObject objJugador = GameObject.FindGameObjectWithTag("Player");
        if (objJugador != null)
            jugador = objJugador.transform;
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia < rangoDescubrimiento)
        {
            RevelarObjetosBajoCobertura();
            gameObject.SetActive(false);
        }
    }

    private void RevelarObjetosBajoCobertura()
    {
        // Busca trampas o tesoros en esta posición exacta
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        foreach (var obj in objetos)
        {
            Trampa trampa = obj.GetComponent<Trampa>();
            if (trampa != null)
            {
                Debug.Log($"🔍 Trampa detectada en {transform.position}");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangoDescubrimiento);
    }

}
