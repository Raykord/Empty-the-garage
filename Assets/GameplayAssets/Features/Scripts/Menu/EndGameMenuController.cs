using EmptyTheGarage.Feature.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmptyTheGarage.Feature.Menu
{
    public class EndGameMenuController : MonoBehaviour
    {
        [SerializeField]
        protected ScenesController scenesController = default;

        public virtual void NewGame() => scenesController.LoadSceneByName(ScenesInGame.Gameplay);
        public virtual void ExitGame() => Application.Quit();
    }
}