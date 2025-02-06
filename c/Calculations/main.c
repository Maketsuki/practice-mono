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
	int value = numbers[0];
	for (int i = 1; i < arraySize; i++) {
		if (numbers[i] < value) {
			value = numbers[i];
		}
	}
	return value;
}

int returnMaxValue(int numbers[], int arraySize) {
	int value = numbers[0];
	for (int i = 1; i < arraySize; i++) {
		if (numbers[i] > value) {
			value = numbers[i];
		}
	}
	return value;
}

int main() {
	int amountOfNumbers = 0;
	int arrayOfNumbers[100];

	while (amountOfNumbers <= 0 || amountOfNumbers > 100) {
		printf("How many numbers do you want to enter? Enter only positive numbers (up to 100):\n");

		// Attempt to read an integer
		int result = scanf_s("%d", &amountOfNumbers);

		// Check if scanf_s successfully read one integer
		if (result != 1) {
			printf("You gave invalid input. Let's try again.\n");

			// Clear the invalid input from the buffer
			int ch;
			while ((ch = getchar()) != '\n' && ch != EOF); // discard characters

			amountOfNumbers = 0;  // reset to force re-prompt
			continue;
		}

		// Additional checks for range
		if (amountOfNumbers <= 0) {
			printf("You entered a negative number or zero. Please enter a positive number.\n");
		}
		else if (amountOfNumbers > 100) {
			printf("You entered a number greater than 100. Please enter a number up to 100.\n");
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

	printf("The total sum of numbers is: %d \n", sum);
	printf("The smallest value is: %d \n", min);
	printf("The largest value is: %d \n", max);
	printf("Average is: %.2f \n", average);

	return 0; //Returning int from main follows the ISO C standard and ensures proper return of an exit status.
}