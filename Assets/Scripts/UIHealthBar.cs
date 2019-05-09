using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }

    public Image mask;
    float originalSize;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    //Value between 0 and 1
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
