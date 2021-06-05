using UnityEngine;

public class Signaling : MonoBehaviour
{
    public bool AlarmOn;
    public bool AlarmIsPlaing = false;

    private AudioSource _alarm;

    private void Awake()
    {
        _alarm = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Thief>())
        {
            AlarmOn = false;
        }
    }

    private void Update()
    {
        if (_alarm.isPlaying)
            AlarmIsPlaing = true;
        else
            AlarmIsPlaing = false;

        if (_alarm.volume <= 0 && AlarmOn == false)
            _alarm.Stop();
        else if (_alarm.isPlaying && _alarm.volume <= 1 && AlarmOn)
            _alarm.volume += 0.3f * Time.deltaTime;
        else if (AlarmOn == false)
            _alarm.volume -= 0.3f * Time.deltaTime;
    }
}
