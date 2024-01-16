import React from "react";

import logo from "../Resources/sia/sta.png";
import "../CSS/Light.css";

export default function HomePage() {
    return (
        <div class="BasePage">
              <header>
            <h1>Stichting Accessibility</h1>
        </header>
      
        <img src={logo} alt="Stichting Accessibility" className='logo'/>
       
        <nav id='menu'>
        <ul>
          <li><a href='http://'>Home</a></li>
          <li><a href='http://'>Chat</a></li>
          <li><a href='http://'>Profiel</a></li>
          <li><a href='http://'>Over ons</a></li>
          <li><a href='http://'>Uitloggen</a></li>
        </ul>
      </nav>
        
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