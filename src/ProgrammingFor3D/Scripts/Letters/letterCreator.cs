using UnityEngine;


[CreateAssetMenu(fileName = "letters", menuName = "ScriptableObjects/letters", order = 1)]
public class letterCreator : ScriptableObject
{
	public string letterTitle;
	[TextArea(5, 10)]
	public string letterTask;
}
