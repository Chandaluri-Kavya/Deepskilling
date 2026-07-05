double presentValue = 10000;
double growthRate = 0.10;
int years = 5;

double futureValue = FinancialForecast.PredictFutureValue(presentValue, growthRate, years);

Console.WriteLine($"Future Value after {years} years = {futureValue:F2}");