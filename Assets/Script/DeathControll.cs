using UnityEngine;

public class DeathControll : MonoBehaviour
{
    private bool pause;
    void Start()
    {
        Stone.death += Stone_Death;
        Move.pause += Move_Pause;

    }

    private void Move_Pause(bool obj)
    {
        pause = obj;
    }

    private void Stone_Death()
    {
        if (!pause)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i);
                child.gameObject.SetActive(true);

            }
        }
       
    }

    void OnDisable()
    {
        Stone.death -= Stone_Death;
    }
}
