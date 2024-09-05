using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Novo Documento", menuName = "Documento")]
public class Document : ScriptableObject
{
    public int id;
    public string titulo;
    public string informacao;
}
