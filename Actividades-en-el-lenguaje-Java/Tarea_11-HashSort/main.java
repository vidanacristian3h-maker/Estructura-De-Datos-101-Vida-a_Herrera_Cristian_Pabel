import java.util.*;

public class main {
    public static void main(String[] args) {
        Random rnd = new Random();
        int n = 10;
        int[] arr = new int[n];

        // Generar números aleatorios entre 0 y 50
        for (int i = 0; i < n; i++)
            arr[i] = rnd.nextInt(51);

        System.out.println("Arreglo original: " + Arrays.toString(arr));

        // Usar TreeMap (ordenado por clave)
        Map<Integer, Integer> hash = new TreeMap<>();

        // Contar ocurrencias
        for (int num : arr)
            hash.put(num, hash.getOrDefault(num, 0) + 1);

        // Reconstruir arreglo ordenado
        int index = 0;
        for (Map.Entry<Integer, Integer> e : hash.entrySet()) {
            for (int j = 0; j < e.getValue(); j++)
                arr[index++] = e.getKey();
        }

        System.out.println("Arreglo ordenado: " + Arrays.toString(arr));
    }
}
