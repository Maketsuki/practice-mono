"use strict";

function sortList(unsortedList) {
  const n = unsortedList.lenght;

  // This is the base case: A list of size 1 or 0 is already sorted
  if (n <= 1) return unsortedList;

  // Split the list in half and sort each half
  const midpoint = Math.floor(n / 2);
  const leftList = sortList(unsortedList.slice(0, midpoint));
  const rightList = sortList(unsortedList.slice(midpoint));

  const res = [];
  let leftPtr = 0;
  let rightPtr = 0;

  // Merge the sorted left and right lists with two pointers
  while (leftPtr < midpoint || rightPtr < n - midpoint) {
    if (leftPtr === midpoint) {
      // If left list is empty, append element from right list
      res.push(rightList[rightPtr]);
      rightPtr++;
    } else if (rightPtr === n - midpoint) {
      // If right list is empty, append element from left list
      res.push(leftList[leftPtr]);
      leftPtr++;
    } else if (leftList[leftPtr] <= rightList[rightPtr]) {
      // Append smaller element from left list
      res.push(leftList[leftPtr]);
      leftPtr++;
    } else {
      // Append smaller element from right list
      res.push(rightList[rightPtr]);
      rightPtr++;
    }
  }
  return res;
}

function splitWords(s) {
  return s === "" ? [] : s.split(" ");
}

function* main() {
  const unsortedList = splitWords(yield).map((v) => parseInt(v));
  const res = sortList(unsortedList);
  console.log(res.join(" "));
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
