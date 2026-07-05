public class FinancialForecast
{
    public static double PredictFutureValue(double presentValue, double growthRate, int years)
    {
        if (years == 0)
            return presentValue;

        return PredictFutureValue(presentValue * (1 + growthRate), growthRate, years - 1);
    }
}