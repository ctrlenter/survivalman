namespace SurvivalMan{
    public class EntityData{
        public Tree Tree = (Tree) new Tree().SetScale(4);
        public Chest Chest = (Chest) new Chest().SetScale(4);
        public Farm Farm = new Farm();
    }

    public enum EntityType{
        Player,
        Tree,
        Rock,
        Building,
        Item,
        Storage
    }
}