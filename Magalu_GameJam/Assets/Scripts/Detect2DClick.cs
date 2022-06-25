using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect2DClick : MonoBehaviour
{
    #region Private Fields

    private RaycastHit2D _hit;
    private Vector2 _clickPosition;

    private HouseRooms _currenRoom;

    #endregion

    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            var item = GetItemCollider(Input.mousePosition);

            if (item != null && item.ItemRoom.Equals(_currenRoom))
                item.Interact();
        }
    }

    private IInteractable GetItemCollider(Vector2 mousePosition)
    {
        _clickPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _hit = Physics2D.Raycast(_clickPosition, Vector2.zero);

        if (_hit.collider != null)
        {
            var item = _hit.collider.GetComponent<IInteractable>();
            return item;
        }

        return null;
    }

    private void ReceiveCurrentRoom(HouseRooms girlRoom)
    {
        //method called by the girl event 
        _currenRoom = girlRoom;
    }
}
