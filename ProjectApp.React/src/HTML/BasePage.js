import React from 'react';
import {Link} from 'react-router-dom';

import logo from '../logo.svg';
import './Style.css';
import Toolbar from '../components/Toolbar.js';

export default function BasePage () {
    return (
    <div class="BasePage">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <Toolbar />
          <p>
            Edit <code>src/App.js</code> and save to reload.
          </p>
          <Link to='/LoginPage'> LoginPage </Link>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Learn React 
          </a>
        </header>
    </div>
    )
}