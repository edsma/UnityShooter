using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Tooltip("Prefab del enemigo a generar")]
    public GameObject prefab;

    [Tooltip("Tiempo en el que inicia y finaliza la oleada")]
    public float starTime, endTime;

    [Tooltip("Tiempo entre la generación de enemigos")]
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        WaveManager.SharedInstance.AddWave(1);
        InvokeRepeating(Constantes.metodos.metodoSpawnEnemigo,starTime,spawnRate);
        Invoke(Constantes.metodos.metodoCancelarSpawnEnemigo,endTime);
    }



    void EndWave()
    {
      
        CancelInvoke();
    }

    void SpawnEnemy()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    void CancelSpawnEnemy()
    {
        CancelInvoke();
    }


}
