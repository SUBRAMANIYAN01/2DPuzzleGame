using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour,IPointerClickHandler
{
    public int tileId;

    [HideInInspector]public int row;
    [HideInInspector]public int col;
   
    public bool isCollected = false;//to CHeck if it already clicked/ selected

     public void OnPointerClick(PointerEventData eventData)
    {
         if (isCollected){
        return;}
        if (!GRIDMANAGER.Instance.IsTileFree(this))
        return;
         isCollected = true;

        GRIDMANAGER.Instance.RemoveTile(this);
        TrayManager.Instance.AddTile(this);
       
    }
    private void Start()
    {
       
    }



   
}
