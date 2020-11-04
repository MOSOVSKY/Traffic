using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChecker : MonoBehaviour
{
    public Car thisCar;

    private void Start()
    {
        thisCar = transform.parent.GetComponent<Car>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Car")
        {
            thisCar.StopCar();
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car")
        {
            {
                thisCar.MoveCar();
            }
        }
    }
}
