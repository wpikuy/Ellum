using UnityEngine;
using System.Collections;

public class ChangeBGM : MonoBehaviour{

    public AudioClip game;
    private bool _used = false;

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player" && !_used){
            _used = true;
            var bgm = GameObject.Find("BGM");
            var audi = GameObject.Find("BGM").audio;
            StartCoroutine(fadeTo(audi, 2f, 0f));
        }
    }

    IEnumerator fadeTo(AudioSource audi, float dt, float target)
    {
        yield return null;
        var curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        var former = audi.volume;
        var interval = target - former;
        float time = 0;
        while (time < dt)
        {
            time += Time.deltaTime;
            audi.volume = former + interval * curve.Evaluate(time / dt);
            yield return null;
        }
        audi.volume = target;
        audi.clip = game;
        audi.volume = 1f;
        audi.Play();
    }
}
