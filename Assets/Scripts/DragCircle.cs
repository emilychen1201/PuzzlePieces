using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using System.Collections;

public class DragCircle : MonoBehaviour
{
    private Vector3 _offset;

    private void OnMouseDown()
    {
        var mousePos = Input.mousePosition;
        _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
    }

    private void OnMouseDrag()
    {
        var mousePos = Input.mousePosition;
        var curPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)) + _offset;
        var curPosRounded = new Vector3(curPos.x, curPos.y, 0);
        transform.position = curPosRounded;
    }


  
}
