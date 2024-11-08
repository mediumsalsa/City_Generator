using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHelper : MonoBehaviour
{
    public GameObject prefab;
    public int maxBuildingheight = 3;
    public Dictionary<Vector3Int, GameObject> structuredDictionary = new Dictionary<Vector3Int, GameObject>();

    public void PlaceStructuresAroundRoad(List<Vector3Int> roadPositions)
    {
        Dictionary<Vector3Int, Direction> freeEstateSpots = FindFreeSpacesAroundRoad(roadPositions);
        foreach (var position in freeEstateSpots.Keys)
        {
            GameObject building = Instantiate(prefab, position, Quaternion.identity, transform);
            float height = UnityEngine.Random.Range(1f, maxBuildingheight);
            building.transform.localScale = new Vector3(1, height, 1);

            Color color;
            if (UnityEngine.Random.value > 0.5f)
            {
                float grayValue = UnityEngine.Random.Range(0.2f, 0.7f);
                color = new Color(grayValue, grayValue, grayValue);
            }
            else
            {
                float blueValue = UnityEngine.Random.Range(0.2f, 0.5f);
                color = new Color(blueValue * 0.5f, blueValue * 0.5f, blueValue);
            }

            Renderer renderer = building.GetComponent<Renderer>();
            if (renderer == null)
            {
                renderer = building.GetComponentInChildren<Renderer>();
            }

            if (renderer != null)
            {
                renderer.material.color = color;
            }
        }
    }

    private Dictionary<Vector3Int, Direction> FindFreeSpacesAroundRoad(List<Vector3Int> roadPositions)
    {
        Dictionary<Vector3Int, Direction> freeSpaces = new Dictionary<Vector3Int, Direction>();
        foreach (var position in roadPositions)
        {
            var neighbourDirections = PlacementHelper.FindNeighbour(position, roadPositions);
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                if (neighbourDirections.Contains(direction) == false)
                {
                    var newPosition = position + PlacementHelper.GetOffsetFromDirection(direction);
                    if (freeSpaces.ContainsKey(newPosition))
                    {
                        continue;
                    }
                    freeSpaces.Add(newPosition, Direction.Right);
                }
            }
        }
        return freeSpaces;
    }

}
