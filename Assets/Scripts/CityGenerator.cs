using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public int numberOfPoints = 5;       // Number of points to generate
    public int gridSize = 10;            // Size of the grid
    public int pathLength = 5;           // Number of path segments to create
    public GameObject pointPrefab;       // Prefab for the point objects
    public GameObject pathPrefab;        // Prefab for the path objects (like tiles or cubes)

    private List<Vector2Int> points = new List<Vector2Int>();   // Store grid positions for points

    void Start()
    {
        GeneratePoints();
        GeneratePaths();
    }

    void GeneratePoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector2Int randomGridPoint = new Vector2Int(
                Random.Range(0, gridSize),
                Random.Range(0, gridSize)
            );

            // Ensure no duplicate points
            while (points.Contains(randomGridPoint))
            {
                randomGridPoint = new Vector2Int(Random.Range(0, gridSize), Random.Range(0, gridSize));
            }

            points.Add(randomGridPoint);

            // Instantiate point object at this position
            if (pointPrefab != null)
            {
                Vector3 worldPosition = new Vector3(randomGridPoint.x, 0, randomGridPoint.y);
                Instantiate(pointPrefab, worldPosition, Quaternion.identity);
            }
        }
    }

    void GeneratePaths()
    {
        foreach (Vector2Int start in points)
        {
            // Generate a random path starting from this point
            Vector2Int currentPos = start;

            for (int i = 0; i < pathLength; i++)
            {
                // Randomly choose a direction: up, down, left, or right
                Vector2Int direction = GetRandomDirection();
                Vector2Int nextPos = currentPos + direction;

                // Ensure next position is within the grid
                if (nextPos.x >= 0 && nextPos.x < gridSize && nextPos.y >= 0 && nextPos.y < gridSize)
                {
                    // Instantiate a path segment at the midpoint between currentPos and nextPos
                    Vector3 pathPosition = new Vector3(
                        (currentPos.x + nextPos.x) / 2.0f,
                        0,
                        (currentPos.y + nextPos.y) / 2.0f
                    );

                    Instantiate(pathPrefab, pathPosition, Quaternion.identity);

                    currentPos = nextPos; // Move to the next position
                }
            }
        }
    }

    Vector2Int GetRandomDirection()
    {
        // Randomly return one of four directions: up, down, left, or right
        int randomDir = Random.Range(0, 4);
        switch (randomDir)
        {
            case 0: return Vector2Int.up;    // Up
            case 1: return Vector2Int.down;  // Down
            case 2: return Vector2Int.left;  // Left
            default: return Vector2Int.right; // Right
        }
    }
}
