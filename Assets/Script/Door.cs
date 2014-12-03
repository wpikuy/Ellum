using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour{
    //
    public bool Opened = false;

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.tag == "Player" && coll.GetComponent<PlayerController>().HasKey && !Opened){
            coll.GetComponent<PlayerController>().HasKey = false;
            TweenPosition.Begin(gameObject, 1f, transform.position + new Vector3(0, 2, 0));
            audio.Play();
        }
    }
}
