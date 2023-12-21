import React from "react";
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import LoginPage from './pages/LoginPage.js';
import BasePage from './pages/BasePage.js';
import HomePage from './pages/HomePage.js';
import './Style.css';
import ChatPage from "./pages/ChatPage.js";

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route exact path="/" element={<BasePage />} />
          <Route exact path="/LoginPage" element={<LoginPage />} />
          <Route exact path="/HomePage" element={<HomePage />} />
          <Route exact path="/ChatPage" element={<ChatPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
