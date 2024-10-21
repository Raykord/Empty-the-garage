using UnityEngine;

namespace EmptyTheGarage.Feature.ItemsDraging
{
    public interface IDragable
    {
        public void OnHighlight();

        public void OffHighlight();

        public void Drag(Transform camera, float holdDistance);

        public void Drop();
    }
}