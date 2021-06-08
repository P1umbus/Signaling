using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _durationVolumeChange;

    private AudioSource _alarm;
    private Coroutine _activeCoroutine;

    public void TurnOnAlarm()
    {
        _alarm.Play();
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(_alarmIsGrowing());
    }
    private void _turnOfAlarm()
    {
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(_alarmFadeIn());
    }

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Thief>())
        {
            _turnOfAlarm();
        }
    }

    private IEnumerator _alarmFadeIn()
    {
        bool works = true;
        while (works)
        {
            _alarm.volume -= Mathf.Lerp(0f, 1f, _durationVolumeChange * Time.deltaTime / 10);
            if (_alarm.volume == 0)
                works = false;
            yield return null;
        }

        _alarm.Stop();
    }

    private IEnumerator _alarmIsGrowing()
    {
        bool works = true;
        while (works)
        {
            _alarm.volume += Mathf.Lerp(0f, 1f, _durationVolumeChange * Time.deltaTime / 10);
            if (_alarm.volume == 1)
                works = false;
            yield return null;
        }
    }
}
