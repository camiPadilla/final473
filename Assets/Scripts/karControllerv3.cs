using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class karControllerv3 : MonoBehaviour
{
    public Transform kartModel;   // Modelo visual
    public Transform kartNormal;  // Orientación visual al terreno
    public Rigidbody sphere;      // Rigidbody invisible para físicas
    public GameObject acelereador;
    public ObjetosManager objetosManager;
    public GameObject items;
    public GameObject none;
    public Transform spawner;
    public bool control;
    public int IDkart;

    float speed, currentSpeed;
    float rotate, currentRotate;
    int driftDirection;
    float driftPower;
    bool drifting;

    [Header("Parameters")]
    public float acceleration = 30f;
    public float steering = 80f;
    public float gravity = 10f;
    public LayerMask layerMask;

    void Update()
    {
        // Seguir al Rigidbody
        transform.position = sphere.transform.position - new Vector3(0, 0.4f, 0);

        // Acelerar L1
        if ( Input.GetButton("Fire2_P2"))
        {
            //Debug.Log("L1");
            speed = acceleration;
        }
        else {
            speed = 0;        
        }


        // Girar con el stick izquierdo
        if (Input.GetAxis("Horizontal_P2") != 0)
        {
            int dir = Input.GetAxis("Horizontal_P2") > 0 ? 1 : -1;
            float amount = Mathf.Abs(Input.GetAxis("Horizontal_P2"));
            Steer(dir, amount);
        }

        // Iniciar derrape con botón de salto + stick horizontal
        if (Input.GetButtonDown("Jump_P2") && !drifting && Input.GetAxis("Horizontal_P2") != 0)
        {
            print("salto");
            drifting = true;
            driftDirection = Input.GetAxis("Horizontal_P2") > 0 ? 1 : -1;
            driftPower = 0;
        }

        // Mientras derrapa
        if (drifting)
        {
            float input = Input.GetAxis("Horizontal_P2");
            Steer(driftDirection, Mathf.Abs(input));
            driftPower += Time.deltaTime * 50f;
        }

        // Soltar derrape
        if (Input.GetButtonUp("Jump_P2") && drifting)
        {
            drifting = false;
            if (driftPower > 50f)
                Boost();  // Turbo simple
            driftPower = 0;
        }

        // Suavizado de velocidad y rotación
        currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime * 5f);
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 5f);
        speed = 0f;
        rotate = 0f;

        // Activación de items
        if (Input.GetButtonDown("Fire1_P2"))
        {
            Debug.Log("CUADRADO presionado");
            LanzarPower2();
            items = none;
        }
    }


    private void FixedUpdate()
    {
        // Movimiento
        if (!drifting)
            sphere.AddForce(-kartModel.right * currentSpeed, ForceMode.Acceleration);
        else
            sphere.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);

        // Gravedad
        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        // Rotación
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.Euler(0, transform.eulerAngles.y + currentRotate, 0),
            Time.deltaTime * 5f);

        // Alinear visualmente al terreno
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out RaycastHit hit, 2f, layerMask))
        {
            kartNormal.up = Vector3.Lerp(kartNormal.up, hit.normal, Time.deltaTime * 8f);
            kartNormal.Rotate(0, transform.eulerAngles.y, 0);
        }
    }

    public void Steer(int direction, float amount)
    {
        rotate = steering * direction * amount;
    }

    public void Boost()
    {
        StartCoroutine(BoostCoroutine());
    }

    IEnumerator BoostCoroutine()
    {
        float boostAmount = currentSpeed + 20f;
        float t = 0f;
        while (t < 0.5f)
        {
            currentSpeed = Mathf.Lerp(boostAmount, acceleration, t * 2f);
            t += Time.deltaTime;
            yield return null;
        }
    }
    public void RecItem2(GameObject itemAd)
    {
        items = itemAd;

    }
    public void LanzarPower2()
    {
        if (items.name == "Coca")
        {
            for (int i = 1; i <= 5; i++)
            {
                Vector3 direccion = sphere.velocity.normalized;
                sphere.AddForce(direccion * 2, ForceMode.Impulse);
            }
        }
        if (items.name == "Pilfrut")
        {
            print("invulnerable");
        }
        if (items.name == "Dinamita")
        {
            GameObject dina = Instantiate(items, spawner.transform.position, spawner.transform.rotation);
            dina.GetComponent<Rigidbody>().AddForce(transform.forward + transform.up * 10f, ForceMode.Impulse);
            print("explosion");
        }
        if (items.name == "MAS")
        {
            print("MASSSS");
            Instantiate(items, transform.position - transform.forward*5f, Quaternion.identity);
        }
    }
    public void Efecto()
    {
        StartCoroutine(Congelado());
    }

    IEnumerator Congelado()
    {
        control = false; 
        sphere.velocity = Vector3.zero;
        sphere.angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(7f);
        control = true;
    }

}
