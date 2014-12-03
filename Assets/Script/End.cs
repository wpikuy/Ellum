using UnityEngine;
using System.Collections;

public class End : MonoBehaviour{

    private bool _ended = false;
    private PlayerController _controller;
    public GameObject lastDoor;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && !_ended)
        {
            _ended = true;
            TweenPosition.Begin(lastDoor, 1f, lastDoor.transform.localPosition + new Vector3(0, -2, 0));
        }
    }

	// Use this for initialization
	void Start (){
	    _controller = GameObject.Find("Player").GetComponent<PlayerController>();
	    StartCoroutine(check());
	}
	
	IEnumerator check () {
	    while (!_controller.died){
	        yield return null;
	    }
	    if (!_ended){
	        _controller.frozen = true;
	        _controller.transform.Find("Sprite").animation.CrossFade("crouch", 2f);
	        yield return new WaitForSeconds(2f);
	        TweenVolume.Begin(GameObject.Find("BGM"), 2f, 0f);
            yield return StartCoroutine(fadeTo(GameObject.Find("FullMask").transform, 2f, 1f));
	        Application.LoadLevel(Application.loadedLevel);
	    }
	    else{
            _controller.frozen = true;
            _controller.transform.Find("Sprite").animation.CrossFade("crouch", 2f);
            yield return new WaitForSeconds(2f);
            TweenVolume.Begin(GameObject.Find("BGM"), 2f, 0f);
	        yield return StartCoroutine(fadeTo(GameObject.Find("WhiteMask").transform, 2f, 1f));
            Destroy(GameObject.Find("Redo"));
            yield return StartCoroutine(fadeTo(GameObject.Find("noone1").transform, 2f, 1f));
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(fadeTo(GameObject.Find("noone1").transform, 2f, 0f));
            yield return StartCoroutine(fadeTo(GameObject.Find("noone2").transform, 2f, 1f));
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(fadeTo(GameObject.Find("noone2").transform, 2f, 0f));
            yield return StartCoroutine(fadeTo(GameObject.Find("FullMask").transform, 2f, 1f));
            Application.LoadLevel("Credit");
	    }
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
}
