using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//entering and exiting the area
public class ChangeColourOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model; //the meshrenderer
    public Color normalColour;
    public Color hoverColour;
    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColour;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColour; //entering the collider, the material changes colour
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        model.material.color = normalColour; //leaving the collider, material returns to normal
    }
}
