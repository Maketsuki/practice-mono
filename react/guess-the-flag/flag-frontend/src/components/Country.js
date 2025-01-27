import { useState } from "react";


const Alert = ({ text }) => {
  return (
    <div>
      <h3>{text}</h3>
    </div>
  );
};

const Country = ({ country, isRight }) => {
  const [visible, setVisible] = useState(false);

  const checkIfRight = () => {
    if (isRight) {
      setVisible(true);
    }
  };

  return (
    <>
      <h2>{country.name.common}</h2>
      <img src={country.flags.png} alt={`${country.name.common} flag`} />
      <button onClick={checkIfRight}>Guess!</button>
      {visible === true ? <div></div> : <Alert text={"Oikein!"}></Alert>}
      <div></div>
    </>
  );
};

export default Country;
