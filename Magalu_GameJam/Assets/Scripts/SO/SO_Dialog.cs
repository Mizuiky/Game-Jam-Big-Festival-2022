using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SO_Dialog : ScriptableObject
{
    public List<DialogData> _dialog;
}

[Serializable]
public class DialogData
{
    [TextArea(5, 100)]
    public string _text; 
}
