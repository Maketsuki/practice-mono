import React from "react";
import "./ResultDisplay.css";

interface ResultDisplayProps {
  label: string;
  value: number;
}

const ResultDisplay: React.FC<ResultDisplayProps> = ({ label, value }) => {
  // Format the value as a currency string
  const formattedValue = new Intl.NumberFormat("en-US", {
    style: "currency",
    currency: "EUR",
    maximumFractionDigits: 2,
  }).format(value);

  return (
    <div className="ResultDisplay">
      <h3>{label}</h3>
      <p>{formattedValue}</p>
    </div>
  );
};

export default ResultDisplay;
