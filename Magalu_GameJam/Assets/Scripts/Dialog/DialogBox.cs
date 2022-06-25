using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    #region Serializable Fields

    [Header("DialogBox components")]

    [SerializeField]
    private SO_String _textData;

    [SerializeField]
    private TextMeshProUGUI _textBox;

    [SerializeField]
    private TextMeshProUGUI _characterName;

    [SerializeField]
    private Button _next;

    #endregion

    private void Start()
    {
        ClearFields();
        Enable(false);
    }

    private void Update()
    {
        if(DialogManager.Instance.ISWriting)
        {
            SetText();
        }
    }

    public void ClearFields()
    {
        DisableNextButton();

        _textData.value = "";
        _textBox.text = "";

        _characterName.text = "";
    }

    private void SetText()
    {
        if (_textData.value != null)
            _textBox.text = _textData.value;
    }

    public void SetName(string name)
    {
        if (name != null)
            _characterName.text = name;
    }

    public void Enable(bool open)
    {
        this.gameObject.SetActive(open);
    }

    public void DisableNextButton()
    {
        _next.interactable = false;
    }
    public void EnableNextButton()
    {
        _next.interactable = true;
    }

    public void Next()
    {
        if(_next.interactable)
            DialogManager.Instance.NextDialog();
    }
}
