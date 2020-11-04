using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Car : MonoBehaviour
{
    public PathCreator path1;
    public PathCreator path2;
    public PathCreator path3;

    public float randomPath;

    public PathCreator pathCurrent;

    public float maxSpeed;
    public float speed;
    float distanceTravelled;
    public bool stopCar = false;

    private void Start()
    {
        //pathCurrent = path1;
        maxSpeed = Random.Range(5,10);
        speed = maxSpeed;

        distanceTravelled = Random.Range(0, 5); // losowe pojawienie sie na trasie podczas startu
        //distanceTravelled = 0;
    }
    private void Update()
    {
        distanceTravelled += speed * Time.deltaTime;

        if (stopCar && speed > 0)
        {
            speed -= 0.4f;
        }
        if(!stopCar && speed < maxSpeed)
        {
            speed += 0.8f;
        }
        if(speed<=0f)
        {
            speed = 0f;           
        }
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        //majac sciezke utrzymuj rotacje i pozycje sciezki
        if (distanceTravelled < pathCurrent.path.length)
        {
            transform.position = pathCurrent.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCurrent.path.GetRotationAtDistance(distanceTravelled);
        }       
        //po dojechaniu do konca sciezki znajdz kolejna
        else if (distanceTravelled >= pathCurrent.path.length)
        {
            
            Debug.Log("over");
            if (path3!=null)
            {
                randomPath = Random.Range(1,3);

                if(randomPath==1)
                {
                   pathCurrent = path1;
                }
                else if(randomPath==2)
                {
                    pathCurrent = path2; 
                }
                else if(randomPath==3)
                {
                    pathCurrent = path3;
                }
            }
            else if (path2 != null)
            {
                randomPath = Random.Range(1, 2);
                if (randomPath == 1)
                {
                    pathCurrent = path1;
                }
                else if (randomPath == 2)
                {
                    pathCurrent = path2;
                }
            }
            else if (path1 != null)
            {
                pathCurrent = path1;
                Debug.Log("path1");
            }
            

            distanceTravelled = 0;
            transform.position = pathCurrent.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCurrent.path.GetRotationAtDistance(distanceTravelled);

            path1 = null;
            path2 = null;
            path3 = null;

        }

    }

    public void StopCar()
    {
        stopCar = true;
    }
    public void MoveCar()
    {
        stopCar = false;
    }
    public void TakeFirstPath() //na starcie wez pierwsza sciezke
    {
        pathCurrent = path1;
        path1 = null;
    }

}
