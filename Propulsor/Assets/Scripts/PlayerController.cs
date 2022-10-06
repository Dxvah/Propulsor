using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 2f;

    [SerializeField]
    TextMeshProUGUI labelFuel;
    float GasolinaActual = 100f;

    [SerializeField]
    GameObject prefabParticles;
    void Start()
    {

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        GasolinaActual = GasolinaActual - 0.5f * Time.deltaTime;
        labelFuel.text = GasolinaActual.ToString("00.00") + "%";

    }

    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel")
        {
            GasolinaActual = GasolinaActual + 10f;
            collision.gameObject.SetActive(false);
            if (GasolinaActual > 100f)
            {
                GasolinaActual = 100f;
            }
            Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);
        }
    }


    //Crear objeto collider que añada gasolina y destruya el objeto recogido (set.Active (false)

}
