using System.Collections.Generic;
using UnityEngine;

public class EndlessRoadSimpleAutoZ : MonoBehaviour
{
    [Header("References")]
    public Transform player;          
    public GameObject roadChunkPrefab; 

    [Header("Settings")]
    public int chunksAhead = 5;       
    public int chunksBehind = 2;       
    
    private readonly List<Transform> active = new List<Transform>();
    private int startIndex;               
    private int currentCenterIndex = int.MinValue;
    private float chunkLength;             

    void Start()
    {
        chunkLength = MeasureChunkLengthZ(roadChunkPrefab);
        currentCenterIndex = Mathf.FloorToInt(player.position.z / chunkLength);
        
        int minIndex = currentCenterIndex - chunksBehind;
        int maxIndex = currentCenterIndex + chunksAhead;

        for (int i = minIndex; i <= maxIndex; i++)
            SpawnAt(i);

        startIndex = minIndex;
    }

    void Update()
    {
        int newCenterIndex = Mathf.FloorToInt(player.position.z / chunkLength);
        if (newCenterIndex == currentCenterIndex) return;

        currentCenterIndex = newCenterIndex;

        int wantMin = currentCenterIndex - chunksBehind;
        int wantMax = currentCenterIndex + chunksAhead;
        
        while (startIndex + active.Count - 1 < wantMax)
            SpawnAt(startIndex + active.Count);
        
        while (startIndex > wantMin)
        {
            startIndex--;
            SpawnAt(startIndex, insertAtFront: true);
        }
        
        while (startIndex + active.Count - 1 > wantMax)
            RemoveBack();
        
        while (startIndex < wantMin)
            RemoveFront();
    }
    
    void SpawnAt(int index, bool insertAtFront = false)
    {
        Vector3 pos = new Vector3(0f, 0f, index * chunkLength);
        
        Quaternion rot = roadChunkPrefab.transform.rotation;

        var go = Instantiate(roadChunkPrefab, pos, rot);
        go.name = $"{roadChunkPrefab.name}_{index}";

        if (insertAtFront)
            active.Insert(0, go.transform);
        else
            active.Add(go.transform);
    }
    
    void RemoveFront()
    {
        if (active.Count == 0) return;

        var t = active[0];
        active.RemoveAt(0);
        Destroy(t.gameObject);
        startIndex++;
    }
    
    void RemoveBack()
    {
        if (active.Count == 0) return;

        int last = active.Count - 1;
        var t = active[last];
        active.RemoveAt(last);
        Destroy(t.gameObject);
    }
    
    static float MeasureChunkLengthZ(GameObject prefab)
    {
        var temp = Object.Instantiate(prefab);
        temp.hideFlags = HideFlags.HideAndDontSave;
        temp.transform.position = Vector3.zero;
        temp.transform.rotation = prefab.transform.rotation;

        temp.SetActive(true);

        var renderers = temp.GetComponentsInChildren<Renderer>(true);
        if (renderers == null || renderers.Length == 0)
        {
            Object.DestroyImmediate(temp);
            return 0f;
        }

        Bounds b = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++)
            b.Encapsulate(renderers[i].bounds);

        float lengthZ = b.size.z;

        Object.DestroyImmediate(temp);
        return lengthZ;
    }
}
