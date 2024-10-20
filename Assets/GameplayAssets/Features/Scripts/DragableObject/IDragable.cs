using UnityEngine;

public interface IDragable
{
    public void OnHighlight();

    public void OffHighlight();

    public void Drag(Transform camera, float holdDistance);

    public void Drop();
}
