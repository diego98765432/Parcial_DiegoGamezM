using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float velocidad = 5f;
    public GameObject bala;
    public float coolDownDisparo;
    public float fuerzaDisparo;

    public Transform limiteDercho;
    public Transform limiteIzquierdo;

    public bool juegoActivo = true;

    private bool enCooldown = false;

    void Update()
    {
        if(juegoActivo)
        {
            Movimiento();
            LimitarMovimiento();

            if (Input.GetKey(KeyCode.UpArrow) && !enCooldown)
            {
                Disparo();
            }
        }
    }

    private void Movimiento()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(movHorizontal, 0, 0) * velocidad * Time.deltaTime;
        transform.position += move;
    }

    private void Disparo()
    {
        StartCoroutine(IniciarCooldown()); 
        GameObject instanciaBala = Instantiate(bala, transform.position + Vector3.up * 2, Quaternion.identity);
        instanciaBala.GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaDisparo);

        Destroy(instanciaBala, 3f);
    }

    private IEnumerator IniciarCooldown()
    {
        enCooldown = true;
        yield return new WaitForSeconds(coolDownDisparo);
        enCooldown = false;
    }

    private void LimitarMovimiento()
    {
        Vector3 pos = transform.position;

        if (pos.x < limiteIzquierdo.position.x)
        {
            pos.x = limiteDercho.position.x;
        }
        else if (pos.x > limiteDercho.position.x)
        {
            pos.x = limiteIzquierdo.position.x;
        }

        transform.position = pos;
    }


    public void TerminarElJuego()
    {
        juegoActivo = false;
        SceneManager.LoadScene(0);
    }
}
