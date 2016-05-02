using System.Collections;

public class CameraPreview : MonoBehaviour {

	public GameObject target;
	public float Distance = 5;
	public float RotationSpeed = 50;
	public bool AutoRotate = true;

	private float rotation = 0f;
	private Vector3 orientation;
	private float rot = 0f;


	// Use this for initialization
	void Start () 
	{
		//orientation = LookObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.RotateAround(LookObject.transform.position, Vector3.up*10, 50 * Time.deltaTime);
		//transform.LookAt (LookObject.transform.position);
		Orbit ();
		if (AutoRotate)
			rot = (RotationSpeed * Time.deltaTime);
		else
			rot = Input.GetAxis ("Mouse X")*(RotationSpeed/10);

		if ((Input.GetAxis ("Mouse ScrollWheel") < 0F) && (Distance < 10))
			Distance += 0.5F;
		if ((Input.GetAxis ("Mouse ScrollWheel") > 0F) && (Distance > 3))
			Distance -= 0.5F;
	}
	
	void Orbit()
	{
		if(target != null)
		{
			// Keep us at orbitDistance from target
			transform.position = target.transform.position + (transform.position - target.transform.position).normalized * Distance;
			transform.RotateAround(target.transform.position, Vector3.up, rot);
		}
	}
}
