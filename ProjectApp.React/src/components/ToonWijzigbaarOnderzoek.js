import React, { useEffect, useState } from "react";

function FetchData() {
  const [onderzoek, setOnderzoek] = useState([]);
  const [deelname, setDeelname] = useState({
    panellidid: '12',
    onderzoekid: '',
  });

  const handleOnderzoek = (data) => {
    setDeelname((prevDeelname) => ({
      ...prevDeelname,
      onderzoekid: data.id,
    }));

    setOnderzoek(data);
  }

  const handleGebruiker = (data) => {
    setDeelname((prevDeelname) => ({
      ...prevDeelname,
      panellidid: data.id,
    }))
  }

  useEffect(() => {
    fetch('/api/Onderzoek/4')
      .then(response => response.json())
      .then(data => handleOnderzoek(data))
      .catch(err => console.log(err));

    fetch('/api/Gebruiker/current')
      .then(response => response.json())
      .then(data => handleGebruiker(data))
      .catch(err => console.log(err));
  }, []);
  
  function handleClick(){

    fetch('/api/Deelname', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(deelname),
    });
  }

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
            <strong>Beloning:</strong> {onderzoek.beloning}<br />
            <strong>Status:</strong> {onderzoek.status}<br />
      </div>
      <div>
        <button onClick = {handleClick}>Neem deel</button>
      </div>
    </div>
  );
}

export default FetchData;
