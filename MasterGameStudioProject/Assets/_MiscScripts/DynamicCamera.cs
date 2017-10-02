using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
	public float m_DampTime = 0.2f;                 // Approximate time for the camera to refocus.
	public float m_ScreenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.
	public float m_MinSize = 6.5f;                  // The smallest orthographic size the camera can be.
	public Transform[] m_Targets; // All the targets the camera needs to encompass.
	private Camera m_Camera;                        // Used for referencing the camera.
	private float m_ZoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
	private Vector3 m_MoveVelocity;                 // Reference velocity for the smooth damping of the position.
	private Vector3 m_DesiredPosition;

	public List<GameObject> allPlayers;// The position the camera is moving towards.
	public GameObject thePlayer;
	public float size = 0f;

	public float zoomFactor = 0f;

	public bool cameraEnabled = false;
	public float requiredSize;
	public void AddPlayerToView(GameObject importedChar){
		allPlayers.Add (importedChar);


	}
	public void RemoveAllPlayersFromView(){
		allPlayers.Clear ();


	}
	void Start(){
		
//		allPlayers = new List<GameObject> ();
//
//		thePlayer = GameObject.FindGameObjectWithTag ("Player1");
//		if (thePlayer != null) {
//			allPlayers.Add (thePlayer);
//		}
//		thePlayer = GameObject.FindGameObjectWithTag ("Player2");
//		if (thePlayer != null) {
//			allPlayers.Add (thePlayer);
//		}
//		thePlayer = GameObject.FindGameObjectWithTag ("Player3");
//		if (thePlayer != null) {
//			allPlayers.Add (thePlayer);
//		}
//		thePlayer = GameObject.FindGameObjectWithTag ("Player4");
//		if (thePlayer != null) {
//			allPlayers.Add (thePlayer);
//		}

	}



	void Update () 
	{

		m_Targets = new Transform[allPlayers.Count];
		if (m_Targets.Length != 0) {
			for (int i = 0; i < allPlayers.Count; i++) {
				m_Targets [i] = allPlayers [i].transform;
			}
		}
	}
	private void Awake ()
	{

		m_Camera = this.transform.Find("Main Camera").GetComponent<Camera>();
	}

	private void FixedUpdate ()
	{
		if (m_Targets.Length != 0) {
			// Move the camera towards a desired position.
			Move ();

			Zoom ();
		}
		// Change the size of the camera based.

	}
	private void Move ()
	{
		// Find the average position of the targets.
		FindAveragePosition ();
		// Smoothly transition to that position.
		//transform.position = Vector3.SmoothDamp(transform.position, new Vector3(m_DesiredPosition.x,m_DesiredPosition.y,m_DesiredPosition.z), ref m_MoveVelocity, m_DampTime);
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(m_DesiredPosition.x,m_DesiredPosition.y,m_DesiredPosition.z), ref m_MoveVelocity, m_DampTime);
	}
	private void FindAveragePosition ()
	{
		Vector3 averagePos = new Vector3 ();
		int numTargets = 0;
		// Go through all the targets and add their positions together.
		for (int i = 0; i < m_Targets.Length; i++)
		{
			// If the target isn't active, go on to the next one.
			if (!m_Targets[i].gameObject.activeSelf)
				continue;
			// Add to the average and increment the number of targets in the average.
			averagePos += m_Targets[i].position;
			numTargets++;
		}
		// If there are targets divide the sum of the positions by the number of them to find the average.
		if (numTargets > 0)
			averagePos /= numTargets;
		// Keep the same y value.
		averagePos.y = averagePos.y + (20 + (zoomFactor * 2));
		//averagePos.y = transform.position.y;
		averagePos.z = averagePos.z - (10 + (zoomFactor * 1));
		// The desired position is the average position;
		m_DesiredPosition = averagePos;
	}
	private void Zoom ()
	{

		float zoomInFactor = 1f;
		float zoomOutFactor = 0f;

		float outerBufferW = Screen.width * 0.1f;
		float innerBufferW = Screen.width * 0.15f;
		float outerBufferH = Screen.height * 0.1f;
		float innerBufferH = Screen.height * 0.15f;


		//Vector3 averagePos = new Vector3 ();
		Vector3 temp;
		//int numTargets = 0;
		// Go through all the targets and add their positions together.
		for (int i = 0; i < m_Targets.Length; i++)
		{



			// If the target isn't active, go on to the next one.
			if (!m_Targets[i].gameObject.activeSelf)
				continue;


			temp = m_Camera.WorldToScreenPoint(m_Targets[i].position);
			if (i == 0) {
				//print (temp);
			}

			if ((temp.x < outerBufferW) || (temp.y < outerBufferH) || (temp.x > (Screen.width - outerBufferW))|| (temp.y > (Screen.height - outerBufferH))) {
				zoomOutFactor = -1f;
				break;
		
			}
			if (zoomInFactor != 0f) {
				if ((temp.x < innerBufferW) || (temp.y < innerBufferH) || (temp.x > (Screen.width - innerBufferW)) || (temp.y > (Screen.height - innerBufferH))) {
					zoomInFactor = 0f;


				}
			}
			// Add to the average and increment the number of targets in the average.
//			averagePos += m_Targets[i].position;
//			numTargets++;
		}
		if (zoomOutFactor == 0f) {
			if (zoomInFactor != 0) {
				//print ("zoomin in");
				zoomFactor = Mathf.Max(0,zoomFactor - 0.05f);
				//transform.position = new Vector3 (transform.position.x, transform.position.y - 0.2f, transform.position.z + 0.2f);
			}
		} else {
			//print ("zoomin out");
			zoomFactor = Mathf.Min(1000f,zoomFactor + 0.05f);
			//transform.position = new Vector3 (transform.position.x, transform.position.y + 0.2f, transform.position.z - 0.2f);
		}
		// If there are targets divide the sum of the positions by the number of them to find the average.
//		if (numTargets > 0)
//			averagePos /= numTargets;
//		// Keep the same y value.
//		averagePos.y = averagePos.y + 20;
//		//averagePos.y = transform.position.y;
//		averagePos.z = averagePos.z - 10;
//		// The desired position is the average position;
//		m_DesiredPosition = averagePos;



		// Find the required size based on the desired position and smoothly transition to that size.
		//requiredSize = FindRequiredSize();
		//this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + size, this.transform.position.z);
		//m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
		//m_Camera.transform.Translate(m_Camera.transform.forward + Mathf.SmoothDamp (m_Camera.transform.forward.z,m_Camera.transform.forward.z + requiredSize, ref m_ZoomSpeed, m_DampTime));
		//m_Camera.transform.position = new Vector3(m_Camera.transform.localPosition.x, m_Camera.transform.localPosition.y + 20,Mathf.SmoothDamp ((m_Camera.transform.localPosition.z - 10), requiredSize, ref m_ZoomSpeed, m_DampTime));
		//m_Camera.transform.position = new Vector3(m_Camera.transform.position.x, m_Camera.transform.position.y,Mathf.SmoothDamp (m_Camera.transform.position.z, requiredSize, ref m_ZoomSpeed, m_DampTime));
	}	
	private float FindRequiredSize ()
	{
		// Find the position the camera rig is moving towards in its local space.
		Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);
		// Start the camera's size calculation at zero.
		
		// Go through all the targets...
		for (int i = 0; i < m_Targets.Length; i++)
		{
			// ... and if they aren't active continue on to the next target.
			if (!m_Targets[i].gameObject.activeSelf)
				continue;
			// Otherwise, find the position of the target in the camera's local space.
			Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);
			// Find the position of the target from the desired position of the camera's local space.
			Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

			desiredPosToTarget = desiredPosToTarget;
			// Choose the largest out of the current size and the distance of the tank 'up' or 'down' from the camera.
			size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
			// Choose the largest out of the current size and the calculated size based on the tank being to the left or right of the camera.
			size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_Camera.aspect);
		}
		// Add the edge buffer to the size.
		size += m_ScreenEdgeBuffer;
		// Make sure the camera's size isn't below the minimum.
		size = Mathf.Max (size, m_MinSize);
		return size;
	}
	public void SetStartPositionAndSize ()
	{
		// Find the desired position.
		FindAveragePosition ();
		// Set the camera's position to the desired position without damping.
		transform.position = m_DesiredPosition;
		// Find and set the required size of the camera.
		m_Camera.orthographicSize = FindRequiredSize ();
	}
}
