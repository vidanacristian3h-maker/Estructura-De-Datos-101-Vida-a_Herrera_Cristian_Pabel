using System.Collections.Generic;
using UnityEngine;

public class GeneradorMapa : MonoBehaviour
{
    [Header("Mapa")]
    public int ancho = 40;
    public int alto = 40;
    public int pasos = 1000;

    [Header("Prefabs")]
    public GameObject pisoPrefab;
    public GameObject paredPrefab;
    public GameObject trampaPrefab;
    public GameObject tesoroPrefab;
    public GameObject salidaPrefab;
    public GameObject coberturaPrefab;
    public GameObject jugadorPrefab;
    public Camera mainCamera;

    [HideInInspector]
    public GameObject[,] coberturas;

    private bool[,] mapa;
    private GameObject jugadorInstanciado;
    public Transform spawnPoint; // ahora es Transform

    void Start()
    {
        GenerarMapa();
        DibujarMapa();
        ColocarJugador();
        SpawnearObjetos(transform);   // ✅ ahora pasamos un Transform
        ConfigurarCamara();
    }

    public void GenerarMapa()
    {
        mapa = new bool[ancho, alto];
        System.Random rnd = new System.Random();

        Vector2Int pos = new Vector2Int(ancho / 2, alto / 2);
        mapa[pos.x, pos.y] = true;

        List<Vector2Int> direcciones = new List<Vector2Int>
        {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };

        for (int i = 0; i < pasos; i++)
        {
            Vector2Int dir = direcciones[rnd.Next(direcciones.Count)];
            pos += dir;
            pos.x = Mathf.Clamp(pos.x, 1, ancho - 2);
            pos.y = Mathf.Clamp(pos.y, 1, alto - 2);
            mapa[pos.x, pos.y] = true;
        }
    }

    void DibujarMapa()
    {
        coberturas = new GameObject[ancho, alto];

        for (int x = 0; x < ancho; x++)
        {
            for (int y = 0; y < alto; y++)
            {
                Vector3 pos = new Vector3(x, y, 0);

                GameObject celda = mapa[x, y] ? pisoPrefab : paredPrefab;
                Instantiate(celda, pos, Quaternion.identity, transform);

                GameObject c = Instantiate(coberturaPrefab, pos, Quaternion.identity, transform);
                c.name = $"Cobertura_{x}_{y}";
                coberturas[x, y] = c;
            }
        }
    }

    void SpawnearObjetos(Transform contenedor)
    {
        // Salida
        Vector2Int salida = GetRandomSuelo();
        Instantiate(salidaPrefab, new Vector3(salida.x, salida.y, 0), Quaternion.identity, contenedor);

        // Trampas
        for (int i = 0; i < 6; i++)
        {
            Vector2Int pos = GetRandomSueloAvoidSpawn();
            GameObject t = Instantiate(trampaPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity, contenedor);

            // ✅ Asegurar que tenga script y collider trigger
            if (t.GetComponent<Trampa>() == null)
                t.AddComponent<Trampa>();

            Collider2D col = t.GetComponent<Collider2D>();
            if (col == null)
            {
                BoxCollider2D box = t.AddComponent<BoxCollider2D>();
                box.isTrigger = true;
            }
            else
            {
                col.isTrigger = true;
            }
            Debug.Log($"🪤 Trampa creada en posición {pos.x}, {pos.y}");
            // Opcional: poner capa especial
            t.layer = LayerMask.NameToLayer("Trampa");
        }

        // Tesoros
        for (int i = 0; i < 5; i++)
        {
            Vector2Int pos = GetRandomSueloAvoidSpawn();
            GameObject t = Instantiate(tesoroPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity, contenedor);

            Tesoro tesoro = t.GetComponent<Tesoro>();
            if (tesoro != null && i == 0) // el primer cofre tiene llave
                tesoro.contieneLlave = true;
        }

    }

    Vector2Int GetRandomSueloAvoidSpawn()
    {
        System.Random rnd = new System.Random();
        while (true)
        {
            int x = rnd.Next(ancho);
            int y = rnd.Next(alto);

            if (!mapa[x, y]) continue;

            if (spawnPoint != null)
            {
                Vector2Int spawnTile = new Vector2Int(Mathf.RoundToInt(spawnPoint.position.x), Mathf.RoundToInt(spawnPoint.position.y));
                float distancia = Vector2.Distance(spawnTile, new Vector2(x, y));

                if (distancia < 3f) continue; // 🔹 evita trampas muy cerca del jugador
            }

            return new Vector2Int(x, y);
        }
    }


    void ColocarJugador()
    {
        Vector2Int posJugador = GetRandomSuelo();
        jugadorInstanciado = Instantiate(jugadorPrefab, new Vector3(posJugador.x, posJugador.y, -0.5f), Quaternion.identity);

        spawnPoint = jugadorInstanciado.transform;

        UIStats ui = FindFirstObjectByType<UIStats>();
        if (ui != null)
        {
            ui.SetJugador(jugadorInstanciado.GetComponent<JugadorStats>());
        }
    }

    void ConfigurarCamara()
    {
        if (mainCamera != null && jugadorInstanciado != null)
        {
            CamaraSeguidora camScript = mainCamera.GetComponent<CamaraSeguidora>();
            if (camScript != null)
            {
                camScript.jugador = jugadorInstanciado.transform;
            }
        }
    }

    Vector2Int GetRandomSuelo()
    {
        System.Random rnd = new System.Random();
        while (true)
        {
            int x = rnd.Next(ancho);
            int y = rnd.Next(alto);
            if (mapa[x, y]) return new Vector2Int(x, y);
        }
    }
}
