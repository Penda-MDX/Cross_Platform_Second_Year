using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Windows.Kinect;

using System.Linq;

public class PT_KinectTest : MonoBehaviour {

    private KinectSensor _sensor;
    private BodyFrameReader _bodyFrameReader;
    private Body[] _bodies = null;

    public GameObject kinectAvailableText;
    public Text handXText;

    public bool IsAvailable;
    public float PaddlePosition;
    public bool IsFire;

    public static PT_KinectTest instance = null;

    public Body[] GetBodies()
    {
        return _bodies;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        _sensor = KinectSensor.GetDefault();

        if (_sensor != null)
        {
            IsAvailable = _sensor.IsAvailable;

            kinectAvailableText.SetActive(IsAvailable);

            _bodyFrameReader = _sensor.BodyFrameSource.OpenReader();

            if (!_sensor.IsOpen)
            {
                _sensor.Open();
            }

            _bodies = new Body[_sensor.BodyFrameSource.BodyCount];
        }
	}
	
	// Update is called once per frame
	void Update () {

        IsAvailable = _sensor.IsAvailable;

        if (_bodyFrameReader != null)
        {
            BodyFrame frame = _bodyFrameReader.AcquireLatestFrame();
            if (frame != null)
            {
                frame.GetAndRefreshBodyData(_bodies);

                foreach (Body _body in _bodies.Where(b => b.IsTracked))
                {
                    IsAvailable = true;
                    if (_body.HandRightConfidence == TrackingConfidence.High && _body.HandRightState == HandState.Lasso)
                    {
                        IsFire = true;
                    }
                    else
                    {
                        PaddlePosition = RescalingToRangesB(-1, 1, -8, 8, _body.Lean.X);
                        handXText.text = PaddlePosition.ToString();
                    }
                }
            }
        }


    }

    static float RescalingToRangesB(float scaleAStart, float scaleAEnd, float scaleBStart, float scaleBEnd, float valueA)
    {
        return (((valueA - scaleAStart) * (scaleBEnd - scaleBStart)) / (scaleAEnd - scaleAStart)) + scaleBStart;
    }

    private void OnApplicationQuit()
    {
        if (_bodyFrameReader != null)
        {
            _bodyFrameReader.IsPaused = true;
            _bodyFrameReader.Dispose();
            _bodyFrameReader = null;
        }

        if(_sensor != null)
        {
            if (_sensor.IsOpen)
            {
                _sensor.Close();
            }
            _sensor = null;
        }
    }
}
