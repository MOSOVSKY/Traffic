using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFinder : MonoBehaviour
{
    public Car thisCar;
    public PathCreator pathcreateor;
    public bool justStarted = false; //do pierwszej sciezki na starcie sceny
    private void Start()
    {
        thisCar = transform.parent.GetComponent<Car>();
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag=="path")
        {
            pathcreateor = other.transform.parent.GetComponent<PathCreator>();

            if (pathcreateor && thisCar.path1==null) //jezeli jest jaki wykryty pathcreator a miejsce 1 jest puste
            {
                thisCar.path1 = pathcreateor;
                //Debug.Log("do 1 :"+pathcreateor.name);
                //pierwsza sciezka-kolizja ze sciezka- to ta po ktorej pierwszej pojedzie auto( do startu )
                if (justStarted==false)
                {
                    Debug.Log("juststarded");
                    thisCar.TakeFirstPath();
                    justStarted = true;
                }
                return;
            }
            else if (pathcreateor != thisCar.path1 && thisCar.path2 == null) //jezeli jest jaki wykryty pathcreator inny niz w path1 2
            {
                thisCar.path2 = pathcreateor;
                //Debug.Log("do 2 :" + pathcreateor.name);
                return;
            }
            else if (pathcreateor != thisCar.path2 && pathcreateor != thisCar.path1 && thisCar.path3 == null) //jezeli jest jaki wykryty pathcreator  inny niz w path2 i path1
            {
                thisCar.path3 = pathcreateor;
                //Debug.Log("do 3 :" + pathcreateor.name);
                return;
            }

            //Debug.Log(other.transform.parent.parent.name);
            //Debug.Log(pathcreateor.name);


        }
    }

 //   void OnTriggerExit(Collider other)
   // {
     //   if (other.tag == "path")
       // {
         //   thisCar.path1 = null;
           // thisCar.path2 = null;
         //   thisCar.path3 = null;
       // }
   // }
}
