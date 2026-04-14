using System;
using UnityEngine;
using UnityEngine.Events;

public class WallEventsBehaviour : MonoBehaviour
{

    // para eventos con argumentos tenemos que definir una clase
    [Serializable]
    public class ColisionConNombre : UnityEvent<string> {}
    
    [Serializable]
    public class ColisionConUbicacion : UnityEvent<float, float, float> {}

    // evento sin argumentos
    [SerializeField]
    private UnityEvent _colisionSinArgs;

    // evento con 1 arg
    [SerializeField]
    private ColisionConNombre _colisionConNombre;

    // evento con 3 args
    [SerializeField]
    private ColisionConUbicacion _colisionConUbicacion;

    void OnCollisionEnter(Collision collision)
    {
        print("COLLISION EN PARED");

        _colisionSinArgs.Invoke();

        _colisionConNombre.Invoke(collision.transform.name);

        ContactPoint punto = collision.GetContact(0);
        _colisionConUbicacion.Invoke(
            punto.point.x,
            punto.point.y,
            punto.point.z
        );
    }
}
