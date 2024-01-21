import React, { useEffect, useState } from "react";

function FetchData({id = 1}) {
  const [onderzoeken, setOnderzoeken] = useState([]);

  useEffect(() => {

    fetch(`api/Gebruiker/${id}/deelnames`)
      .then(response => response.json())
      .then(data => setOnderzoeken(data))
      .catch(err => console.log(err));
  }, [id]);

  return (
    <div>
      {onderzoeken.length > 0 ? (
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
          </li>
        ))}
      </ul>
      ) : (
        <h3>Geen onderzoeken gevonden</h3>
      )}
    </div>
  );
}

export default FetchData;
