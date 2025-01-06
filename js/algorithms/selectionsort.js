"use strict";

function sortList(unsortedList) {
  const n = unsortedList.length;

  for (let i = 0; i < n; i++) {
    // Assume the current position is the minimum
    let minIndex = i;

    // Find the minimum element in the unsorted part of the list
    for (let j = i; j < n; j++) {
      if (unsortedList[j] < unsortedList[minIndex]) {
        minIndex = j;
      }
    }
    // Swap the minimum element with the first element of the unsorted part
    [unsortedList[i], unsortedList[minIndex]] = [
      unsortedList[minIndex],
      unsortedList[i],
    ];
  }
  return unsortedList;
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
