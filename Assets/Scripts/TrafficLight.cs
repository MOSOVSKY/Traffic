using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Light LightRed;
    public Light LightYellow;
    public Light LightGreen;
    // Start is called before the first frame update
    void Start()
    {
        LightRed.enabled = false;
        LightYellow.enabled = false;
        LightGreen.enabled = true;

    }

    // Update is called once per frame

    public void OnMouseDown()
    {
        //jezeli zielone daj zolte i czerw

        //jesli czerw daj czerwone z zoltym i zielone

        if (LightRed.enabled)
        {
            StartCoroutine(TurnOnGreen());
        }
        if (LightGreen.enabled)
        {
            StartCoroutine(TurnOnRed());
        }
    }
    public IEnumerator TurnOnGreen()
    {
        yield return new WaitForSeconds(1f);
        LightYellow.enabled = true;
        yield return new WaitForSeconds(1f);
        LightRed.enabled = false;
        LightYellow.enabled = false;
        LightGreen.enabled = true;

    }

    IEnumerator TurnOnRed()
    {
        yield return new WaitForSeconds(1f);
        LightYellow.enabled = true;
        LightGreen.enabled = false;
        yield return new WaitForSeconds(1f);
        LightRed.enabled = true;
        LightYellow.enabled = false;
        LightGreen.enabled = false;
    }
}
