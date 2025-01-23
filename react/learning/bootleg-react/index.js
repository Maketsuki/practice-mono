// Idea is to create a "bootleg react". So, my own version of React.

// This is how grab a reference to an element that already exists on the page
// Let's grab the body element
const body = document.querySelector("body");

// Queryselector uses CSS selectors to grab elements. So, if you want to grab an element by its id, you use the # symbol.
// We usually call it on document, since it's the top-level DOM node, but we can actually call it on any DOM node!
const header = document.querySelector("#header");
const firstLink = header.querySelector("a");

// If multiple elements match the query, querySelector will only return the first one.

// When we have the element, we can edit it!
const node = document.querySelector("#header");
node.setAttribute("class", "bolded-title");
