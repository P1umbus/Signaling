using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalingOnDoor : MonoBehaviour
{
    private AudioSource _alarm;
    private Signaling _signaling;

    private void Awake()
    {
        _alarm = GetComponentInParent<AudioSource>();
        _signaling = GetComponentInParent<Signaling>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Thief>())
        {
            _alarm.Play();
            _signaling.AlarmOn = true;
        }
    }
}
