using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject panelBreveDescripcion, menuInteracciones, menuInformacion;


	public void activarPanelBreveDescripcion(){
		panelBreveDescripcion.SetActive (true);
	}

	public void desactivarPanelBreveDescripcion(){
		panelBreveDescripcion.SetActive (false);
	}

	public void activarMenuInteracciones(){
		menuInteracciones.SetActive (true);
	}

	public void desactivarMenuInteracciones(){
		menuInteracciones.SetActive (false);
		//Debug.Log ("pepe");
	}

	public void activarMenuInformacion(){
		menuInformacion.SetActive (true);
	}

	public void desactivarMenuInformacion(){
		menuInformacion.SetActive (false);
	}


	public void desactivarMenues(){
		desactivarMenuInformacion ();
	}



	public void setearDatos(InformacionDelObjeto info){
		GetComponent<ReferenciasGraficas> ().matchear (info);
	}

	public void setearDescripcionNivel2(string d){
		panelBreveDescripcion.transform.Find ("Desc").GetComponent<Text> ().text = d;
	}

	public void setearNombreNivel2(string n){
		panelBreveDescripcion.transform.Find ("Nombre").GetComponent<Text> ().text = n;
	}

	public void cerrarAplicacíon() {
		Application.Quit ();

	}
}
