import React, { useState } from "react";
import InputField from "../InputField/InputField";
import ResultDisplay from "../ResultDisplay/ResultDisplay";

interface MortgageCalculatorProps {}

const MortgageCalculator: React.FC<MortgageCalculatorProps> = () => {
  const [mortgageAmount, setMortgageAmount] = useState<number>(0);
  const [interestRate, setInterestRate] = useState<number>(0);
  const [condoFee, setCondoFee] = useState<number>(0);
  const [monthlySalary, setMonthlySalary] = useState<number>(0);
  const [leftOver, setLeftOver] = useState<number>(0);

  function calculateMonthlyExpenses() {
    const monthlyInterestRate = interestRate / 100 / 12;
    const monthlyMortgagePayment =
      (mortgageAmount * monthlyInterestRate) /
      (1 - Math.pow(1 + monthlyInterestRate, -240)); // Assuming a 20-year mortgage
    const totalMonthlyExpenses = monthlyMortgagePayment + condoFee;
    const monthlyLeftOver = monthlySalary - totalMonthlyExpenses;
    setLeftOver(monthlyLeftOver);
  }

  return (
    <div className="MortgageCalculator">
      <header className="MortgageCalculator-header">
        <p>Budjetin laskuri</p>
      </header>
      <InputField
        label="Asuntolainen kokonaismäärä"
        value={mortgageAmount}
        onChange={setMortgageAmount}
      />
      <InputField
        label="Asuntolainan korko"
        value={interestRate}
        onChange={setInterestRate}
      />
      <InputField
        label="Hoitovastike"
        value={condoFee}
        onChange={setCondoFee}
      />
      <InputField
        label="Kuukausipalkka (netto)"
        value={monthlySalary}
        onChange={setMonthlySalary}
      />
      <button onClick={calculateMonthlyExpenses}>Calculate</button>
      {leftOver !== null && (
        <ResultDisplay label="Kuukaudessa jää" value={leftOver} />
      )}
    </div>
  );
};

export default MortgageCalculator;
