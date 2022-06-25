using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect2DClick : MonoBehaviour
{
    #region Private Fields

    private RaycastHit2D _hit;
    private Vector2 _clickPosition;
    private IInteractable _item;

    private HouseRooms _girlRoom;

    #endregion

    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _hit = Physics2D.Raycast(_clickPosition, Vector2.zero);

            if (_hit.collider != null)
            {
                _item = _hit.collider.GetComponent<IInteractable>();

                //checar se o itemRoom é igual ao girlRoom

                if (_item != null)
                    _item.Interact();              
            }
        }
    }
}
