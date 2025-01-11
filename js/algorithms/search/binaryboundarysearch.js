"use strict";

function findBoundary(arr) {
  let left = 0;
  let right = arr.length - 1;
  let boundaryIndex = -1;

  while (left <= right) {
    const mid = Math.floor((left + right) / 2);
    if (arr[mid]) {
      boundaryIndex = mid;
      right = mid - 1;
    } else {
      left = mid + 1;
    }
  }
  return boundaryIndex;
}

function splitWords(s) {
  return s === "" ? [] : s.split(" ");
}

function* main() {
  const arr = splitWords(yield).map((v) => v === "true");
  const res = findBoundary(arr);
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
