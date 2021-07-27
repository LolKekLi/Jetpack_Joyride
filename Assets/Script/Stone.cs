using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public static Action death = delegate { };

    void Start()
    {
        StartCoroutine(Death_());
    }

    IEnumerator Death_()
    {

        yield return new WaitForSeconds(20);
        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      death();
    }

    
}
