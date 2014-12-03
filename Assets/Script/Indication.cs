using UnityEngine;
using System.Collections;

public class Indication : MonoBehaviour{

    public PlayerController controller;

    private Transform _cold;
    private Transform _food;

	// Use this for initialization
	void Start (){
        _cold = transform.Find("ColdIndication").Find("atwar utils_1");
        _food = transform.Find("EnergyIndication").Find("atwar utils_1");
	}
	
	// Update is called once per frame
	void Update (){
	    var coldIndi = controller.Warm;
	    var foodIndi = controller.Energy;

	    var scale = _cold.localScale;
	    scale.x = coldIndi;
	    _cold.localScale = scale;

	    scale = _food.localScale;
	    scale.x = foodIndi;
        _food.localScale = scale;

	}
}
