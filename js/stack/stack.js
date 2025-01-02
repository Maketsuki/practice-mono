// Strict enables strict mode, which is a restricted variant of JavaScript that disallows some of the language's more problematic features.
// for example, in strict mode, you can not use undeclared variables.
"use strict";

// This library is needed to read input from the user
const readlineSync = require("readline-sync");

function execute(program) {
  //Empty array to simulate stack data structure
  const stack = [];

  //for...of loop acts similarly as foreach in C# or Java
  for (const instruction of program) {
    // if instruction is "peek", log the last element of the stack (or top element of the stack)
    if (instruction == "peek") {
      console.log(stack[stack.length - 1]);
    } else if (instruction == "pop") {
      // if instruction is "pop", remove the last element of the stack
      stack.pop();
    } else {
      // if instruction is "push", get the data from the instruction and push it to the stack
      // should be in a format "push <data>"
      const data = parseInt(instruction.substring(5));
      if (isNaN(data)) {
        console.log("Invalid instruction");
        break;
      }
      stack.push(data);
    }
  }
  return stack;
}

// Generator function to read input from the user
function* main() {
  // yield is used to pause and resume a generator function
  const programLength = parseInt(yield);
  const program = [];
  for (let i = 0; i < programLength; i++) {
    // push the instruction to the program array
    program.push(yield);
  }
  const res = execute(program);
  console.log(res.join(" "));
}

const generator = main();
generator.next();

const programLength = readlineSync.question(
  "Enter the number of instructions: "
);
generator.next(programLength);

for (let i = 0; i < programLength; i++) {
  const instruction = readlineSync.question(`Enter instruction ${i + 1}: `);
  generator.next(instruction);
}
