using UnityEngine;

public class FlashlightEffect : MonoBehaviour
{
  	private Vector3 v3Offset;
	private GameObject goFollow;
	[SerializeField]private float speed = 0.5f;

	void Start () {
		goFollow = Camera.main.gameObject;
		transform.position = goFollow.transform.position;
		v3Offset = transform.position - goFollow.transform.position;
	}
	
	void Update () {
		transform.position = goFollow.transform.position + v3Offset;
		transform.rotation  = Quaternion.Slerp (transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
	}
}
