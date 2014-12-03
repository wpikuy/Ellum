using System.Security.Policy;
using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {

    // for animation
    void step(){
        audio.Play();
    }

    // for Player

    public AnimationClip[] clips;

    public enum Anim{
        idle,
        walk,
        run,
        jump
    }

    public void play(Anim type){
        _animation.CrossFade(type.ToString(), 0.2f);
    }

    public void flip(){
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        _facingRight = !_facingRight;
    }

    public bool FacingRight{
        get { return _facingRight; }
    }

    private Animation _animation;
    private bool _facingRight;

	// Use this for initialization
	void Start () {

        _animation = animation;

        //读取animation
        _animation.AddClip(clips[0], "idle");
        _animation.AddClip(clips[1], "walk");
        _animation.AddClip(clips[2], "run");
        _animation.AddClip(clips[3], "jump");
        _animation.AddClip(clips[4], "crouch");

        //播放
        _animation.wrapMode = WrapMode.Loop;
	    _animation.Play("crouch");

	    _facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
