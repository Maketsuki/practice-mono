#include <stdio.h>

int calculateSum(int numbers[], int arraySize) {
	int sum = 0;

	for (int i = 0; i < arraySize; i++) {
		sum = sum + numbers[i];
	}
	return sum;
}

double calculateAverage(int numbers[], int arraySize) {
	int sum = calculateSum(numbers, arraySize);
	return (double)sum / arraySize;
}

int returnMinValue(int numbers[], int arraySize) {
	// I had an issue in this, that if the first number was actually the smalles, we never assigned to return value..
	int value = numbers[0];

	for (int i = 0;i < arraySize; i++) {
		// Current number to check
		int currentNumber = numbers[i];

		for (int x = 0; x < arraySize;x++) {
			// If currentnumber is larger than checked number
			if (currentNumber > numbers[x]) {
				// if the final value is larger than
				if (value > numbers[x]) {
					// set the new final value
					value = numbers[x];
				}
			}
		}
	}
	return value;
}

int returnMaxValue(int numbers[], int arraySize) {
	int value = numbers[0];

	for (int i = 0;i < arraySize; i++) {
		int currentNumber = numbers[i];

		for (int x = 0; x < arraySize;x++) {
			if (currentNumber > numbers[x]) {
				if (value < numbers[x]) {
					value = numbers[x];
				}
			}
		}
	}
	return value;
}

void main() {
	int amountOfNumbers = 0;
	int arrayOfNumbers[100];

	while (amountOfNumbers <= 0) {
		printf("How many numbers do you want to enter? Enter only positive numbers\n");
		scanf_s("%d", &amountOfNumbers);

		if (amountOfNumbers <= 0) {
			printf("You entered a negative number or zero. Please enter a positive number\n");
		}
	}

	for (int i = 0; i < amountOfNumbers; i++) {
		printf("Enter number: %d\n", i + 1);
		scanf_s("%d", &arrayOfNumbers[i]);
	}

	int sum = calculateSum(arrayOfNumbers, amountOfNumbers);
	int min = returnMinValue(arrayOfNumbers, amountOfNumbers);
	int max = returnMaxValue(arrayOfNumbers, amountOfNumbers);
	double average = calculateAverage(arrayOfNumbers, amountOfNumbers);

	if (min == 0) {
		printf("\n Calculation of MinValue failed");
	}

	printf("The total sum of numbers is: %d \n", sum);
	printf("The smallest value is: %d \n", min);
	printf("The largest value is: %d \n", min);
	printf("Average is: %.2f \n", average);
}