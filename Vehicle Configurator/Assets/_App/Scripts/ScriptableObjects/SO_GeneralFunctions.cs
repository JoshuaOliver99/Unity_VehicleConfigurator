using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Multipurpose ScriptableObject holding common use functions to access from anywhere
/// </summary>
[CreateAssetMenu()]
public class SO_GeneralFunctions : ScriptableObject
{
    /// <summary>
    /// Opens the given URL. Example: "http://unity3d.com/"
    /// </summary>
    public void OpenURL(string url) => Application.OpenURL(url);
}
