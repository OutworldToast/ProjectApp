import React, { useState, useEffect } from 'react';

const ProfielFormulier = () => {
  const [gegevens, setGegevens] = useState({
    voornaam: '',
    achternaam: '',
    adres: '',
    postcode: '',
    telefoonnummer: '',
    geselecteerdeBeperking: '', // Nieuw veld voor de geselecteerde beperking
    // Voeg andere velden toe indien nodig...
  });

  const [beperkingen, setBeperkingen] = useState([]);

  useEffect(() => {
    // Fetch beperkingen en zet ze in de state
    fetch('/api/Beperking')
      .then(response => response.json())
      .then(data => setBeperkingen(data))
      .catch(err => console.log(err));
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Filter alleen de ingevulde velden
    const gevuldeGegevens = Object.fromEntries(
      Object.entries(gegevens).filter(([_, value]) => value !== '')
    );

    try {
      const response = await fetch('api/gebruiker/profiel-wijzigen', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gevuldeGegevens),
      });

      if (response.ok) {
        console.log('Profiel succesvol gewijzigd');
      } else {
        const fouten = await response.json();
        console.error('Fout bij het wijzigen van het profiel:', fouten);
      }
    } catch (error) {
      console.error('Er is een fout opgetreden:', error.message);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setGegevens((prevGegevens) => ({
      ...prevGegevens,
      [name]: value,
    }));
  };

  const handleBeperkingChange = (e) => {
    setGegevens((prevGegevens) => ({
      ...prevGegevens,
      geselecteerdeBeperking: e.target.value,
    }));
  };

  return (
    <form onSubmit={handleSubmit} className="profiel-formulier">
      <label>
        Voornaam:
        <input type="text" name="voornaam" value={gegevens.voornaam} onChange={handleChange}/>
      </label>
      <br />
      <label>
        Achternaam:
        <input type="text" name="achternaam" value={gegevens.achternaam} onChange={handleChange} />
      </label>
      <br />
      <label>
        Adres:
        <input type="text" name="adres" value={gegevens.adres} onChange={handleChange} />
      </label>
      <br />
      <label>
        Postcode:
        <input type="text" name="postcode" value={gegevens.postcode} onChange={handleChange} />
      </label>
      <br />
      <label>
        Telefoonnummer:
        <input type="tel" name="telefoonnummer" value={gegevens.telefoonnummer} onChange={handleChange}/>
      </label>
      
      <label>
        Beperking:
        <select name="geselecteerdeBeperking" value={gegevens.geselecteerdeBeperking} onChange={handleBeperkingChange}>
          <option value="">Selecteer een beperking</option>
          {beperkingen.map((beperking, index) => (
            <option key={index} value={beperking.categorie}>
              {beperking.categorie}
            </option>
          ))}
        </select>
      </label>
      <br />
      
      <button type="submit">Opslaan</button>
    </form>
  );
};

export default ProfielFormulier;
