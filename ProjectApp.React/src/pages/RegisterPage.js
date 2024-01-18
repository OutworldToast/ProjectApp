// src/components/RegisterForm.js
import React, { useState } from 'react';
import LinkButton from '../components/LinkButton.js';

const RegisterForm = () => {
  const [emailadres, setEmailadres] = useState('');
  const [wachtwoord, setWachtwoord] = useState('');

  const handleRegister = async () => {
    let user = {emailadres: emailadres, wachtwoord: wachtwoord};

    const response = await fetch('api/Gebruiker/registreer', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(user) ,
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
            <label>Email:
            <input type="text" value={emailadres} onChange={(e) => setEmailadres(e.target.value)} required/>
            </label>
        </div>
        <div className="registreer-group">
            <label>Wachtwoord:
            <input type="password" value={wachtwoord} onChange={(e) => setWachtwoord(e.target.value)} required/>
            </label>
        </div>
        <div className="registreer-group">
            <button onClick={handleRegister} type="submit">Registreer</button>
            <div style={{ height: '10px' }}></div>
            <LinkButton body = {"Login"} link = {"/LoginPage"}>Login</LinkButton>

        </div>
        </form>
    </div>
  );
};

export default RegisterForm;
