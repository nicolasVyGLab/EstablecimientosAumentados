using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorObjeto3D : MonoBehaviour {

	public string nombre;
	public GameObject objeto;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		objeto.transform.Rotate (new Vector3 (0, 10 * Time.deltaTime, 0));
		if (transform.parent.parent.name.Equals (nombre)) {
			objeto.SetActive (true);
		} else {
			objeto.SetActive (false);
		}
	}
}
