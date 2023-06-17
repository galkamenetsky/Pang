using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class GameBoundsLocator : MonoBehaviour
{
    [SerializeField] private float colDepth = 3f;
    [SerializeField] private Transform topCollider;
    [SerializeField] private Transform bottomCollider;
    [SerializeField] private Transform rightCollider;
    [SerializeField] private Transform leftCollider;

    private Vector2 screenSize;
  
    public Vector3 CameraPosition;

    private void Start()
    {
        GetScreenSize();
        LocateObjects();
    }
    private void GetScreenSize()
    {
        // Generate world space point Information
        CameraPosition = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)), Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height))) * 0.5f;
    }
    private void LocateObjects()
    {
        //Change our Scale and Position
        //RightCollider:
        rightCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        rightCollider.position = new Vector3(CameraPosition.x + screenSize.x + (rightCollider.localScale.x * 0.5f), CameraPosition.y, 0f);
        //LeftCollider:
        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        leftCollider.position = new Vector3(CameraPosition.x - screenSize.x - (leftCollider.localScale.x * 0.5f), CameraPosition.y, 0f);
        //TopCollider:
        topCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
        topCollider.position = new Vector3(CameraPosition.x, CameraPosition.y + screenSize.y + (topCollider.localScale.y * 0.5f), 0f);
        //BottomCollider:
        bottomCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
        bottomCollider.position = new Vector3(CameraPosition.x, CameraPosition.y - screenSize.y * 0.7f, 0f);
    }
#if UNITY_EDITOR
    void Update()
    {
        GetScreenSize();
        LocateObjects();
    }
#endif
}
