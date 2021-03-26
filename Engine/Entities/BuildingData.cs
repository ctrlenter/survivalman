using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace SurvivalMan
{
    public class BuildingData
    {
        public string Name;
        public string Description;
        public int Level = 1;

        public BuildingData(){

        }

        public BuildingData(string name, string desc){
            Name = name;
            Description = desc;
        }

    }
}