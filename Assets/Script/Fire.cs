using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            audio.Play();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            audio.Stop();
        }
    }
}
