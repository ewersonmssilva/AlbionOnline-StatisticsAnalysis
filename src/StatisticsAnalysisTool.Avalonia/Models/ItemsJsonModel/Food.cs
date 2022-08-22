using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Avalonia.Models.ItemsJsonModel;

public class Food
{
    [JsonPropertyName("@nutritionmax")]
    public string NutritionMax { get; set; } = string.Empty;

    [JsonPropertyName("@secondspernutrition")]
    public string SecondSpernutrition { get; set; } = string.Empty;

    [JsonPropertyName("acceptedfood")]
    public AcceptedFood AcceptedFood { get; set; } = new ();

    [JsonPropertyName("@lossbeforehungry")]
    public string LossBeforeHungry { get; set; } = string.Empty;
}