import "../CSS/Light.css";
import { Navigate, useNavigate } from 'react-router-dom';
import { useState } from 'react';
import LinkButton from "../components/LinkButton";
import Cookies from "js-cookie";

// LoginPage-component
export default function LoginPage() {
  const navigate = useNavigate();
  const [emailadres, setEmailadres] = useState('');
  const [wachtwoord, setWachtwoord] = useState('');
  const [loginStatus, setLoginStatus] = useState(null); // Toegevoegde staat voor loginstatus

  async function getUser() {
    fetch(`api/Gebruiker/current`)
      .then(response => response.json())
      .then(data => {setCookie(data);})
      .catch(err => console.log(err));
  }

  function setCookie(data) {
    console.log(data);
    // console.log(data.id); //data.id crasht willekeurig alles??
    Cookies.set('gebruiker', '2', { expires: 1 })
  } 

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
      await getUser();
      setCookie();
      setLoginStatus('success'); // Set loginstatus op 'success' bij succes
      navigate('/HomePage');
    } else {
      console.error('Inloggen mislukt');
      setLoginStatus('failure'); // Set loginstatus op 'failure' bij mislukking
    }
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      {loginStatus === 'success' && <div style={{ color: 'green' }}>Inloggen succesvol!</div>}
      {loginStatus === 'failure' && <div style={{ color: 'red' }}>Inloggen mislukt. Controleer uw gegevens en probeer opnieuw.</div>}
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
          <LinkButton body={"Registreer"} link={"/RegisterPage"}>
            Registreer
          </LinkButton>
        </div>
      </form>
    </div>
  );
}