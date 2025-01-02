"use string";

const readlineSync = require("readline-sync");

function execute(program) {
  // We simulate queue data structure using an array
  const queue = [];

  for (const instruction of program) {
    if (instruction == "peek") {
      if (queue.length > 0) {
        console.log([0]);
      } else {
        console.log("Queue is empty");
      }
    } else if (instruction == "pop") {
      if (queue.length > 0) {
        // Remove first element from the queue
        queue.shift();
      } else {
        console.log("Queue is empty");
      }
    } else {
      const data = parseInt(instruction.substring(5));
      queue.push(data);
    }
  }
  return queue;
}

// Generator function to read input from the user. It can pause and resume the execution.
function* main() {
  // Yield is used to pause and resume a generator function
  const programLength = parseInt(yield);
  const program = [];
  for (let i = 0; i < programLength; i++) {
    program.push(yield);
  }
  const res = execute(program);
  console.log(res.join(" "));
}

const generator = main();

// Whne we call generator.next(), the execution of the generator function starts
generator.next();

const programLength = readlineSync.question(
  "Enter the number of instructions: "
);
generator.next(programLength); //We pass the program length to the generator function

for (let i = 0; i < programLength; i++) {
  const instruction = readlineSync.question(`Enter instruction ${i + 1}: `);
  generator.next(instruction); // We pass the instruction to the generator function
}
