using TreeEditor;
using UnityEngine;
using System.Collections;

public class Process : MonoBehaviour{

    public AudioClip op;
    public AudioClip game;

    private Transform _camera;
    private Transform _tips;
    private AudioSource _audio;
    private PlayerSprite _playerSprite;

    IEnumerator process(){

        yield return null;

        _audio.clip = op;
        _audio.loop = true;
        _audio.Play(44100 * 1);

        yield return StartCoroutine(fadeTo(_camera.Find("FullMask"), 5f, 0));

        yield return StartCoroutine(fadeTo(_tips.Find("PressSpace"), 1f, 1f));

        while (!Input.GetButtonDown("Jump")) yield return null;

        yield return StartCoroutine(fadeTo(_tips.Find("PressSpace"), 1f, 0f));

        _playerSprite.GetComponent<Animation>().CrossFade("idle", 2f);
        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(fadeTo(_tips.Find("Logo"), 2f, 1f));

        yield return new WaitForSeconds(1.5f);

        yield return StartCoroutine(fadeTo(_tips.Find("Logo"), 2f, 0f));

        yield return StartCoroutine(fadeTo(_tips.Find("Present"), 2f, 1f));

        yield return new WaitForSeconds(1.5f);

        yield return StartCoroutine(fadeTo(_tips.Find("Present"), 2f, 0f));

        yield return StartCoroutine(fadeTo(_tips.Find("Move"), 2f, 1f));

        _playerSprite.transform.parent.GetComponent<PlayerController>().frozen = false;
    }

    IEnumerator fadeTo(Transform transform, float dt, float alpha){
        yield return null;
        var curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        var target = transform.GetComponent<SpriteRenderer>();
        var former = target.color.a;
        var interval = alpha - former;
        float time = 0;
        while (time < dt){
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
	void Start (){
	    _camera = GameObject.Find("Main Camera").transform;
	    _tips = GameObject.Find("Tips").transform;
	    _audio = GameObject.Find("BGM").GetComponent<AudioSource>();
	    _playerSprite = GameObject.Find("Player").transform.Find("Sprite").GetComponent<PlayerSprite>();
	    StartCoroutine(process());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
