using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct BGImages
{
    public Sprite sprite;
    public string description;
    
}
public class BG_Controller : MonoBehaviour {
    [Header("Replace Images here")]
    public BGImages[] Backgrounds;

    [Header("Crop Settings Slider")]
    public Slider SliderLeft;
    public Slider SliderRight;
    public Slider SliderTop;

    public static BG_Controller instance;

    private void Awake()
    {
        instance = this;
    }

   

    //public Sprite [] Images;

    
    

    //public string[] Descriptions;

    public Image BG_HolderImage;
    public Image CropOverlayLeft;
    public Image CropOverLayRight;
    public Image CropOverLayTop;
    public Text DescriptionTextHolder;

    public int CurrentImage;
    private void Start()
    {
        CurrentImage = 0;
        SetNextImage();
    }

    public void SetNextImage()
    {
        CurrentImage = (CurrentImage + 1) % Backgrounds.Length;
        SetImage(CurrentImage);
    }
    void SetImage(int index) {
        BG_HolderImage.sprite = Backgrounds[index].sprite;
        CropOverlayLeft.sprite = Backgrounds[index].sprite;
        CropOverLayRight.sprite = Backgrounds[index].sprite;
        CropOverLayTop.sprite = Backgrounds[index].sprite;
        DescriptionTextHolder.text = Backgrounds[index].description;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow))
            SetNextImage();
    }



    public void OnSliderRight_ValueChanged()
    {
        CropOverLayRight.fillAmount = SliderRight.value;
    }
    public void OnSliderLeft_ValueChanged()
    {
        CropOverlayLeft.fillAmount = SliderLeft.value;
    }
    public void OnSliderTop_ValueChanged()
    {
        CropOverLayTop.fillAmount = SliderTop.value;
    }



}
