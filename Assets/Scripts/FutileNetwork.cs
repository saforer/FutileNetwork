using UnityEngine;
using System.Collections;

public class FutileNetwork : MonoBehaviour {
    public static FutileNetwork instance;
    public static System.Random rand;
    private Page _currentPage;


	// Use this for initialization
	void Start () {
        instance = this;


        FutileParams fparams = new FutileParams(true, true, false, false);
        fparams.AddResolutionLevel(240f, 1f, 1f, "");
        fparams.origin = Vector2.zero;

        Futile.instance.Init(fparams);
        Futile.atlasManager.LoadAtlas("Atlases/atlas");
        rand = new System.Random(System.DateTime.Now.Millisecond);


        LoadTestPage();
    }
	
	// Update is called once per frame
	void Update () {
        _currentPage.Update();
	}

    void LoadTestPage()
    {
        if (_currentPage != null) _currentPage.RemoveFromContainer();

        _currentPage = new TestPage();
        Futile.stage.AddChild(_currentPage);
    }
}
