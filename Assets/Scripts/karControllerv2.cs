using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class karControllerv2 : MonoBehaviour
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
    public int IdKart;
    public int cpActual;
    public int vuelta;
    public bool invulnerable = false;

    float speed, currentSpeed;
    float rotate, currentRotate;
    int driftDirection;
    float driftPower;
    bool drifting;

    //registro de vueltas y checkpoints
    

    [Header("Parameters")]
    public float acceleration = 30f;
    public float steering = 80f;
    public float gravity = 10f;
    public LayerMask layerMask;

    void Update()
    {
        // Seguir al Rigidbody
        transform.position = sphere.transform.position - new Vector3(0, 0.4f, 0);

        // Acelerar
        if (Input.GetKey(KeyCode.W) && control==true)
            speed = acceleration;

        // Girar
        if (Input.GetAxis("Horizontal") != 0)
        {
            int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs(Input.GetAxis("Horizontal"));
            Steer(dir, amount);
        }

        // Iniciar derrape
        if (Input.GetButtonDown("Jump") && !drifting && Input.GetAxis("Horizontal") != 0)
        {
            print("salto");
            drifting = true;
            driftDirection = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            driftPower = 0;
        }

        // Mientras derrapa
        if (drifting)
        {
            float input = Input.GetAxis("Horizontal");
            Steer(driftDirection, Mathf.Abs(input));
            driftPower += Time.deltaTime * 50f;
        }

        // Soltar derrape
        if (Input.GetButtonUp("Jump") && drifting)
        {
            drifting = false;
            if (driftPower > 50f)
                Boost();  // Turbo simple
            driftPower = 0;
        }

        currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime * 5f);
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 5f);
        speed = 0f; rotate = 0f;

        //Activación de items :D
        if (Input.GetButtonDown("Fire1")) {
            LanzarPower();
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
    public void RecItem(GameObject itemAd)
    {
        items = itemAd;

    }
    public void LanzarPower()
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
            ActivarInvulnerabilidad(10f); 
        }
        if (items.name == "Dinamita  1")
        {
            GameObject dina = Instantiate(items, spawner.transform.position, spawner.transform.rotation);
            dina.GetComponent<Rigidbody>().AddForce(transform.forward + transform.up * 10f, ForceMode.Impulse);
            print("explosion");
        }
        if (items.name == "Banderaa")
        {
            print("MASSSS");
            Instantiate(items, transform.position - transform.forward*5f, Quaternion.identity);
        }
    }
    public void ActivarInvulnerabilidad(float tiempo)
    {
        StartCoroutine(Invulnerabilidad(tiempo));
    }

    IEnumerator Invulnerabilidad(float tiempo)
    {
        invulnerable = true;
        Debug.Log("invulnerable");
        yield return new WaitForSeconds(tiempo);
        invulnerable = false;
        Debug.Log("no invulnerable");
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

        yield return new WaitForSeconds(15f);

        control = true;
    }
    public float ProgresoTotal()
    {
        return vuelta * 100 + cpActual;
    }

}
