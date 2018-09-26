using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonData
{
    public int red;
    public int green;
    public int blue;

    public static JsonData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<JsonData>(jsonString);
    }
}
