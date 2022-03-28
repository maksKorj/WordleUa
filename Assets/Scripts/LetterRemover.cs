using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LetterRemover : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster _raycaster;
    [SerializeField] private EventSystem _eventSystem;

    private Touch _touch;
    private PointerEventData _pointerEventData;
    private List<RaycastResult> _results = new List<RaycastResult>();

    private void Awake()
        => _pointerEventData = new PointerEventData(_eventSystem);

    private void Update() => CheckTap();

    private void CheckTap()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                CheckRaycast();
            }
        }
    }

    private void CheckRaycast()
    {
        _results.Clear();

        _pointerEventData.position = _touch.position;
        _raycaster.Raycast(_pointerEventData, _results);

        foreach (RaycastResult result in _results)
        {
            if (IsCorrectRaycastResult(result))
                return;
        }
    }

    private bool IsCorrectRaycastResult(RaycastResult raycastResult)
    {
        if(raycastResult.gameObject.TryGetComponent(out Cell cell) && CanClearCell(cell))
        {
            cell.Clear();
            return true;
        }

        return false;
    }

    private bool CanClearCell(Cell cell)
        => cell.Letter != null && cell.IsPainted == false;
}
