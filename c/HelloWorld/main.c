#include <stdio.h>

int main() {
	int valuesFromUser[5];
	int arraySize = sizeof(valuesFromUser) / sizeof(valuesFromUser[0]);

	printf("Enter %d number values:\n", arraySize);

	for (int i = 0; i < arraySize; i++) {
		printf("Enter value %d: ", i + 1);
		scanf_s("%d", &valuesFromUser[i]); // This reads user input and stores it in the array
	}

	printf("You entered these numbers:\n");
	for (int i = 0; i < arraySize; i++) {

		printf("%d\n", valuesFromUser[i]);
	}

	return 0;
}