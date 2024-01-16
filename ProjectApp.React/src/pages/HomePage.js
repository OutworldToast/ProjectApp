import React from "react";

import logo from "../Resources/sia/sta.png";
import "../CSS/Light.css";
import ToonData from '../components/ToonData'

export default function HomePage() {
    return (
        <div className="BasePage">
              <header>
            <h1>Stichting Accessibility</h1>
        </header>
      
        <img src={logo} alt="Stichting Accessibility" className='logo'/>
       
        <nav>
            <a href="HomePage">Home</a> |
            <a href="ChatPage">Chat</a> |
            <a href="LoginPage">Uitloggen</a> |
            <a href="ProfielPage">Profiel</a> |
            <a href="#Over ons">Over ons</a>
        </nav>

        <ToonData />
        
        <section id="section1">
            <h2>Section 1</h2>
            <p>Dit is de inhoud van de eerste sectie.</p>
        </section>
    
        <section id="section2">
            <h2>Section 2</h2>
            <p>Dit is de inhoud van de tweede sectie.</p>
        </section>
    
        <section id="section3">
            <h2>Section 3</h2>
            <p>Dit is de inhoud van de derde sectie.</p>
        </section>

        
    
        </div>
    )
}