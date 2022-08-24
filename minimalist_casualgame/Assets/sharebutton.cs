using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class sharebutton : MonoBehaviour
{
	// Start is called before the first frame update
	public string sharemsg;
	//public Button button;
	public scorecalculator scorecalculatorscript;

	void Start()
	{
		
		//button.onClick.AddListener(clicktoshare);
		
	}
	public void clicktoshare()
    {
		sharemsg = "GG easy - I scored" + scorecalculatorscript.score.ToString() + "points in Shatter!";
		StartCoroutine(TakeScreenshotAndShare());
    }
	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject("Shatter").SetText("Hello world!").SetUrl("https://github.com/siqilin123/minimalistgame")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

		// Share on WhatsApp only, if installed (Android only)
		if( NativeShare.TargetExists( "com.whatsapp" ) )
			new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
	}
}
