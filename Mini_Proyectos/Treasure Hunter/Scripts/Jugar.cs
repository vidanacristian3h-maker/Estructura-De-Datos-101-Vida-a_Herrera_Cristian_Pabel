using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{


    public void Click_IrAlJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
