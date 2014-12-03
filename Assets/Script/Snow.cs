using UnityEngine;
using System.Collections;

public class Snow : MonoBehaviour{

    public float speed;

    private Transform _s1;
    private Transform _s2;

    void Start(){
        _s1 = transform.Find("s1");
        _s2 = transform.Find("s2");
    }

    void Update(){

        var s1Pos = _s1.position;
        if (s1Pos.y > -4.8){
            s1Pos.y -= speed * Time.deltaTime;
        }
        else{
            s1Pos.y = 4.8f;
        }
        _s1.position = s1Pos;

        var s2Pos = _s2.position;
        if (s2Pos.y > -4.8)
        {
            s2Pos.y -= speed * Time.deltaTime;
        }
        else
        {
            s2Pos.y = 4.8f;
        }
        _s2.position = s2Pos;

    }
}
