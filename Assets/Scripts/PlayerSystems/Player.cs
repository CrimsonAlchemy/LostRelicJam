using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.PlayerSystems
{
    public enum PlayerType
    {
        Human,
        Shadow
    }

    public class Player : MonoBehaviour
    {
        public PlayerType playerType;
    }

}
