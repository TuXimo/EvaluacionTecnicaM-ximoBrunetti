using TMPro;
using UnityEngine;

namespace Exercises.Hex_Grids.Scripts
{
    public class HexGrid : MonoBehaviour
    {
        [Range(0,100)] public int width = 6;
        [Range(0,100)] public int height = 6;
        
        public Color defaultColor = Color.white;
        public Color touchedColor = Color.magenta;

        public HexCell cellPrefab;
        
        [SerializeField] private TMP_Text cellLabelPrefab;
        private Canvas gridCanvas;

        HexCell[] cells;
        HexMesh hexMesh;

        void Awake () {
            hexMesh = GetComponentInChildren<HexMesh>();
            gridCanvas = GetComponentInChildren<Canvas>();

            cells = new HexCell[height * width];

            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++) {
                    CreateCell(x, z, i++);
                }
            }
        }
        
        void Start () 
        {
            hexMesh.Triangulate(cells);
        }
        
        void Update () 
        {
            if (Input.GetMouseButton(0)) {
                HandleInput();
            }
        }

        void HandleInput ()
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit)) {
                TouchCell(hit.point);
            }
        }
	
        void TouchCell (Vector3 position) 
        {
            position = transform.InverseTransformPoint(position);
            HexCoordinates coordinates = HexCoordinates.FromPosition(position);
            Debug.Log("touched at " + coordinates);
            
            int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
            HexCell cell = cells[index];
            cell.color = touchedColor;
            hexMesh.Triangulate(cells);
        }
	
        private void CreateCell (int x, int z, int i) {
            Vector3 position;
            // ReSharper disable once PossibleLossOfFraction
            position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
            position.y = 0f;
            position.z = z * (HexMetrics.outerRadius * 1.5f);

            HexCell cell = cells[i] = Instantiate(cellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
            cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
            cell.color = defaultColor;
            //cell.GetComponent<MeshRenderer>().material.color = defaultColor;

            TMP_Text label = Instantiate(cellLabelPrefab, gridCanvas.transform, false);
            label.rectTransform.anchoredPosition =
                new Vector2(position.x, position.z);
            label.text = cell.coordinates.ToStringOnSeparateLines();
        }
    }
}