using System;
using UnityEngine;

namespace Assets.Script
{
    public class PlayerCont : MonoBehaviour
    {
        [SerializeField] private float jetpackForce = 75.0f;
        private Rigidbody2D _playerRigidbody = null;
        private bool _jetpackActive = false;
        private Animator _playerAnimator = null;

        private bool death = false;
        private bool pause = false;
     

        private void OnEnable()
        {
            Stone.death += Stone_Death;
            Move.pause += Move_Pause;
            _playerRigidbody = GetComponent<Rigidbody2D>();
            _playerAnimator = GetComponent<Animator>();
        }

        private void Move_Pause(bool temp)
        {
            if (temp)
            {
                pause = true;
                temp = false;
            }
            else
            {
                pause = false;
                temp = true;
            }
            

        }

        private void Stone_Death()
        {
            if (!pause)
            {
                death = true;
                _playerAnimator.SetBool("Death", true);
                var position = transform.position;
                transform.position = position;
                GetComponent<AudioSource>().Play();
            }
        }

        private void FixedUpdate()
        {
           
            _jetpackActive = Input.GetButton("Fire1");

            if (_jetpackActive && !death && !pause)
            {
                _playerAnimator.SetBool("Fly", true);
                _playerRigidbody.AddForce(new Vector2(0, jetpackForce));
            }

        }



        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag =="down")
            {
                _playerAnimator.SetBool("Fly", false);
            }

        }
        void OnDisable()
        {
            Stone.death -= Stone_Death;
            Move.pause -= Move_Pause;
        }
    }

}

    
