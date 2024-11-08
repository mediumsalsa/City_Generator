using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHelper : MonoBehaviour
{
    public GameObject roadStraight, roadCorner, road3way, road4way, roadEnd;
    Dictionary<Vector3Int, GameObject> roadDictionary = new Dictionary<Vector3Int, GameObject>();
    HashSet<Vector3Int> fixRoadCandidates = new HashSet<Vector3Int>();

    public void PlaceStreetPositions(Vector3 startPosition, Vector3Int direction, int length)
    {
        var rotation = Quaternion.identity;
        if (direction.x == 0)
        {

        }
    }

}
