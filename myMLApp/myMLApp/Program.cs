using MyMLApp;
// Add input data

public class MyApp
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Please give me a review of this restaurant\n");

        string response = Console.ReadLine();

        try
        {
            string userInputAsString = string.Format(response);
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }

        ReviewSentiment(response);

    }

    public static void ReviewSentiment(string sentiment)
    {
        var sampleData = new SentimentModel.ModelInput()
        {
            Col0 = sentiment
        };

        // Load model and predict output of sample data
        var result = SentimentModel.Predict(sampleData);

        // If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
        sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
        Console.WriteLine($"Text: {sampleData.Col0}\nSentiment: {sentiment}");
    }
};