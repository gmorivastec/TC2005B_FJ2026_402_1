using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    // SINGLETON - PARA EL QUIZ!!!
    // https://en.wikipedia.org/wiki/Singleton_pattern
    
    // singleton es un patron de diseño en donde se limita la creacion de instancias de una clase
    // a una sola

    // que restricciones tenemos para implementar un singleton en el contexto de un MonoBehaviour?

    // nuestra version de singleton es "correctiva" en lugar de "preventiva"

    // property - mecanismo C# para separar acceso de lectura / escritura a una variable
    // puede haber una variable declarada de manera explicita administrada por una property
    // o una version anonima

    // ejemplo con variable explicita
    private string _ejemplo;

    // esta es la property
    public string Ejemplo
    {
        get
        {
            return _ejemplo;
        }
        private set
        {
            _ejemplo = value;
        }
    }

    // property con variable anonima

    public static PoolManager Instance
    {
        get;
        private set;
    }

    // POOL
    // recurso compartido centralizado
    // funciona como arsenal / biblioteca
    // utilizado comunmente en juegos que requieran mucha creacion / destruccion
    // ventaja?
    
    // creacion / destruccion tiene mas overhead
    // que activar / desactivar

    // 1ero - contenedor 
    private Queue<GameObject> _pool;

    // tambien necesito el tamaño
    [SerializeField]
    private int _poolSize = 10;

    // objeto original
    [SerializeField]
    private GameObject _original;

    void Awake()
    {
        // hacer verificacion que asegura una sola instancia
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // las propiedades sintacticamente funcionan como variables
        Ejemplo = "HOLA";

        // inicializamos pool
        _pool = new Queue<GameObject>();

        // creamos objetos en pool
        for(int i = 0; i < _poolSize; i++)
        {
            GameObject instance = Instantiate(_original);
            
            // guardamos instancia recien creada en estructura
            _pool.Enqueue(instance);

            // desactivamos
            instance.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecirHola()
    {
        print("HOLA SOY EL MANAGER!");
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        if(_pool.Count == 0)
            return null;
        
        GameObject poolObject = _pool.Dequeue();
        poolObject.transform.position = position;
        poolObject.transform.rotation = rotation;
        poolObject.SetActive(true);
        return poolObject;
    }

    public void ReturnObject(MovimientoBala returnedObject)
    {
        _pool.Enqueue(returnedObject.gameObject);
        returnedObject.gameObject.SetActive(false);
        
    }
}
