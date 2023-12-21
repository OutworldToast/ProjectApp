import React from "react";
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import LoginPage from './HTML/LoginPage.js';
import BasePage from './HTML/BasePage.js';
import HomePage from './HTML/HomePage.js';
import './Style.css';

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route exact path="/" element={<BasePage />} />
          <Route exact path="/LoginPage" element={<LoginPage />} />
          <Route exact path="/HomePage" element={<HomePage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
