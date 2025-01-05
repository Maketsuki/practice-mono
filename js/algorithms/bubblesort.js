"use strict";

function sortList(unsortedList) {
  // Bubble Sort Algorithm
  let length = unsortedList.length;
  for (let i = 0; i < length - 1; i++) {
    for (let j = 0; j < length - i - 1; j++) {
      if (unsortedList[j] > unsortedList[j + 1]) {
        // Swap the elements
        let temp = unsortedList[j];
        unsortedList[j] = unsortedList[j + 1];
        unsortedList[j + 1] = temp;
      }
    }
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
