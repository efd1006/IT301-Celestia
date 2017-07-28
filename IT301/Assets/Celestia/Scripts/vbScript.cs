using UnityEngine;
using System.Collections;
using Vuforia;
public class vbScript : MonoBehaviour, IVirtualButtonEventHandler {

	private GameObject A;
	private GameObject B;
	private GameObject C;
	private GameObject D;
	//private GameObject c;
	// Use this for initialization
	string updateUserUrl = "https://celestia.000webhostapp.com/update.php";
	private string usn;
	private GameObject scriptholder;
	TextMesh textObject;
	void Start () {
		A = GameObject.Find ("A");
		A.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		B = GameObject.Find ("B");
		B.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		C = GameObject.Find ("C");
		C.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		D = GameObject.Find ("D");
		/*D.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		scriptholder = GameObject.Find("ScriptHolder");
		Login l = scriptholder.GetComponent<Login> ();
		usn = l.getUsn (); */
		//Debug.Log (usn);
		//c = GameObject.Find ("value");
		//c.SetActive (false);
		textObject = GameObject.Find ("value").GetComponent<TextMesh> ();
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		//c.SetActive (true);
		Debug.Log ("PRessed");
		switch (vb.VirtualButtonName) {
		case "A":
			textObject.text = "A";
			Debug.Log ("A");
			break;
		case "B":
			textObject.text = "B";
			Debug.Log ("B");
			break;
		case "C":
			textObject.text = "C";
			Debug.Log ("C");
			break;
		case "D":
			textObject.text = "D";
			Debug.Log ("D");
			break;
		}
		//StartCoroutine(updateOnExit(usn));
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
		//c.SetActive (false);
		Debug.Log ("released");
	}
	IEnumerator updateOnExit(string student_number)
	{
		string status = "offline";
		WWWForm f2 = new WWWForm();
		f2.AddField ("usnPost", student_number);
		f2.AddField("statusPost",status);
		WWW www_req2 = new WWW (updateUserUrl, f2);
		yield return www_req2;
		Debug.Log (www_req2);
	}
}
