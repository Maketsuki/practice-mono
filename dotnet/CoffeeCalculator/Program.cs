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

int pricePer100g = 1;
decimal numberOfCupsInPackage = 500 / 7;
// Round the number of cups in a package to the nearest whole number
numberOfCupsInPackage = Math.Round(numberOfCupsInPackage);
decimal pricePerCup = (pricePer100g * 5) / numberOfCupsInPackage;

Console.WriteLine("How many desiliters of coffee do you drink in a day? \n **One cup is 1.15 desiliters**");
decimal dailyAmount = int.Parse(Console.ReadLine());
Console.WriteLine("You drink " + dailyAmount + " desiliters of coffee in a day.");
decimal yearlyAmountDl = dailyAmount * 365;
decimal yearlyAmountL = yearlyAmountDl / 10;
decimal yearlyAmountCups = yearlyAmountDl / 1.25m;
decimal yearlyAmountCaffeineMg = yearlyAmountCups * 100;
decimal yearlycoffeeCost = Math.Round(pricePerCup * yearlyAmountCups);
Console.WriteLine("You drink " + yearlyAmountL + " liters of coffee in a year. " +
    "\n That means " + yearlyAmountCups + " cups in a year. " +
    "\n That includes " + yearlyAmountCaffeineMg + " mg of caffeine!" +
    "\n that costs you " + yearlycoffeeCost + " euros");