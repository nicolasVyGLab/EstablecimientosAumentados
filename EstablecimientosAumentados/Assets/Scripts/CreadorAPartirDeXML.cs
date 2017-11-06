using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class CreadorAPartirDeXML : MonoBehaviour {

	public GameObject objetoPrefab;
	public GameObject persona,menu,manager;
	public Sprite imagenUns,imagenAulas,imagenOtros;
	public string xml;

	// Use this for initialization
	void Start () {
		cargarDatos ();
	}


	void cargarDatos(){



		XmlDocument doc = new XmlDocument ();
		doc.LoadXml (xml);
		//mostrar (doc.SelectSingleNode("/Datos"));
		XmlNode inicial = doc.SelectSingleNode("/Datos");

		ArrayList objetos = new ArrayList ();
		//GameObject[] objetos = new GameObject[ inicial.ChildNodes.Count];
		int o = 0;

	//	Debug.Log (inicial.ChildNodes.Count);

		//por cada punto de interes
		foreach (XmlNode puntoDeInteres in inicial.ChildNodes) {
			
			if (puntoDeInteres.Name != "#text") {
				GameObject nuevoPunto = Instantiate (objetoPrefab) as GameObject;
				objetos.Add( nuevoPunto);
				o++;
				nuevoPunto.GetComponent<SeguirCamara> ().target = persona;
				nuevoPunto.GetComponent<ControladorObjetoEnElMundo> ().menu = menu;
				nuevoPunto.GetComponent<ControladorObjetoEnElMundo> ().panelInfo = menu.transform.Find ("PanelBreveDescripcion").gameObject;
				//asigno el nombre
				if (puntoDeInteres.SelectSingleNode ("Nombre") != null) {
					nuevoPunto.transform.name = puntoDeInteres.SelectSingleNode ("Nombre").InnerText;
					nuevoPunto.GetComponent<InformacionDelObjeto> ().nombre = nuevoPunto.transform.name;
				}
				//asigno la descripcion
				if (puntoDeInteres.SelectSingleNode ("Descripcion") != null)
					nuevoPunto.GetComponent<InformacionDelObjeto> ().descipcion = puntoDeInteres.SelectSingleNode ("Descripcion").InnerText;
				

				//asigno fotos
				if (puntoDeInteres.SelectSingleNode ("Fotos") != null) {
					int cantidadFotos = puntoDeInteres.SelectSingleNode ("Fotos").ChildNodes.Count;
					string[] opcionesFotos = new string[cantidadFotos];
					int posF = 0;
					foreach (XmlNode op in puntoDeInteres.SelectSingleNode("Fotos").ChildNodes) {
						opcionesFotos [posF] = op.InnerText;
						posF++;
					}
					nuevoPunto.GetComponent<InformacionDelObjeto> ().fotos = opcionesFotos;
				}

				//asigno coordanadas GPS
				if (puntoDeInteres.SelectSingleNode ("CoordenadaGPS") != null) {
					nuevoPunto.GetComponent<PosicionGPS> ().lat = double.Parse (puntoDeInteres.SelectSingleNode ("CoordenadaGPS").SelectSingleNode ("Latitud").InnerText);
					nuevoPunto.GetComponent<PosicionGPS> ().lon = double.Parse (puntoDeInteres.SelectSingleNode ("CoordenadaGPS").SelectSingleNode ("Longitud").InnerText);
				}

				//asigno iconos de categoria
				if (puntoDeInteres.SelectSingleNode ("Categoria") != null) {
					string categoria = puntoDeInteres.SelectSingleNode ("Categoria").InnerText;
					if (categoria.Equals ("UNS")) {
						nuevoPunto.transform.Find ("Nivel2").Find ("Button").GetComponent<Image> ().sprite = imagenUns;
					} else if (categoria.Equals ("Aulas")) {
						nuevoPunto.transform.Find ("Nivel2").Find ("Button").GetComponent<Image> ().sprite = imagenAulas;
					}
					else { //otros
						nuevoPunto.transform.Find ("Nivel2").Find ("Button").GetComponent<Image> ().sprite = imagenOtros;
					}
				}




			}

			//agrego los objetos al manager

			manager.GetComponent<Manager> ().setearObjetosYComenzar (((GameObject[])(  objetos.ToArray(typeof(GameObject)))));
		}
	}

	void mostrar(XmlNode n){
		foreach (XmlNode n2 in n.ChildNodes) {
			Debug.Log (n2.Name);
			mostrar (n2);
		}
	}
}
