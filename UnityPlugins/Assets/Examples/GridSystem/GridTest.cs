using UnityEngine;
using XIV.Core;
using XIV.Core.Extensions;
using XIV.GridSystems;

namespace Examples.GridSystem
{
    public class GridTest : MonoBehaviour, IGridListener
    {
        GridXY grid;
        public GameObject prefab;
        public Vector2 areaSize = new Vector2(10, 10);
        public Vector2Int cellCount = new Vector2Int(10, 10);
        public float cellPadding = 0.1f;
        public int cachedIndex;
        Camera cam;
        GameObject[] cellObjects;

        void Awake()
        {
            cam = Camera.main;
            grid = new GridXY(transform.position, areaSize, cellCount);
            cellObjects = new GameObject[cellCount.x * cellCount.y];
            var cells = grid.GetCells();
            for (var i = 0; i < cells.Count; i++)
            {
                CellData cellData = cells[i];
                var cell = Instantiate(prefab, cellData.worldPos, Quaternion.identity);
                cell.transform.localScale = (cellData.cellSize.SetZ(cell.transform.localScale.z) - Vector3.one * cellPadding);
                cellObjects[cellData.index] = cell;
            }

            cachedIndex = -1;
        }

        void OnEnable()
        {
            grid.AddListener(this);
        }

        void OnDisable()
        {
            grid.RemoveListener(this);
        }

        void Update()
        {
            grid.GridCenter = transform.position;
            grid.AreaSize = areaSize;
            grid.CellCount = cellCount;
            grid.RebuildIfDirty();
            
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition.SetZ(Mathf.Abs(grid.GridCenter.z - cam.transform.position.z)));
            int index = grid.GetIndexByWorldPos(mousePos);
            
            if (cachedIndex != index)
            {
                ClearPrevious();
                SetIndex(index);
            }
        }

        void ClearPrevious()
        {
            if (cachedIndex == -1) return;

            cellObjects[cachedIndex].GetComponent<Renderer>().material.color = Color.white;
            var neihgbours = grid.GetNeighbourIndices(cachedIndex);
            for (int i = 0; i < neihgbours.Count; i++)
            {
                cellObjects[neihgbours[i]].GetComponent<Renderer>().material.color = Color.white;
            }
        }

        void SetIndex(int index)
        {
            cellObjects[index].GetComponent<Renderer>().material.color = Color.green;
            cachedIndex = index;
            var neihgbours = grid.GetNeighbourIndices(cachedIndex);
            for (int i = 0; i < neihgbours.Count; i++)
            {
                cellObjects[neihgbours[i]].GetComponent<Renderer>().material.color = Color.red;
            }
        }

        public void OnGridChanged(IGrid grid)
        {
            cachedIndex = -1;
            for (int i = 0; i < cellObjects.Length; i++)
            {
                Destroy(cellObjects[i]);
            }
            cellObjects = new GameObject[cellCount.x * cellCount.y];
            var cells = grid.GetCells();
            for (var i = 0; i < cells.Count; i++)
            {
                CellData cellData = cells[i];
                var cell = Instantiate(prefab, cellData.worldPos, Quaternion.identity);
                cell.transform.localScale = (cellData.cellSize.SetZ(cell.transform.localScale.z) - Vector3.one * cellPadding);
                cellObjects[cellData.index] = cell;
            }
        }
        
#if UNITY_EDITOR
        
        void OnDrawGizmos()
        {
            var cellDatas = GridXY.GetCells(transform.position, areaSize, cellCount);

            for (var i = 0; i < cellDatas.Count; i++)
            {
                CellData gridCellData = cellDatas[i];
                var pos = gridCellData.worldPos;
                XIVDebug.DrawRectangle(pos, gridCellData.cellSize * 0.5f);
                XIVDebug.DrawCircle(pos, gridCellData.cellSize.magnitude * 0.25f);
            }
        }
        
#endif
        
    }
}