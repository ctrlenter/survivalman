namespace SurvivalMan{
    public class EntityData{
        public static Entity Tree = new Entity("world/tree", 2);
    }

    public enum EntityType{
        Player,
        Tree,
        Rock,
        Building,
        Item
    }
}