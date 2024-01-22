// src/components/RegisterForm.js
import React, { useState } from 'react';
import LinkButton from '../components/LinkButton.js';

const RegisterForm = () => {
  const [emailadres, setEmailadres] = useState('');
  const [wachtwoord, setWachtwoord] = useState('');
  const [gebruikerType, setGebruikerType] = useState(''); // Voeg staat toe voor het type gebruiker

  const handleRegister = async () => {
    let user = {
      emailadres: emailadres,
      wachtwoord: wachtwoord,
      type: gebruikerType, // Voeg het geselecteerde gebruikerstype toe
    };

    const response = await fetch('api/Gebruiker/registreer', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(user),
    });
    

    if (response.ok) {
      console.log('Registratie succesvol');
    } else {
      console.error('Registratie mislukt');
    }
  };

  return (
    <div className="registreer-container">
      <h2>Registreer</h2>
      <form className="registreer-form">
        <div className="registreer-group">
          <label>Email:</label>
          <input type="text" value={emailadres} onChange={(e) => setEmailadres(e.target.value)} required />
        </div>
        <div className="registreer-group">
          <label>Wachtwoord:</label>
          <input type="password" value={wachtwoord} onChange={(e) => setWachtwoord(e.target.value)} required />
        </div>
        <div className="registreer-group">
          {/* Voeg het dropdown-menu toe */}
          <label>Gebruikerstype:</label>
          <select value={gebruikerType} onChange={(e) => setGebruikerType(e.target.value)} required>
            <option value="">Selecteer</option>
            <option value="panellid">Panellid</option>
            <option value="bedrijf">Bedrijf</option>
          </select>
        </div>
        <div className="registreer-group">
          <button onClick={handleRegister} type="button">Registreer</button>
          <div style={{ height: '10px' }}></div>
          <LinkButton body={"Login"} link={"/LoginPage"}>
            Login
          </LinkButton>
        </div>
      </form>
    </div>
  );
};

export default RegisterForm;
