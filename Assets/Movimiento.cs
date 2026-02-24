// using - "importar"
// namespaces - "paquete"
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    private InputSystem_Actions inputActions;

    [SerializeField]
    private float _velocidad = 5;

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
        inputActions = new InputSystem_Actions();
    }

    // más ciclo de vida!
    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();        
    }

    // segundo método en correr es start
    // start depende de el status del componente (habilitado / deshabilitado)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("START");
        
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

        //print("UPDATE");

        //tratar de limitar código a 2 cuestiones en update:
        // 1. movimiento
        // 2. captar entrada

        // VERIFICAR INPUT PARA BOTÓN
        if(inputActions.Player.Jump.triggered)
        {
            // esto va a ser true sólo en una situación específica y sólo 1 frame a la vez
            // frame anterior - desactivado, frame actual - activado
            print("JUMP!");
        }

        // tipos genéricos
        // mecanismo que permite parametrizar un tipo para un objeto o método
        Vector2 desplazamiento = inputActions.Player.Move.ReadValue<Vector2>();
        Debug.Log(desplazamiento);

        // las entradas vector2 tienen rango [-1, 1]
        // transform (t minúscula)
        // objeto que heredo de MonoBehaviour que es una referencia
        // al componente transform en este mismo GO

        // PRIMERO 
        // consistencia en movimiento entre diferentes desempeños

        // Time.deltaTime - cantidad de tiempo en segundos que ha transcurrido entre
        // el frame anterior y el actual
        transform.Translate(desplazamiento * Time.deltaTime * _velocidad);
    }

    void LateUpdate()
    {
        // sucede TODOS los frames después de todos los updates
        // print("LATE UPDATE");
    }

    void FixedUpdate()
    {
        // corre (pretende correr) en intervalos de tiempo regulares
        // print("FIXED UPDATE");
    }

    // detección de colisiones
    // 1. motor de física
    // 2. character controller

    // 1. motor de física
    // requisitos:
    // - 2 o más objetos con colliders
    // - al menos 1 objeto tiene el componente rigidbody 
    // - el objeto con rigidbody se está moviendo (TODO: EXPLICAR POR QUÉ)
}
