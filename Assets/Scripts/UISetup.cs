using System.Collections.Generic;
using UnityEngine;

public class UISetup : MonoBehaviour
{
    [SerializeField] private List<RectTransform> rectTransforms;

    private void Awake()
    {
        var worldPos = transform.position;
        var uiPos = Camera.main.WorldToScreenPoint(worldPos);

        var uiPosWIthOffset = new Vector3(uiPos.x, uiPos.y + 50, uiPos.z);

        foreach (var rectTransform in rectTransforms)
        {
            rectTransform.position = uiPosWIthOffset;
        }
    }
}
