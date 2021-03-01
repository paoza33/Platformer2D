using UnityEngine;

//pour qu'il puisse être utilisé dans d'autre script
[System.Serializable]
public class Dialogue
{
    public string name;

    //Zone de texte pour mieux mettre en forme cette variable dans notre inspecteur pour y ecrire des choses de maniere plus simple et plus agreable
    [TextArea(3,10)]
    public string[] sentences;

}
