import java.util.*;

public class main {
    static void bucketSort(float[] arr) {
        int n = arr.length;
        if (n <= 0) return;

        // Crear cubetas
        ArrayList<Float>[] buckets = new ArrayList[n];
        for (int i = 0; i < n; i++)
            buckets[i] = new ArrayList<>();

        // Colocar cada número en su cubeta
        for (float num : arr) {
            int index = (int)(num * n);
            buckets[index].add(num);
        }

        // Ordenar cubetas
        for (int i = 0; i < n; i++)
            Collections.sort(buckets[i]);

        // Unir cubetas
        int k = 0;
        for (int i = 0; i < n; i++)
            for (float num : buckets[i])
                arr[k++] = num;
    }

    public static void main(String[] args) {
        Random rand = new Random();
        float[] arr = new float[10];
        for (int i = 0; i < arr.length; i++)
            arr[i] = rand.nextFloat();

        System.out.println("Antes:");
        for (float x : arr) System.out.print(x + " ");

        bucketSort(arr);

        System.out.println("\n\nDespués:");
        for (float x : arr) System.out.print(x + " ");
    }
}
