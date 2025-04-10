using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameObject
    {
        public char displayCharacter;
        public GameCell currentCell;
        public GameObjectType type;

        public GameObject()
        {

        }
        public GameObject(GameObjectType type, char displayCharacter)
        {

        }
        //public static GameObjectType GetGameObjectType(string displayCharacter)
        //{
            
        //}


    }
}
