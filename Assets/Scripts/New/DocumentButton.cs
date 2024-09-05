using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentButton : MonoBehaviour
{
    public Document document;
    public TMP_Text tituloText;
    public TMP_Text informacaoText;
    public GameObject documentoImagem;
   

    private void Start()
    {
        documentoImagem.SetActive(false);
        
    }
    public void AbrirDocumento()
    {
        
        documentoImagem.SetActive(true);
        tituloText.text = document.titulo;
        informacaoText.text = document.informacao;
       

    }
    
    
}
