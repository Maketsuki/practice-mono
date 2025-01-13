"use strict";

// Define a Node class to represent each node in the binary tree
class Node {
  constructor(value) {
    this.value = value;
    this.left = null; // Left Child
    this.right = null; // Right Child
  }
}

// Function to perform in-order traversal of a binary tree
function inOrderTraversal(root) {
  if (root != null) {
    inOrderTraversal(root.left); // Traverse the left subtree
    console.log(root.value); // Visit the current node
    inOrderTraversal(root.right); // Traverse the right subtree
  }
}

// Function to build a binary tree from an iterator of node values
function buildTree(nodes, f) {
  const val = nodes.next().value; // Get the next value from the iterator
  if (val === "x") return null; // If the value is "x", return null (indicates no node)
  const left = buildTree(nodes, f); // Recursively build the left subtree
  const right = buildTree(nodes, f); // Recursively build the right subtree
  return new Node(f(val), left, right); // Create a new node with the value and subtrees
}

function splitWords(s) {
  return s === "" ? [] : s.split(" ");
}

function* main() {
  const root = buildTree(splitWords(yield)[Symbol.iterator](), parseInt); // Create a new node with the value and subtrees
  inOrderTraversal(root); // Perform in-order traversal of the tree
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
