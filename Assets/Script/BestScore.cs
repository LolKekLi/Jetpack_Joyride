using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    void OnEnable()
    {
        transform.GetChild(0).GetComponent<Text>().text = "Best speed: " + PlayerPrefs.GetFloat("Score") + "m/c";
    }
}