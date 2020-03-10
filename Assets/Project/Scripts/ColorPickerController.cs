using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nexweron.WebCamPlayer;
public class ColorPickerController : MonoBehaviour {

    public Texture2D CursorImage;

    public bool startPicker;
    public Camera mainCamera;
    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
        startPicker = false;
	}
    public Color pickedColor;
	// Update is called once per frame
	void Update () {
        if (startPicker)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Vector2 mousePos = Input.mousePosition;
                Ray ray = mainCamera.ScreenPointToRay(mousePos);
                startPicker = false;
                StartCoroutine(ReadPixel(mousePos));

            }
        }
       
	}
    IEnumerator ReadPixel(Vector2 mousePos)
    {
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame();
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tex.Apply();
        pickedColor = tex.GetPixel((int)mousePos.x,(int)mousePos.y);
        UI_Controller.instance.SetPickedColor(pickedColor);
        // turn off setting panel
        UI_Controller.instance.SetAppear_SettingsPanel(true);
        SettingsController.instance.SetKeyColor(pickedColor);
    }

    public void OnPickerButtonPressed()// Called from Picker Button
    {
        Cursor.SetCursor(CursorImage, Vector2.zero, CursorMode.Auto);
        UI_Controller.instance.SetAppear_SettingsPanel(false);
        Invoke("SetStartPickerTrue_Invoke", .5f);
    }
    void SetStartPickerTrue_Invoke()
    {
        startPicker = true;
    }
}
