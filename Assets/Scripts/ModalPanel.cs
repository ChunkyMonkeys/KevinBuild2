using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModalPanel : MonoBehaviour {

	public Text question;
	public Button butArena;
	public Button butHome;
	public Button butGym;
	public Button butShop;
	public Button butClose;
	public GameObject modalPanelObject;

	private static ModalPanel modalPanel;

	public static ModalPanel Instance () {
		if (!modalPanel) {
			modalPanel = FindObjectOfType (typeof(ModalPanel)) as ModalPanel;
			if (!modalPanel)
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your Scene");
		}

		return modalPanel;
	}

	// A string, arena event, gym event, shop event, home evenbt and home event
	public void Choice (string question, UnityAction arenaEvent, UnityAction homeEvent, UnityAction gymEvent, UnityAction shopEvent, UnityAction closeEvent){
		modalPanelObject.SetActive (true);

		butArena.onClick.RemoveAllListeners ();
		butArena.onClick.AddListener (arenaEvent);
		butArena.onClick.AddListener (ClosePanel);

		butHome.onClick.RemoveAllListeners ();
		butHome.onClick.AddListener (homeEvent);
		butHome.onClick.AddListener (ClosePanel);

		butGym.onClick.RemoveAllListeners ();
		butGym.onClick.AddListener (gymEvent);
		butGym.onClick.AddListener (ClosePanel);

		butShop.onClick.RemoveAllListeners ();
		butShop.onClick.AddListener (shopEvent);
		butShop.onClick.AddListener (ClosePanel);

		butClose.onClick.RemoveAllListeners ();
		butClose.onClick.AddListener (closeEvent);
		butClose.onClick.AddListener (ClosePanel);

		this.question.text = question;
		butArena.gameObject.SetActive (true);
		butHome.gameObject.SetActive (true);
		butGym.gameObject.SetActive (true);
		butShop.gameObject.SetActive (true);
		butClose.gameObject.SetActive (true);
	}

	void ClosePanel() {
		modalPanelObject.SetActive (false);
	}
}
