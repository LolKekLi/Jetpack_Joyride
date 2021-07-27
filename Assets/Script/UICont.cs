using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICont : MonoBehaviour
{
    [SerializeField] private Text score;
    private int intscore = 0;
    void OnEnable()
    {
        Coin.take += Coin_Take;
    }

    private void Coin_Take()
    {
        intscore++;
        score.text = intscore + "X";
    }

    void OnDisable()
    {
        Coin.take -= Coin_Take;
    }



}
