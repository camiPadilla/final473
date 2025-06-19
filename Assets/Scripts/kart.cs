using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class kart : MonoBehaviour
{
    public float speed;
    public Rigidbody kartrb;
    public GameObject acelerador;
    public ObjetosManager objetosManager;
    public GameObject item;
    public Transform spawnObj;
    [SerializeField] private float veloRtot;
    [SerializeField] Transform miTrans;

    // Start is called before the first frame update
    void Start()
    {
        //kartrb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = kartrb.transform.position;
        Movimiento();
        if (Input.GetKeyDown(KeyCode.P)) {
            LanzarPower();
        }
    }
    public void Movimiento()
    {
        transform.position = kartrb.transform.position;

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
            GameObject dina = Instantiate(item,spawnObj.transform.position,spawnObj.transform.rotation);
            dina.GetComponent<Rigidbody>().AddForce(transform.forward+transform.up*10f,ForceMode.Impulse);
            print("explosion");
        }
        if (item.name == "MAS") {
            print("MASSSS");
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}