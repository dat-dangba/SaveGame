using Unity.Collections;

namespace SaveGame
{
    public class BaseDataSave
    {
        public SaveValue<int> Version = new();
    }
}