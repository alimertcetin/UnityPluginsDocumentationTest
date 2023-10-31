namespace XIV_Packages.SaveSystems
{
    public interface ISavable
    {
        object GetSaveData();
        void LoadSaveData(object data);
    }
}