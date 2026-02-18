// using - "importar"
// namespaces - "paquete"
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    // CÓDIGO!

    // ciclo de vida 
    // lifecycle 
    // en algunos motores / frameworks / tecnología
    // nosotros inyectamos lógica por medio de métodos que 
    // forman parte de algo que llamamos ciclo de vida

    // CICLO DE VIDA
    // serie de métodos que se invocan en momentos específicos durante la ejecución
    // de un elemento (monobehaviour)

    // primer método del ciclo de vida
    // se invoca una vez al inicio de la vida del componente
    void Awake()
    {
        print("AWAKE");
    }

    // segundo método en correr es start
    // start depende de el status del componente (habilitado / deshabilitado)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("START");
    }

    // cómo funciona una app gráfica
    // utiliza un loop
    // lógica + gráficos (esto es un frame!)

    // fps - frames per second
    // aspiramos a 60+
    // nos podemos conformar con 30

    // Update is called once per frame
    void Update()
    {
        // invocado una vez por cuadro

        print("UPDATE");

        //tratar de limitar código a 2 cuestiones en update:
        // 1. movimiento
        // 2. captar entrada
    }
}
