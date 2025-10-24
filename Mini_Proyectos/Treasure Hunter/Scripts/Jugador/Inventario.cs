using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public class Item
    {
        public string nombre;
        public int valor;

        public Item(string nombre, int valor)
        {
            this.nombre = nombre;
            this.valor = valor;
        }
    }

    public List<Item> items = new List<Item>();

    // Nuevo método con 2 parámetros
    public void AgregarItem(string nombre, int valor)
    {
        items.Add(new Item(nombre, valor));
        Debug.Log($"🪙 Agregado al inventario: {nombre} (valor {valor})");
    }

    public void MostrarInventario()
    {
        Debug.Log("📦 Inventario del jugador:");
        foreach (var item in items)
        {
            Debug.Log($"• {item.nombre} (valor: {item.valor})");
        }
    }
}
