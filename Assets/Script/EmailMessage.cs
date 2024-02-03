using UnityEngine;

[CreateAssetMenu(fileName = "New Email Message", menuName = "Custom/Email Message")]
public class EmailMessage : ScriptableObject
{
    public string Ramuan;
    public string From;
    public string subject;
    [TextArea(3, 10)]
    public string body;
}
