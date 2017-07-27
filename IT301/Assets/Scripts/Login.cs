using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour {

	public InputField usn;
	//string loginUserUrl = "http://192.168.200.111/CelestiaAPI/login.php";
	//string updateUserUrl = "http://192.168.200.111/CelestiaAPI/update.php";
	string loginUserUrl = "https://celestia.000webhostapp.com/login.php";
	string updateUserUrl = "https://celestia.000webhostapp.com/update.php";
	public Text msg;
	string status;
	string usn_online;

	public void getLogin()
	{
		if (usn.text != "") {
			//Debug.Log(usn.text);
			StartCoroutine(loginToDB(usn.text));
		} else {
			msg.text =  "Enter student number";
		}
	}
		
	IEnumerator loginToDB(string student_number)
	{
		WWWForm form = new WWWForm();
		form.AddField ("usnPost", student_number);

		WWW www = new WWW (loginUserUrl, form);

		yield return www;

		if (www.text == "success") {
			status = "online";
			usn_online = student_number;
			WWWForm f = new WWWForm();
			f.AddField ("usnPost", student_number);
			f.AddField("statusPost",status);
			WWW www_req = new WWW (updateUserUrl, f);
			yield return www_req;
			SceneManager.LoadScene ("AR", LoadSceneMode.Single);
		} else {
			msg.text = "Not Found";
		}
	}

	IEnumerator updateOnExit(string student_number)
	{
		status = "offline";
		WWWForm f2 = new WWWForm();
		f2.AddField ("usnPost", student_number);
		f2.AddField("statusPost",status);
		WWW www_req2 = new WWW (updateUserUrl, f2);
		yield return www_req2;
		Debug.Log (www_req2);
	}

	void OnApplicationQuit()
	{
		StartCoroutine(updateOnExit(usn_online));
		//Debug.Log("Application ending after " + Time.time + " seconds");
	}
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Update()
	{
		if(Application.platform==RuntimePlatform.Android && Input.GetKeyDown ("escape"))
		{
			StartCoroutine(updateOnExit(usn_online));
			Application.Quit();
		}
	}
	public string getUsn()
	{
		return usn_online;
	}
}
