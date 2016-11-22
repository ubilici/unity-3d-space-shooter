using UnityEngine;
using System.Collections;

public class TargetReticle : MonoBehaviour
{
    public Sprite targetImage;

    void Start()
    {
        IndicatorManager.instance.AddIndicator(gameObject, Color.yellow, targetImage);
    }
}
