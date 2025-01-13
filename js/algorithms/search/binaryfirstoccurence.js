"use strict";

/**
 * Finds the first occurrence of a target value in a sorted array.
 * @param {number[]} arr - The sorted array to search.
 * @param {number} target - The value to search for.
 * @returns {number} The index of the first occurrence of the target value if found, otherwise -1.
 */
function findFirstOccurrence(arr, target) {
  let left = 0; // Initialize the left pointer to the start of the array
  let right = arr.length - 1; // Initialize the right pointer to the end of the array
  let targetIndex = -1; // Variable to store the index of the first occurrence

  // Continue searching while the left pointer is less than or equal to the right pointer
  while (left <= right) {
    const mid = Math.floor((left + right) / 2); // Calculate the middle index
    if (arr[mid] === target) {
      // Check if the middle element is the target
      targetIndex = mid;
      right = mid - 1; // Move the right pointer to the left of mid to find the first occurrence
    } else if (arr[mid] < target) {
      // If the middle element is less than the target
      left = mid + 1; // Move the left pointer to the right of mid
    } else {
      // If the middle element is greater than the target
      right = mid - 1; // Move the right pointer to the left of mid
    }
  }
  return targetIndex; // Return the index of the first occurrence or -1 if not found
}

function splitWords(s) {
  return s === "" ? [] : s.split(" ");
}

function* main() {
  const arr = splitWords(yield).map((v) => parseInt(v));
  const target = parseInt(yield);
  const res = findFirstOccurrence(arr, target);
  console.log(res);
}

class EOFError extends Error {}
{
  const gen = main();
  const next = (line) => gen.next(line).done && process.exit();
  let buf = "";
  next();
  process.stdin.setEncoding("utf8");
  process.stdin.on("data", (data) => {
    const lines = (buf + data).split("\n");
    buf = lines.pop();
    lines.forEach(next);
  });
  process.stdin.on("end", () => {
    buf && next(buf);
    gen.throw(new EOFError());
  });
}
