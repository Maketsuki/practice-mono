import React from "react";

interface InputFieldProps {
  label: string;
  value: number;
  onChange: (value: number) => void;
}

const InputField: React.FC<InputFieldProps> = ({ label, value, onChange }) => {
  return (
    <div className="InputField">
      <label>{label}</label>
      <input
        type="number"
        value={value}
        onChange={(e) => onChange(parseFloat(e.target.value))}
        className="input"
      />
    </div>
  );
};

export default InputField;
