using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenciasGraficas : MonoBehaviour {

	public Text titulo,descipcion;
	public Text informacionPosta;
	public GameObject imagenes;

	public void matchear(InformacionDelObjeto info){
		titulo.text = info.transform.name;
		informacionPosta.text = info.descipcion;
		string op = "";
		for (int i = 0; i < info.juegoOpciones.Length; i++) {
			op +="("+(i+1)+") "+ info.juegoOpciones [i] + "\n";
		}
		GetComponent<ControladorFotos> ().fotos = info.fotos;
		GetComponent<ControladorFotos> ().iniciar ();
		//lo mismo para videos y links
		GetComponent<ControladorLinks>().linksNombre=info.linksNombres;
		GetComponent<ControladorLinks>().linksURLs=info.linksURLs;
		GetComponent<ControladorLinks> ().iniciar ();
	}
		
}
