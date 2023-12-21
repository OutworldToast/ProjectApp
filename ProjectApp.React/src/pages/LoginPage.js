import "../CSS/Dark.css";
import {Link} from 'react-router-dom';

export default function LoginPage () {
    return (
    <div class="login-container">
        <Link to='/'> Home </Link>
        <h2>Login</h2>
            <form class="login-form">
        <div class="form-group">
            <label for="username">Gebruikersnaam:</label>
            <input type="text" id="username" name="username" required />
        </div>
        <div class="form-group">
            <label for="password">Wachtwoord:</label>
            <input type="password" id="password" name="password" required />
        </div>
        <div class="form-group">
            <button type="submit">Inloggen</button>
        </div>
        </form>
    </div>
    )
}