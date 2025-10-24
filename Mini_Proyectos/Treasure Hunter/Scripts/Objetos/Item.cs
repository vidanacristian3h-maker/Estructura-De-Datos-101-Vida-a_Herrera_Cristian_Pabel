using UnityEngine;

[System.Serializable]
public class Item
{
    public string nombre;
    public int valor;
    public Sprite icono; // opcional, servirá después para UI

    public Item(string nombre, int valor)
    {
        this.nombre = nombre;
        this.valor = valor;
    }

    public override string ToString()
    {
        return $"{nombre} (valor: {valor})";
    }
}
