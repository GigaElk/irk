using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Runtime.UIManager.Containers;

public class ReleaseIrritant : MonoBehaviour
{
    public UIView IrritantView;
    public Image IrritantImage;

    public bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("RELEASE THE IRRITANT!");
            UIView.Show("Irritant", "IrritantView");
            isVisible = true;
        }
    }
}
