using UnityEngine;
using System.Collections;

public class SpaceStation : MonoBehaviour
{
    void Start()
    {
        IndicatorManager.instance.AddIndicator(gameObject, Color.green);
    }
}
