using UnityEngine;

public class Meteorito : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if(other.CompareTag("Bala"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TerminarElJuego();
            Destroy(gameObject);
        }

    }
}
