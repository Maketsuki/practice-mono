"use strict";

function sortList(unsortedList) {
  for (let i = 0; i < unsortedList.length; i++) {
    let current = i;
    while (current > 0 && unsortedList[current] < unsortedList[current - 1]) {
      const temp = unsortedList[current];
      unsortedList[current] = unsortedList[current - 1];
      unsortedList[current - 1] = temp;
      current--;
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
