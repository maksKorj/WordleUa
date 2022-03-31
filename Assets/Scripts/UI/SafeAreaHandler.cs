using UnityEngine;

public class SafeAreaHandler : MonoBehaviour
{
    private void Awake() => UpdateCanvasRect();

    private void UpdateCanvasRect()
    {
        var safeArea = Screen.safeArea;
        var myRectTransform = GetComponent<RectTransform>();

        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }
}
