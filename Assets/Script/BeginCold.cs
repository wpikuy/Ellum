using System.Net;
using UnityEngine;
using System.Collections;

public class BeginCold : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            coll.GetComponent<PlayerController>().IsCold = true;
            var mask = GameObject.Find("Main Camera").transform.Find("TopMask");
            TweenPosition.Begin(mask.gameObject, 2f, mask.localPosition + new Vector3(0, 3, 0))
                .animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
            Destroy(gameObject);
        }
    }
}
