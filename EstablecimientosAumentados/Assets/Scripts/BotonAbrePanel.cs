using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAbrePanel : MonoBehaviour {

	public GameObject panel,panelACerrar;

	public void abrirPanel(){
		panel.SetActive (true);
		if (panelACerrar != null)
			panelACerrar.SetActive (false);
	}
}
