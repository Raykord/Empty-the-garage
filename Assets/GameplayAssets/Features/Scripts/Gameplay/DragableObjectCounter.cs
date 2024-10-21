using UnityEngine;
using UnityEngine.UI;

namespace EmptyTheGarage.Feature.Gameplay
{
    public class DragableObjectCounter : MonoBehaviour
    {
        protected const string COLLECTABLE_TAG = "DtagableObject";

        [SerializeField]
        ScenesController scenesController = default;
        [SerializeField]
        protected Text counerUI = default;
        [SerializeField]
        protected int countToWin = 3;

        protected int countOfObjects = 0;

        protected virtual void Start() => counerUI.text = $"{countOfObjects}/{countToWin}";

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.tag == COLLECTABLE_TAG)
            {
                countOfObjects++;
                counerUI.text = $"{countOfObjects}/{countToWin}";
                if (countOfObjects == countToWin)
                {
                    scenesController.LoadSceneByName(ScenesInGame.Win);
                }
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.tag == COLLECTABLE_TAG)
            {
                countOfObjects--;
                counerUI.text = $"{countOfObjects}/{countToWin}";
            }
        }
    }
}