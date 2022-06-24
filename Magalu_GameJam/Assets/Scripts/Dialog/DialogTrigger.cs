using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private SO_Dialog _soDialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!DialogManager.Instance.ISWriting)
            {
                DialogManager.Instance.Initialize(_soDialog);
            }         
        }
    }
}
