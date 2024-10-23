using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TemporaryScript : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button button;
    [SerializeField] Transform user;
    public void SetLocation()
    {
        text.text = "X: " + user.position.x + " Z: " + user.position.z;
        text.gameObject.SetActive(true);
    }
}
