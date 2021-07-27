using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Action take = delegate { };

    void Start()
    {
        StartCoroutine(Death_());
    }

    IEnumerator Death_()
    {
        
        yield return new WaitForSeconds(20);
        Destroy(gameObject);

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        take();
        Destroy(gameObject);
    }
}
