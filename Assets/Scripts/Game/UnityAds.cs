using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour {
	[SerializeField]
	string gameID;
	public int maxValue;
	int a;

	void Awake () {
		a = Random.Range (0, maxValue);
		print ("----------------------------------------------------------------" + a);
		Advertisement.Initialize (gameID, true);
	}


	void Update () {
		ShowAd ();
	}

	public void ShowAd (string zone = "") {

		if (string.Equals (zone, ""))
			zone = null;

		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady (zone) && (SelectionGuide.ads == 1)) {
			RandomizeAds (zone, options);
	
		}
	}

	void AdCallbackhandler (ShowResult result) {
		switch (result) {
		case ShowResult.Finished:
			SelectionGuide.ads = 3;
			break;
		case ShowResult.Skipped:
			SelectionGuide.ads = 3;
			break;
		case ShowResult.Failed:
			SelectionGuide.ads = 3;
			break;
		}
	}


	public void RandomizeAds (string zone, ShowOptions options) {   
		if (a == 1) { 
			Advertisement.Show (zone, options);   
		}
	}

}

