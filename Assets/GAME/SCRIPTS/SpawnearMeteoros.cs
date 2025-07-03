using System.Collections;
using UnityEngine;

public class SpawnearMeteoros : MonoBehaviour
{
    public GameObject prefabMeteoro;
    public Transform limiteIzquierdo;
    public Transform limiteDerecho;

    private Player playerScript;


    private void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        StartCoroutine(SpawnearMeteoeros());
    }
    public IEnumerator SpawnearMeteoeros()
    {
        while (playerScript.juegoActivo) 
        {
            float randomSpawn = Random.Range(limiteIzquierdo.position.x, limiteDerecho.position.x);
            float tiempoSpawn = Random.Range(0.5f, 1.5f);

            Vector3 spawn = new Vector3(randomSpawn, limiteDerecho.position.y, limiteDerecho.position.z);

            GameObject meteoerito = Instantiate(prefabMeteoro, spawn, Quaternion.identity);

            Destroy(meteoerito, 3);
            yield return new WaitForSeconds(tiempoSpawn);
        }      
    }
}
