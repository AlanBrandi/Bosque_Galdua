using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Bullet")]
public class BulletAttribute : MonoBehaviour
{
	public string quem;
	[HideInInspector]
	public int playerId;

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		if(CompareTag(quem))
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}
}
