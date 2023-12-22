import React from 'react';
import '../CSS/ChatPageStyle.css';
import Navigatiebalk from '../components/Navigatiebalk.js';


export default function ChatPage() {
    return (
  <div class="chat-container">
    <div class="navbar" >
        <Navigatiebalk />
      </div>
    <div class="contacts">
      <h3>Contacts</h3>
      <ul>
        <li class="contact">Panneellid 1</li>
        <li class="contact">Bedrijf XYZ</li>
        <li class="contact">Panneellid 2</li>
      </ul>

    </div>

    

    <div class="chat-content">
      <div class="chat-header">
        <h2>Chat met <span class="current-contact">Panneellid 1</span></h2>
      </div>
      
      <div class="chat-messages">
      </div>

      <div class="chat-input">
       <input type="text" placeholder="Typ uw bericht..."/> 
        <button>Verstuur</button>
      </div>
    </div>
  </div>
    )
}