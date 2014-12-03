using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public void use(){
        audio.Play();
        var delt = audio.clip.length;
        TweenAlpha.Begin(gameObject, delt, 0f).animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        var tween = TweenPosition.Begin(gameObject, delt, transform.position + new Vector3(0, 1, 0));
        tween.animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        tween.AddOnFinished(delegate{
            Destroy(gameObject);
        });
    }
}
