using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{

    [SerializeField]
    GameObject Gasolina;
    bool TocarFuel = true;
    float TiempoFuel = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(TocarFuel == false)
        {

            TiempoFuel = TiempoFuel - Time.deltaTime;

        }
        

    }
}
