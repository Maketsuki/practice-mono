// This is an application which will calculate how much Caffee I drink in a year.
// 1 First we must take amount of coffee as desiliters in a day.
// 2 Multiply it by 365 to get amount of desiliters in a year.
// 3 Convert it to liters by dividing by 10.
// One cup of coffee is 1.25 desiliters. Which is 0.125 liters. It has 100mg of caffeine.
// 4 Calculate how much caffeine I drink in a year
// 4.1 Calculate how many cups of coffee my yearly amount of desiliters is.
// You cet the result when you divide the yearly amount of coffee by 1.25
// 5 print the results
// 100g of coffee is around euro. 
// One cup takes 7g of coffee.
// 6 Calculate how much money I spend on coffee in a year.

//Constants
const decimal dlPerCup = 1.25m;
const decimal caffeinePerCupMg = 100;
const decimal gramsPerCup = 7;
const decimal pricePerPackageInEuros = 5; // Price of a 500g package
const decimal packageWeightInGrams = 500;
const int daysInAYear = 365;

decimal pricePerCup = pricePerPackageInEuros / (packageWeightInGrams / gramsPerCup);

// User input
Console.WriteLine("How many desiliters of coffee do you drink in a day? \n **One cup is 1.15 desiliters**");

if (!int.TryParse(Console.ReadLine(), out int dailyAmount))
{
    Console.WriteLine("Please enter a number");
    return;
}

if (dailyAmount < 0)
{
    Console.WriteLine("Please enter a positive number");
    return;
}

if (dailyAmount > 30)
{
    Console.WriteLine("That's a lot of coffee! Are you sure?");
}

// Calculations
decimal yearlyAmountInDl = dailyAmount * daysInAYear;
decimal yearlyAmountInLiters = yearlyAmountInDl / 10;
decimal yearlyAmountCups = yearlyAmountInDl / dlPerCup;
decimal yearlyAmountCaffeineMg = yearlyAmountCups * caffeinePerCupMg;
decimal yearlyCoffeeCostInEuros = pricePerCup * yearlyAmountCups;

// Output results
Console.WriteLine($"\nYou drink {dailyAmount} desiliters of coffee in a day.");
Console.WriteLine($"You drink {yearlyAmountInLiters:F2} liters of coffee in a year.");
Console.WriteLine($"That means {yearlyAmountCups:F2} cups in a year.");
Console.WriteLine($"That includes {yearlyAmountCaffeineMg:F2} mg of caffeine!");
Console.WriteLine($"That costs you {yearlyCoffeeCostInEuros:F2} euros per year.");
