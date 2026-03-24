using System.Collections;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    [SerializeField]
    private float _velocidad = 5;

    [SerializeField]
    private GameObject _original;

    // CORRUTINAS
    // mecanismo que utiliza Unity para trabajar con pseudoconcurrencia (QUIZ?!?!)

    // ejecución con delay
    // ejecución recurrente fuera de update

    // por qué usar corrutina vs update?
    // - performance - entre más pequeño el update más performance
    // - las corrutinas tienen poco overhead
    // - podemos definir la frecuencia con la que se corre 

    // más sobre corrutinas:
    // - dependen directamente del componente: si el componente desaparece las corrutinas también
    // - la gestión de las corrutinas dependen del componente al que pertenezca

    IEnumerator _enumeratorCorrutina;
    Coroutine _corrutina;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }
    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enumeratorCorrutina = EjemploCiclo(); 
        StartCoroutine("EjemploLineal");
        StartCoroutine(EjemploLineal());
        _corrutina = StartCoroutine(_enumeratorCorrutina);
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento copy-paste-eado del otro movimiento
        Vector2 desplazamiento = inputActions.Player.Move.ReadValue<Vector2>();
        transform.Translate(desplazamiento * Time.deltaTime * _velocidad, Space.World);
    
        // disparo
        if(inputActions.Player.Jump.triggered)
        {
            print("DISPARO!");
            // para crear clones de gameobjects 
            // utilizamos un método que se llama instantiate
            Instantiate(
                _original, 
                transform.position,
                transform.rotation
                );
        }

        // sólo para el ejemplo de corrutinas
        // polling directo a dispositivo
        if(Input.GetKeyDown(KeyCode.C))
        {
            StopAllCoroutines();
            StopCoroutine("EjemploLineal");
            StopCoroutine(_enumeratorCorrutina);
            StopCoroutine(_corrutina);
        }
    }

    // para definir una corrutina es necesario definir una función 

    // debe regresar un objeto IEnumerator
    IEnumerator EjemploLineal()
    {
        yield return new WaitForSeconds(2);
        print("EJEMPLO LINEAL DE CORRUTINA");
    }

    IEnumerator EjemploCiclo()
    {
        WaitForSeconds espera = new WaitForSeconds(1);
        while(true)
        {
            print("EJEMPLO CICLO DE CORRUTINA");
            yield return espera;
        }
    }
}
