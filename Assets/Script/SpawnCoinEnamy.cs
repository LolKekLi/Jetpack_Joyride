using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinEnamy : MonoBehaviour
{
    [SerializeField] private float backroundSize;
    [SerializeField] private float paralaxspeed;
    [SerializeField] private GameObject[] coin;
    [SerializeField] private GameObject[] stone;

    private Transform cameraTransform;
    private Transform[] layers;

    private int leftindex;
    private int rightindex;

    private float lastCameraX;

    


    void Start()
    {
        

        cameraTransform = Camera.main.transform;


        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = gameObject.transform.GetChild(i);
        }

        leftindex = 0;
        rightindex = layers.Length - 1;

    }

    


    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * paralaxspeed);
        lastCameraX = cameraTransform.position.x;
        if (cameraTransform.position.x > (layers[rightindex].transform.position.x))
        {
            ScrollRight();
        }
    }

    private void ScrollRight()
    {
        
        int lastLeft = leftindex;
        layers[leftindex].position = new Vector3((layers[rightindex].position.x + backroundSize), layers[rightindex].position.y, layers[rightindex].position.z);
        rightindex = leftindex;
        leftindex++;
        if (leftindex == layers.Length)
        {
            leftindex = 0;
        }
        var index = leftindex - 1;
        if (index <  0)
        {
            index = 2;
        }

        var coin_ =Instantiate(coin[Random.Range(0, coin.Length)]);
        coin_.gameObject.transform.position =   new Vector3(layers[index].position.x, 5f, coin_.gameObject.transform.position.z);

        var stone_ = Instantiate(stone[Random.Range(0, stone.Length)]);
        stone_.gameObject.transform.position =  new Vector3(layers[index].position.x, 5f, coin_.gameObject.transform.position.z);


    }
}

