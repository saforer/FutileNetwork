using UnityEngine;
using System.Collections;

public class FutileNetwork : MonoBehaviour {
    public static FutileNetwork instance;


	// Use this for initialization
	void Start () {
        instance = this;


        FutileParams fparams = new FutileParams(true, true, false, false);
        fparams.AddResolutionLevel(240f, 1f, 1f, "");
        fparams.origin = Vector2.zero;

        Futile.instance.Init(fparams);
        Futile.atlasManager.LoadAtlas("Atlases/atlas");

        FSprite box = new FSprite("Box");
        Futile.stage.AddChild(box);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
