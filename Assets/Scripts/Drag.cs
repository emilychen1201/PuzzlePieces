using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using System.Collections;
using Leap;
using Leap.Unity;


public class Drag : MonoBehaviour
{
    private Vector3 _offset;
    private bool _isDown;
    private float _duration;
    private LeapProvider mProvider;
	Frame mFrame;


    private Transform _transform;

    private void OnMouseDown()
    {
        _isDown  = true;
        _duration = 0;
		var mousePos = Input.mousePosition;
    	print(mousePos);
        _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
    }

    private void OnMouseDrag()
    {
        var mousePos = Input.mousePosition;
        var curPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)) + _offset;
        var curPosRounded = new Vector3(Mathf.Round(curPos.x), Mathf.Round(curPos.y), 0);
        transform.position = curPosRounded;
    }

    private void OnMouseUp()
    {
    	// print(Input.mousePosition);
        _isDown = false;
        if (_duration <= 0.5) Rotate();
    }

	public void OnPointDown()
    {
    	var frame = mProvider.CurrentFixedFrame;
        var hand = frame.Hands[0];
        var mousePos = Camera.main.WorldToScreenPoint(new Vector3(hand.PalmPosition.x,hand.PalmPosition.y,0));
        print(mousePos);

        _isDown  = true;
        _duration = 0;
        _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
    }

    public void OnPointDrag()
    {
    	var frame = mProvider.CurrentFixedFrame;
        var hand = frame.Hands[0];
        var mousePos = Camera.main.WorldToScreenPoint(new Vector3(hand.PalmPosition.x,hand.PalmPosition.y,0));
        print(mousePos);

        var curPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0)) + _offset;
        var curPosRounded = new Vector3(Mathf.Round(curPos.x), Mathf.Round(curPos.y), 0);
        transform.position = curPosRounded;
    }

    public void OnPointUp()
    {
    	// print(Input.mousePosition);
        _isDown = false;
        if (_duration <= 0.5) Rotate();
    }
    

    public void Start()
    {
        _transform = GetComponent<Transform>();
        mProvider = FindObjectOfType<LeapProvider> () as LeapProvider;

    }

    public void Update()
    {
        if (_isDown) _duration += Time.deltaTime;
    }

    private void Rotate()
    {
    	print("rotate");
        _transform.Rotate(0, 0, 90);
        AudioManager.instance.Play("ding");
    }

    private float Round5(float f)
    {
        if((f-(int)f)<=0.5&&(f-(int)f>0))
            return (int)f+0.5f;
        if((f-(int)f)>0.5)
            return (int)f+1.0f;
        if((f-(int)f)==0)
            return f;
   return f;
    } 
}