import "../CSS/Light.css";
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import LinkButton from "../components/LinkButton";

// LoginPage-component
export default function LoginPage() {
  const navigate = useNavigate();
  const [emailadres, setEmailadres] = useState('');
  const [wachtwoord, setWachtwoord] = useState('');

  const handleLogin = async (e) => {
    e.preventDefault();

    let userCredentials = { emailadres: emailadres, wachtwoord: wachtwoord };

    const response = await fetch('api/Gebruiker/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(userCredentials),
    });

    if (response.ok) {
      console.log('Inloggen succesvol');
      navigate('/HomePage');
    } else {
      console.error('Inloggen mislukt');
    }
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      <form className="login-form" onSubmit={handleLogin}>
        <div className="form-group">
          <label htmlFor="username">Email:</label>
          <input type="text" value={emailadres} onChange={(e) => setEmailadres(e.target.value)} required />
        </div>
        <div className="form-group">
          <label htmlFor="password">Wachtwoord:</label>
          <input type="password" value={wachtwoord} onChange={(e) => setWachtwoord(e.target.value)} required />
        </div>
        <div className="form-group">
          <button type="submit">Inloggen</button>
          <div style={{ height: '10px' }}></div>
            <LinkButton body={"Registreer"} link={"/RegisterPage"}>Registreer</LinkButton>
        </div>
      </form>
    </div>
  );
}
