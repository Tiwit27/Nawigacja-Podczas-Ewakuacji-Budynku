using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NFC : MonoBehaviour
{
    public TMP_Text NFCStatus;

    public bool tagFound = false;

    private AndroidJavaObject mActivity;
    private AndroidJavaObject mIntent;
    private string sAction;
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            NFCStatus.text = "Szukam tagu";
            mActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            mIntent = mActivity.Call<AndroidJavaObject>("getIntent");
            sAction = mIntent.Call<String>("getAction");
            if (sAction == "android.nfc.action.TECH_DISCOVERED")
            {
                AndroidJavaObject[] mNdefMessage = mIntent.Call<AndroidJavaObject[]>("getParcelableArrayExtra", "android.nfc.extra.NDEF_MESSAGES");
                AndroidJavaObject[] mNdefRecord = mNdefMessage[0].Call<AndroidJavaObject[]>("getRecords");
                byte[] payLoad = mNdefRecord[0].Call<byte[]>("getPayload");
                string text = System.Text.Encoding.UTF8.GetString(payLoad);
                text = text.Substring(3);
                NFCStatus.text = text;
            }
        }
    }
}
