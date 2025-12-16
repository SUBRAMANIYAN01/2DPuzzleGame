using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TrayManager : MonoBehaviour
{
     public static TrayManager Instance;
    
     

    public Transform trayParent;
    public int maxSlots = 5;

    private List<Tile> trayTiles = new List<Tile>();
    public event EventHandler OnSelected;
    public event EventHandler OnitemsMatched;

    
    private void Awake()
    {
        Instance = this;
        
    }

    public void AddTile(Tile tile)
    {
         if (trayTiles.Contains(tile))
            return;
        trayTiles.Add(tile);
        tile.transform.SetParent(trayParent);
        tile.transform.localScale = Vector3.one;
        OnSelected?.Invoke(this,EventArgs.Empty);
        GRIDMANAGER.Instance.MoveuptheGrid(tile.col);
        StartCoroutine(CheckMatchWithDelay());
    }

    //After placing the 5th item checking whether it is in tray or not
    //If it is not there GAmeover()
    IEnumerator CheckMatchWithDelay()
    {
    yield return new WaitForSeconds(0.25f);

    bool matchHappened = CheckForMatch();

    if (trayTiles.Count == maxSlots && !matchHappened)
    {
        GAMEMANAGER.Instance.Gamelose();
    }
    }

    //Creating a dictionary to store list of items of same type and when the list size is equal to 2 we take them out
    bool CheckForMatch()
    {
         Dictionary<int, List<Tile>> tilegroups = new Dictionary<int, List<Tile>>();

        foreach (Tile t in trayTiles)
        {
            if (!tilegroups.ContainsKey(t.tileId))
                tilegroups[t.tileId] = new List<Tile>();

            tilegroups[t.tileId].Add(t);
        }

        foreach (var pair in tilegroups)
        {
            if (pair.Value.Count >= 2) 
            {
                for (int i = 0; i < 2; i++)
                {
                    Tile t = pair.Value[i];
                    trayTiles.Remove(t);
                    Destroy(t.gameObject);
                    
                    
                }
                ScoreUI.Instance.AddScore();
                OnitemsMatched?.Invoke(this,EventArgs.Empty);

                GRIDMANAGER.Instance.CheckLevelComplete();
                return true; // match 
            }
        }

        return false; // no match
    }

     public void ClearTray()
    {
        foreach (Tile t in trayTiles)
        {
            if (t != null)
                Destroy(t.gameObject);
        }

        trayTiles.Clear();
    }




    
}
