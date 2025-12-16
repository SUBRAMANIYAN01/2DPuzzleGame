using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
public class GRIDMANAGER : MonoBehaviour
{
    public static GRIDMANAGER Instance {get;private set;}
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Grid Settings")]
    public int rowCount=6;
    public int ColomnCount=6;

     [Header("References")]
    public ITEMS_SO iTEMS_SO;
    public RectTransform gridParent;
    public LEVELS_SO currentLevel;
    private int tilespace=120;


     private Tile firstSelectedTile;
     
     private Tile[,]grid;// grid to store each item values

     private bool inputLocked;

        //SPAWNING ITEMS IN GRID
    public void Generatetiles()
        {
        if (currentLevel == null)
            {
                Debug.LogError("Current Level is NULL");
                return;
            }

        if (currentLevel.tileIDs.Length != currentLevel.rows * currentLevel.cols)
            {
                Debug.LogError("Tile IDs count does not match grid size");
                return;
            }
            ClearTiles();
            TrayManager.Instance.ClearTray();

        rowCount = currentLevel.rows;
        ColomnCount = currentLevel.cols;

        grid = new Tile[rowCount, ColomnCount];

        int index = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < ColomnCount; col++)
            {
                int tileId = currentLevel.tileIDs[index++];
                if (tileId < 0 || tileId >= iTEMS_SO.tiles.Length)
                        {
                            Debug.LogError($"Invalid tile ID: {tileId}");
                            return;
                        }
                Tile tile = Instantiate(iTEMS_SO.tiles[tileId], gridParent);
                tile.tileId = tileId;
                tile.row = row;
                tile.col = col;
                tile.name=$"{row},{col}";//To keep track of index position in the heirarchy [TESTING PURPOSE]

                grid[row, col] = tile;

                tile.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(col * tilespace, -row * tilespace);
            }
        }
    }

   

    //CHECKING IF SELECTION OF ITEM IS VALID
    public bool IsTileFree(Tile tile)
    {
        int row = tile.row;
        int col = tile.col;

        // If tile is in top row, it's free
        if (row == 0)
            return true;

        // If there is no tile above it, it's free
        return grid[row - 1, col] == null;
    }

    //REMOVING ITEM IDENTITY/INFO
    public void RemoveTile(Tile tile)
    {
        grid[tile.row, tile.col] = null;
    }
 
 
public void CheckLevelComplete()
{
   
    if (gridParent.childCount == 0)
    {
        LEVELMANAGER.Instance.LevelCompleted();
        
    }
}
 private void ClearTiles()
    {
        foreach(Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }
    }

//MOVING REMAINING ITEMS ABOVE THE GRID
public void MoveuptheGrid(int COL)
    {
        
    for (int row = 0; row < rowCount - 1; row++)
    {
        Tile belowTile = grid[row + 1, COL];
        grid[row, COL] = belowTile;

        if (belowTile != null)
        {
            belowTile.row = row;
            belowTile.col = COL;

            RectTransform rt = belowTile.GetComponent<RectTransform>();
            rt.anchoredPosition += new Vector2(0, tilespace); // move UP by 1 cell
        }
    }

    // Bottom-most cell becomes empty
    grid[rowCount - 1, COL] = null;
    }




}


