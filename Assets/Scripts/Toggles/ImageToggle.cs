using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageToggle : Toggle
{
    public Image image;
    public Sprite satisfiedImage;
    public Sprite unsatisfiedImage;

    public override void toggle(bool value)
    {
        if (value)
        {
            image.sprite = satisfiedImage;
        }
        else
        {
            image.sprite = unsatisfiedImage;
        }
    }

}
