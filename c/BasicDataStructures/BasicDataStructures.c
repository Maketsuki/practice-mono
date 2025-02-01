
#include <stdio.h>




static void printArray(int arr[], int size) {
	for (int i = 0; i < size; i++) {
		printf("\n%d ", arr[i]);
	}
	printf("\n");
}


int main(__RETURN_POLICY_VOID)
{
	int numberOfItemsInStack;
	int stack[100];

	printf("How many integers would you like to store in a stack? \n");
	scanf_s("%d", &numberOfItemsInStack);

	for (int i = 0; i < numberOfItemsInStack; i++) {
		printf("\n Enter integer number %d: ", i + 1);
		scanf_s("%d", &stack[i]);
	}

	if (numberOfItemsInStack > 0) {
		printf("\n\n The integers in the stack are: \n");
		printArray(stack, numberOfItemsInStack);
	}
	else {
		printf("\n\n The stack is empty. \n");
	}

    return 0;
}


