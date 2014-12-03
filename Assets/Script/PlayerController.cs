using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{

    public bool frozen;
    [HideInInspector]
    public bool died = false;

    public float JumpSpeed;
    public float WalkSpeed;
    public float RunSpeed;
    public float Gravity;
    [Range(0, 1)] public float EnergyCost;
    [Range(0, 1)] public float Energy;
    [Range(0, 1)] public float WarmAbsorb;
    [Range(0, 1)] public float WarmCost;
    [Range(0, 1)] public float Warm;
    public bool IsCold = false;
    public bool HasKey = false;
    public Vector3 velocity { get { return _velocity; } }

    private CharacterController2D _controller;
    private Vector3 _velocity;
    private PlayerSprite _sprite;
    private string _playingAnim;

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Food"){
            Energy = 1;
            col.GetComponent<Item>().use();
        }
        else if (col.gameObject.tag == "Key"){
            HasKey = true;
            col.GetComponent<Item>().use();
        }
    }

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.tag == "Fire"){
            Warm += WarmAbsorb * Time.deltaTime;
            if (Warm > 1){
                Warm = 1;
            }
        }
    }

    private void processCold(){
        if (IsCold){
            Warm -= WarmCost * Time.deltaTime;
            if (Warm < 0){
                Warm = 0;
                IsCold = false;
                died = true;
            }
        }
    }

    private void detectKeys(){

        var _isRun = Input.GetButton("Run") && Energy > 0;

        if (_isRun && Mathf.Abs(_velocity.x) > 0){
            Energy -= EnergyCost * Time.deltaTime;
            if (Energy < 0){
                Energy = 0;
            }
        }

        if (_controller.collisionState.above){
            _velocity.y = 0;
        }

        if (_controller.isGrounded){

            if (_playingAnim == "jump"){
                _sprite.play(PlayerSprite.Anim.idle);
                _playingAnim = "idle";
            }

            _velocity.y = 0;

            if (Input.GetButtonDown("Jump")){
                _velocity.y += JumpSpeed;
            }
        }
        else{
            if (_playingAnim != "jump"){
                _playingAnim = "jump";
                _sprite.play(PlayerSprite.Anim.jump);
            }
        }

        float xAxis = Input.GetAxis("Horizontal");
        _velocity.x = xAxis * (_isRun ? RunSpeed : WalkSpeed);

        if (_controller.isGrounded){
            if (Mathf.Abs(xAxis) > 0.1){
                if (_isRun && _playingAnim != "run"){
                    _sprite.play(PlayerSprite.Anim.run);
                    _playingAnim = "run";
                }
                else if (!_isRun && _playingAnim != "walk"){
                    _sprite.play(PlayerSprite.Anim.walk);
                    _playingAnim = "walk";
                }
            }
            else{
                if (_playingAnim != "idle"){
                    _sprite.play(PlayerSprite.Anim.idle);
                    _playingAnim = "idle";
                }
            }
        }

        if ((xAxis < 0 && _sprite.FacingRight) ||
            (xAxis > 0 && !_sprite.FacingRight)){
            _sprite.flip();
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localEulerAngles = scale;
        }

        _velocity.y -= Gravity * Time.deltaTime;

        _controller.velocity = _velocity;
        _controller.move(_velocity * Time.deltaTime);
    }

	// Use this for initialization
	void Start (){
        _controller = GetComponent<CharacterController2D>();
        _velocity = _controller.velocity;
	    _sprite = transform.Find("Sprite").GetComponent<PlayerSprite>();
	    _playingAnim = "crouch";
	    frozen = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!frozen){
            detectKeys();
            processCold();
	    }
	}
}
