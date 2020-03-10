using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour {

    public string FilePath;

    public Animator FlashAnimator;
    string sequenece;
    int i; //
	// Use this for initialization
	void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(takePicture());
        }
	}
    IEnumerator takePicture()
    {

        string folderpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + "\\"+ FilePath + "\\";
        Debug.Log(folderpath);
        if (!System.IO.Directory.Exists(folderpath))
        {
            System.IO.Directory.CreateDirectory(folderpath);
            yield return new WaitForEndOfFrame();
        }

        i++;
        string name = System.DateTime.Now.Date.Day + "_" + System.DateTime.Now.Date.Month + "_" + System.DateTime.Now.Date.Year +
            "_" + System.DateTime.Now.Hour + "_" + System.DateTime.Now.Minute + "_" + System.DateTime.Now.Date.Second+"_"+i;
        ScreenCapture.CaptureScreenshot(folderpath + name + ".jpg");
        Debug.Log(folderpath + name + ".jpg");
        yield return new WaitForEndOfFrame();
        Debug.Log("Success");
        FlashAnimator.SetTrigger("Flash");
    }

}
