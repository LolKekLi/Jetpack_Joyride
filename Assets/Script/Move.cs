using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] private float move;
    private bool death = false;
    [SerializeField] private Text speed = null;
    private float bestSpeed;
    [SerializeField] private GameObject pauseMenu = null;

    public static Action<bool> pause = delegate { };
    private bool pause_ = false;

    private bool temp_ = true;
    void OnEnable()
    {
        Stone.death += Stone_Death;
        speed.text = move.ToString() + " m/c";
        StartCoroutine(AddSpeed());
        bestSpeed = PlayerPrefs.GetFloat("Score");
    }

    IEnumerator AddSpeed()
    {

        while (!death)
        {
            yield return new WaitForSeconds(1);
            move += 0.001f;
            var speedMove = move*10;
            speed.text = speedMove.ToString() + " m/c";

        }

    }
    private void Stone_Death()
    {
        if (!pause_)
        {
            death = true;
            if (move > bestSpeed)
            {
                PlayerPrefs.SetFloat("Score", move);
            }
        }

    }

    void FixedUpdate()
    {
        if (!death && !pause_)
        {
            gameObject.transform.position += Vector3.right*move;
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (temp_)
            {
                pauseMenu.SetActive(true);
                pause_ = true;
                pause(pause_);
                temp_ = false;
            }
            else
            {
                pauseMenu.SetActive(false);
                temp_ = true;
                pause_ = false;
                pause(pause_);
            }
            
        }
    }

    void OnDisable()
    {
        Stone.death -= Stone_Death;
    }
}
