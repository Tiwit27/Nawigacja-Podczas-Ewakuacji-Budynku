using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private RawImage map;

    public void OnOffMap()
    {
        map.enabled = !map.enabled;
    }
}
