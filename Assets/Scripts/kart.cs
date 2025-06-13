using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class kart : MonoBehaviour
{
    public float speed;
    public Rigidbody kartrb;
    public GameObject acelerador;
    public ObjetosManager objetosManager;
    GameObject item;



    // Start is called before the first frame update
    void Start()
    {
        kartrb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        if (Input.GetKeyDown(KeyCode.P)) {
            LanzarPower();
        }
    }
    public void Movimiento()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        Vector3 direccion = new Vector3(movX, 0, movZ);
        direccion.Normalize();
        kartrb.AddForce(direccion * speed);
            

    }
    
    public void RecItem(GameObject itemAd) {
        item = itemAd;
        
    }
    public void LanzarPower() { 
        if (item.name == "Coca")
        {
            for (int i = 1; i <= 5; i++)
            {
                Vector3 direccion = kartrb.velocity.normalized;
                kartrb.AddForce(direccion * 2, ForceMode.Impulse);
            }
        }
        if (item.name == "Pilfrut") {
            print("invulnerable");
        }
        if (item.name == "Dinamita") {
            print("explosion");
        }
        if (item.name == "MAS") {
            print("MASSSS");
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}