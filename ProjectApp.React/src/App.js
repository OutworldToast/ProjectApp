import React from "react";
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import LoginPage from './pages/LoginPage.js';
import BasePage from './pages/BasePage.js';
import HomePage from './pages/HomePage.js';
import RegisterPage from './pages/RegisterPage.js';
import ProfielPage from './pages/ProfielPage.js';

import './CSS/Light.css';
import './CSS/Dark.css';

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route exact path="/" element={<BasePage />} />
          <Route exact path="/LoginPage" element={<LoginPage />} />
          <Route exact path="/HomePage" element={<HomePage />} />
          <Route exact path="/RegisterPage" element={<RegisterPage />} />
          <Route exact path="/ProfielPage" element={<ProfielPage />} />
          {/* <Route exact path="/ChatPage" element={<ChatPage />} /> */}
        </Routes>
      </div>
    </Router>
  );
}

export default App;
