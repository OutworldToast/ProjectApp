import React, { useEffect, useState } from "react";
//moet ge algemeniseerd worden voor de fetch
function FetchData() {
  const [onderzoeken, setOnderzoeken] = useState([]);

  useEffect(() => {
    fetch('/api/Onderzoek/')
      .then(response => response.json())
      .then(data => setOnderzoeken(data))
      .catch(err => console.log(err));
  }, []);

  return (
    <div>
      <h1>Onderzoeken</h1>
      <ul>
        {onderzoeken.map((onderzoek, index) => (
          <li key={index}>
            <strong>ID:</strong> {onderzoek.id}<br />
            <strong>Titel:</strong> {onderzoek.titel}<br />
            <strong>Beschrijving:</strong> {onderzoek.beschrijving}<br />
            <strong>Onderzoeksdatum:</strong> {onderzoek.onderzoeksdatum}<br />
            <strong>Tijdslimiet:</strong> {onderzoek.tijdslimiet}<br />
            <strong>Soortonderzoek:</strong> {onderzoek.soortOnderzoek}<br />
            <strong>Hoeveelheid deelnemers:</strong> {onderzoek.hoeveelheidDeelnemers}<br />
            <strong>Beloning:</strong> {onderzoek.beloning}<br />
            <strong>Status:</strong> {onderzoek.status}<br />
            
            {/* Voeg andere eigenschappen toe zoals gewenst */}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default FetchData;
