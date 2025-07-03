using UnityEngine;

public class Fondo : MonoBehaviour
{
    public float velocidad = 2f; 
    private float largo;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
        largo = transform.localScale.y;
    }

    void Update()
    {
        transform.position -= Vector3.up * velocidad * Time.deltaTime;

        // Cuando el fondo sale completamente de la pantalla, lo reposiciona
        if (transform.position.y <= posicionInicial.y - largo)
        {
            transform.position = posicionInicial;
        }

    }
}

