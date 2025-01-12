When talking about algorithms, usually a term called "time complexity" is used. It offers insight into how long an algorithm takes to complete given a certain input size.

Here is a breakdown of the most common time complexities:

## O(1)

Constant time complexity. Could be:

- Hashmap lookout
- Array access and update
- Pushing and popping elements from a stack.

## O(log(N))

log(N) grows very slowly. It usually means:

- Binary search or variant
- Processing the digits of a number

## O(N)

Linear time typically means looping through a linear data structure a constant number of times. Most commonly, this means

- Going through array/linked list
- Two pointers
- Some types of greedy
- Tree/graph traversal
- Stack/Queue

## O(K log(N))

- Heap push/pop K times.
- Binary search K times

## O(N log(N))

- Sorting

## O(N^2)

Also called "Quadratic time"

- Nested loops, e.g. visiting each matrix entry
- many brute force solutions

## O(2^N)

Grows very rapidly. Often requires memoization to avoid repeated computations and reduce complexity

- Combinatorial problems

* Often involves recursion

## O(N!)

Grows insanely rapidly. Often requires memoization to avoid repeated computations and reduce complexity
