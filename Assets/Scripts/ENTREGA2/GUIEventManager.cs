using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GUIEventManager : MonoBehaviour
{
    // si quieres puedes hacerlo singleton
    // NO es indispensable

    [SerializeField]
    private TMP_Text _texto;

    public void ColisionSinArgsListener()
    {
        print("COLISION SIN ARGS");
    }

    public void ColisionConNombreListener(string nombre)
    {
       print("COLISION CON: " + nombre);
    }

    public void ColisionConUbicacionListener(float x, float y, float z)
    {
        print("UBICACION: " + x + ", " + y + ", " + z);
    }

    // boton
    public void BotonPresionado()
    {
        _texto.text = "BOTÓN PRESIONADO";
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene("SampleScene");
    }

    // slider
    public void SliderCambio(float valor)
    {
        _texto.text = "valor actual del slider: " + valor;
    }
 }
