#include <stdio.h>

typedef struct {
	int arr[100];
} Stack;



Stack createStackStruct(int arr[], int size) {
	Stack stack;
	for (int i = 0; i < size; i++) {
		stack.arr[i] = arr[i];
	}
	return stack;
}

static void printArray(int arr[], int size) {
	for (int i = 0; i < size; i++) {
		printf("\n%d ", arr[i]);
	}
	printf("\n");
}

static void printStack(Stack stack, int size) {
	printArray(stack.arr, size);
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

	Stack stackStruct = createStackStruct(stack, numberOfItemsInStack);
	printStack(stackStruct, numberOfItemsInStack);

    return 0;
}


