using System.Security.Policy;
using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {

    // for animation
    void step(){
        // TODO: 脚步声
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
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
