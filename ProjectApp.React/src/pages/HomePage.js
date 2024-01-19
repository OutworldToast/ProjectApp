import React from "react";

import logo from "../Resources/sia/sta.png";
import ToonGebruikerOnderzoeken from "../components/ToonGebruikersOnderzoek";
// import ToonRelevanteOnderzoeken from "../components/ToonRelevanteOnderzoeken";
import ToonData from "../components/ToonData";
import "../CSS/Light.css";

export default function HomePage() {
    return (
        <div className="BasePage">
              <header>
            <h1>Stichting Accessibility</h1>
        </header>
      
        <img src={logo} alt="Stichting Accessibility" className='logo'/>
      
        <nav id='menu'>
        <ul>
          <li><a href='HomePage'>Home</a></li>
          <li><a href='ChatPage'>Chat</a></li>
          <li><a href='ProfielPage'>Profiel</a></li>
          <li><a href='OnderzoekPage'>Onderzoek</a></li>
          <li><a href='LoginPage'>Uitloggen</a></li>
          <li><a href='MaakOnderzoekPage'>Maak Onderzoek</a></li>
        </ul>
      </nav>
        
        <section id="section1">
            <h2>Mijn Onderzoeken</h2>
            <ToonGebruikerOnderzoeken/>
        </section>
    
        <section id="section2">
            <h2>Nieuwe Onderzoeken</h2>
            <ToonData/>
        </section>
    
        </div>
        
    )
    
}