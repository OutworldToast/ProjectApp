import React from 'react';
import {Link} from 'react-router-dom';

import logo from '../Resources/sia/sia.png';
import '../CSS/Light.css';
import Toolbar from '../components/Toolbar.js';
import ToolbarStart from '../components/ToolbarStart.js';

export default function BasePage () {
    return (
    <div class="BasePage">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <ToolbarStart />
        </header>
    </div>
    )
}