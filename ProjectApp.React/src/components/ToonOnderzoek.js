import React, { useEffect, useState } from "react";

function FetchData() {
  const [onderzoek, setOnderzoeken] = useState([]);

  useEffect(() => {
    fetch('/api/Onderzoek/2')
      .then(response => response.json())
      .then(data => setOnderzoeken(data))
      .catch(err => console.log(err));
  }, []);

  return (
    <div>
      <h1>Onderzoeken</h1>
      <div>
            <strong>ID:</strong> {onderzoek.id}<br />
            <strong>Titel:</strong> {onderzoek.titel}<br />
            <strong>Beschrijving:</strong> {onderzoek.beschrijving}<br />
            <strong>Onderzoeksdatum:</strong> {onderzoek.onderzoeksdatum}<br />
            <strong>Tijdslimiet:</strong> {onderzoek.tijdslimiet}<br />
            <strong>Soortonderzoek:</strong> {onderzoek.soortOnderzoek}<br />
            <strong>Hoeveelheid deelnemers:</strong> {onderzoek.hoeveelheidDeelnemers}<br />
            <strong>Beloning:</strong> {onderzoek.beloning}<br />
            <strong>Status:</strong> {onderzoek.status}<br />
      </div>
    </div>
  );
}

export default FetchData;
