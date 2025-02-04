#include <stdio.h>




int calculateSum(int numbers[], int arraySize) {
	int sum = 0;

	for (int i = 0; i < arraySize; i++) {
		sum = sum + numbers[i];
	}
	return sum;
}

int returnMinValue() {

}

int returnMaxValue() {

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

	printf("The total sum of numbers is: %d", sum);

}