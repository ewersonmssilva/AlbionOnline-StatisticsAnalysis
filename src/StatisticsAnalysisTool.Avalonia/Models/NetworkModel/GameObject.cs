using StatisticsAnalysisTool.Avalonia.Enumerations;

namespace StatisticsAnalysisTool.Avalonia.Models.NetworkModel
{
    public abstract class GameObject
    {
        public long? ObjectId { get; set; }
        public GameObjectType ObjectType { get; set; } = GameObjectType.Unknown;
        public GameObjectSubType ObjectSubType { get; set; } = GameObjectSubType.Unknown;
    }
}