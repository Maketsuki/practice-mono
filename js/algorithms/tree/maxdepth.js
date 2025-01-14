"use strict";

class Node {
  constructor(value, left = null, right = null) {
    this.value = value;
    this.left = left;
    this.right = right;
  }
}

// DFS = Depth-First Search
// Function to calculate the maximum depth of a binary tree using Depth-First Search (DFS)
function dfs(root) {
  if (root === null) return 0; // If the current node is null, return 0
  return Math.max(dfs(root.left), dfs(root.right)) + 1; // Recursively calculate the depth of left and right subtrees and add 1 for the current node
}

function treeMaxDepth(root) {
  return root !== null ? dfs(root) - 1 : 0;
}

// this function builds a tree from input
function buildTree(nodes, f) {
  const val = nodes.next().value;
  if (val === "x") return null;
  const left = buildTree(nodes, f);
  const right = buildTree(nodes, f);
  return new Node(f(val), left, right);
}

function splitWords(s) {
  return s === "" ? [] : s.split(" ");
}

function* main() {
  const root = buildTree(splitWords(yield)[Symbol.iterator](), parseInt);
  const res = treeMaxDepth(root);
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
