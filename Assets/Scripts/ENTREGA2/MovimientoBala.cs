using UnityEngine;

public class MovimientoBala : MonoBehaviour
{

    [SerializeField]
    private float _velocidad = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * _velocidad, 0, 0, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        // para destruir utilizamos Destroy
        // podemos destruir componentes o gameobjects completos
        // Destroy(this); // con esto puedes destruir un componente

        // VENDRÁ EN EL QUIZ?!
        // cuando hagamos "Instantiate" hay que tener "Destroy"
        // Destroy(gameObject);

        PoolManager.Instance.ReturnObject(this);
    }
}
