using UnityEngine;
using System.Collections;

public class ChangeBG : MonoBehaviour{

    public string name;

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            var camera = GameObject.Find("Main Camera").transform;
            TweenAlpha.Begin(camera.Find("atwar bg " + name).gameObject, 2f, 0f)
                .animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
            Destroy(gameObject);
        }
    }
}
