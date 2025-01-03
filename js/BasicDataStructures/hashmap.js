"use strict";

const readlineSync = require("readline-sync");

function getCounter(arr) {
  // Initialize a hash map to store each number and its count
  // Js Map counts the number of occurrences of each number in the array
  const counter = new Map();
  for (const num of arr) {
    // Check if num is a key in the hash map
    if (counter.has(num)) {
      // Increment the count of num
      counter.set(num, counter.get(num) + 1);
    } else {
      // set the count of num to 1
      counter.set(num, 1);
    }
  }
  return counter;
}

function splitWords(s) {
  return s === "" ? [] : s.split(" ");
}

function* main() {
  const arr = splitWords(yield).map((v) => parseInt(v));
  const res = getCounter(arr);
  const resSorted = new Map([...res.entries()].sort((a, b) => a[0] - b[0]));
  for (const [index, value] of resSorted.entries()) {
    console.log(`${index}: ${value}`);
  }
}

const generator = main();

generator.next();

const arr = readlineSync.question("Enter the array of numbers: ");

generator.next(arr);
