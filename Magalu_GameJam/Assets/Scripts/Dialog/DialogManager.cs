using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;
using UnityEngine.UI;

public class DialogManager : Singleton<DialogManager>
{
    #region Serializable Fields

    [Header("Dialog Setup")]

    [SerializeField]
    private DialogBox _dialogBox;

    [SerializeField]
    private SO_String _text;

    [SerializeField]
    private float _speed;

    #endregion

    #region Private Fields

    private bool _isWriting;

    private int _currentDialogIndex;

    private string _dialogName;

    private DialogData[] _dialogs;

    #endregion

    #region Properties

    public bool ISWriting
    {
        get => _isWriting;
    }

    #endregion

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        _isWriting = false;
        _currentDialogIndex = 0;
    }

    public void Initialize(SO_Dialog data, string itemName = "")
    {
        _dialogBox.Enable(true);

        ClearPreviousData();
        Init();

        _dialogs = data._dialog.ToArray();
        _dialogName = itemName;

        Write();
    }

    private void ClearPreviousData()
    {
        if(_dialogs != null && _dialogs.Length > 0)
        {
            _dialogs = null;
            GC.Collect();
        }

        _dialogName = "";

        _dialogBox.ClearFields();
    }

    public void Write()
    {
        _isWriting = true;

        StartCoroutine(WriteText());
    }

    private IEnumerator WriteText()
    {     
        var aux = _dialogs[_currentDialogIndex];

        if(_dialogName != null)
            _dialogBox.SetName(_dialogName);

        var dialog = aux._text.ToCharArray();

        foreach (char letter in dialog)
        {
            _text.value += letter;

            yield return new WaitForSeconds(_speed);
        }
       
        _isWriting = false;

        _dialogBox.EnableNextButton();
    }

    public void NextDialog()
    {
        if (!_isWriting)
        {
            _dialogBox.DisableNextButton();

            _currentDialogIndex++;

            if (_currentDialogIndex == _dialogs.Length)
            {
                _dialogBox.Enable(false);
                return;
            }
                
            _text.value = "";

            Write();
        }       
    }  
}
