"use strict";

/**
 *
 * @param {number[]} arr - Sorted array
 * @param {number} target - Target value to search
 * @returns {number} - Index of the target value in the array
 */
function binarySearch(arr, target) {
  let left = 0; // Initialize left pointer to the start of the array
  let right = arr.length - 1; // Initialize right pointer to the end of the array

  // Continue search while the left pointer is less than or equal to the right pointer
  while (left <= right) {
    // Calculate the middle index of the array
    const mid = left + Math.floor((right - left) / 2);

    if (arr[mid] === target) {
      // Check if the target value is found at the middle index (Amazing luck!)
      return mid; // If found, return the index
    } else if (arr[mid] < target) {
      // If the middle element is less than the target value
      left = mid + 1; // Move the left pointer to the right of the middle element
    } else {
      // If the middle element is greater than the target value
      right = mid - 1; // Move the right pointer to the left of the middle element
    }
  }
  return -1; // Return -1 if the target value is not found in the array
}

function splitWords(s) {
  return s === "" ? [] : s.split(" ");
}

function* main() {
  const arr = splitWords(yield).map((v) => parseInt(v));
  const target = parseInt(yield);
  const res = binarySearch(arr, target);
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
