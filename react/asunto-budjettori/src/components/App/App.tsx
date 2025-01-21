import React from "react";
import logo from "./logo.svg";
import "./App.css";
import MortgageCalculator from "../MortgageCalculator/MortgageCalculator";

function App() {
  return (
    <div className="App">
      <header className="App-header">AsuntoBudjettori</header>
      <div className="MortgageCalculator">
        <MortgageCalculator />
      </div>
    </div>
  );
}

export default App;
