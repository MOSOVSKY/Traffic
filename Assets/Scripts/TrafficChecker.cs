using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficChecker : MonoBehaviour
{
    public TrafficLight collidedTrafficLight;
    public Car thisCar;

    private void Start()
    {
        thisCar = transform.parent.GetComponent<Car>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "TrafficLight")
        {
            collidedTrafficLight = other.GetComponent<TrafficLight>();

            if (collidedTrafficLight.LightRed.enabled || collidedTrafficLight.LightYellow.enabled)
            {
                //Debug.Log("STOP");
                thisCar.StopCar();
            }
            if (collidedTrafficLight.LightGreen.enabled)
            {
                //Debug.Log("START");
                thisCar.MoveCar();
            }
        }
    }

    void OnTriggerExit(Collider other) //jesli na zoltym przejedzie niech jedzie
    {
        if (other.tag == "Traffic Light")
        {
            collidedTrafficLight = other.GetComponent<TrafficLight>();
            if (collidedTrafficLight.LightYellow.enabled)
            {
                //Debug.Log("START SPOZNONY");
                thisCar.MoveCar();
                collidedTrafficLight = null;
            }
        }
    }
}
