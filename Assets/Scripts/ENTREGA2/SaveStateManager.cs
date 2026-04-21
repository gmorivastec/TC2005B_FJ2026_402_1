using System;
using System.IO;
using UnityEngine;

public class SaveStateManager : MonoBehaviour
{
    // PLAYERPREFS
    // sirve para guardar preferencias
    // podemos guardar lo que sea
    // en el fondo es un archivo XML con un montón de tuplas llave-valor

    // GUARDADO EN ARCHIVOS 
    // para guardar estructuras más complejas utilizamos el sistema de archivos
    // normalmente un save state tiene algo de encriptación

    // PARA PROBAR GUARDADO EN SISTEMA DE ARCHIVOS VAMOS A DECLARAR UNA ESTRUCTURA DE INFORMACIÓN MÁS COMPLEJA
    
    // serializar - transformar un objeto de representación en memoria a datos 
    // que pueden ser texto plano o binario

    // deserializar - transformar un objeto representado en datos (texto plano o binario)
    // a una representación en memoria
    [Serializable]
    public class EstadoDelJuego
    {
        public float nivelDeVida;
        public int nivelActual;
        public string nombreDelJugador;
    }

    [SerializeField]
    private EstadoDelJuego _estado;

    // voy a especificar path para guardar mi estado
    private string _pathEstado;

    void Awake()
    {
        _pathEstado = Application.persistentDataPath + "/archivito.json";
        print(_pathEstado);
    }

    public void SavePlayerPrefs(float valor)
    {
        // existen dos playerprefs - uno en memoria y otro en sistema de archivos
        // set sólo guarda la tupla en memoria
        PlayerPrefs.SetFloat("llaveEjemplo", valor);

        // con esta instrucción explícita se actualiza el archivo de playerprefs
        // se hace aparte porque las operaciones de I/O se consideran lentas
        PlayerPrefs.Save();
    }

    public void LoadPlayerPrefs()
    {
        // cargar y mostrar 
        float valor = PlayerPrefs.GetFloat("llaveEjemplo", -1);
        print(valor);
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("llaveEjemplo");
    }

    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveState()
    {
        // serializamos a json
        string json = JsonUtility.ToJson(_estado, true);

        // guardamos a archivo
        File.WriteAllText(_pathEstado, json);

        print("ARCHIVO GUARDADO");
    }

    public void LoadState()
    {
        // SIEMPRE QUE USEMOS ARCHIVOS CHECAMOS SI EXISTEN
        if(File.Exists(_pathEstado))
        {
            
            // cargamos contenido deserializando
            
            // primero sacamos el  string del archivo
            string json = File.ReadAllText(_pathEstado);

            print("JSON: " + json);

            // deserializamos a un objeto
            _estado = JsonUtility.FromJson<EstadoDelJuego>(json);

            print("ESTADO ACTUALIZADO");

        } else
        {
            print("ARCHIVO NO EXISTE");
        }
    }
}
