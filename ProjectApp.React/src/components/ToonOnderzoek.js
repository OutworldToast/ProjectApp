import React, { useEffect, useState } from "react";

function FetchData() {
  const [onderzoek, setOnderzoek] = useState([]);

  useEffect(() => {
    fetch('/api/Onderzoek/10')
      .then(response => response.json())
      .then(data => setOnderzoek(data))
      .catch(err => console.log(err));
  }, []);


  return (
    <div>
      <h1>Onderzoek</h1>
      <div>
            <strong>ID:</strong> {onderzoek.id}<br />
            <strong>Titel:</strong> {onderzoek.titel}<br />
            <strong>Beschrijving:</strong> {onderzoek.beschrijving}<br />
            <strong>Onderzoeksdatum:</strong> {onderzoek.onderzoeksdatum}<br />
            <strong>Tijdslimiet:</strong> {onderzoek.tijdslimiet}<br />
            <strong>Soortonderzoek:</strong> {onderzoek.soortOnderzoek}<br />
            <strong>Hoeveelheid deelnemers:</strong> {onderzoek.hoeveelheidDeelnemers}<br />
            <strong>Beloning:</strong> {onderzoek.beloning} <strong>€</strong><br />
            <strong>Status:</strong> {onderzoek.status}<br />
      </div>
      <button>
      <li><a href='OnderzoekPage'>Onderzoek</a></li>
      </button>
    </div>
  );
}

export default FetchData;
