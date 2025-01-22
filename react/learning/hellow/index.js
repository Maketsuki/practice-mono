import React from "react";
import { createRoot } from "react-dom/client"; //React-dom is for the web. React is platform agnostic.

// This acceptrs 3 arguments.
// The first is the type of element, the second is the props, and the third is the children.
const element = React.createElement("p", { id: "hello" }, "Hello World!");

const container = document.querySelector("#root");
const root = createRoot(container);
root.render(element);
