using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour{

    public Transform credit;
    public float speed;
    public Transform blackMask;
    public AudioSource bgm;

    private float _endPosition = 7.386192f;

    IEnumerator process(){
        yield return StartCoroutine(fadeTo(blackMask, 2f, 0f));
        while (credit.position.y < _endPosition){
            var pos = credit.position;
            pos.y += Time.deltaTime * speed;
            credit.position = pos;
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(volumeTo(bgm, 2f, 0f));
        yield return StartCoroutine(fadeTo(blackMask, 2f, 1f));
        Application.LoadLevel("Support");
    }

    IEnumerator volumeTo(AudioSource audi, float dt, float target)
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
    }

    IEnumerator fadeTo(Transform transform, float dt, float alpha)
    {
        yield return null;
        var curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        var target = transform.GetComponent<SpriteRenderer>();
        var former = target.color.a;
        var interval = alpha - former;
        float time = 0;
        while (time < dt)
        {
            time += Time.deltaTime;
            var color = target.color;
            color.a = former + interval * curve.Evaluate(time / dt);
            target.color = color;
            yield return null;
        }
        var _color = target.color;
        _color.a = alpha;
        target.color = _color;
    }

	// Use this for initialization
	void Start () {
	    StartCoroutine(process());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
