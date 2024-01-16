import React, { useState } from 'react';

const ProfielFormulier = () => {
  const [gegevens, setGegevens] = useState({
    voornaam: '',
    achternaam: '',
    adres: '',
    postcode: '',
    telefoonnummer: '',
    // Voeg andere velden toe indien nodig...
  });

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('api/gebruiker/profiel-wijzigen', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gegevens),
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

  return (
    <form onSubmit={handleSubmit} className="profiel-formulier">
      <label>
        Voornaam:
        <input type="text" name="voornaam" value={gegevens.voornaam} onChange={handleChange} required />
      </label>
      <br />
      <label>
        Achternaam:
        <input type="text" name="achternaam" value={gegevens.achternaam} onChange={handleChange} required />
      </label>
      <br />
      <label>
        Adres:
        <input type="text" name="adres" value={gegevens.adres} onChange={handleChange} required />
      </label>
      <br />
      <label>
        Postcode:
        <input type="text" name="postcode" value={gegevens.postcode} onChange={handleChange} required />
      </label>
      <br />
      <label>
        Telefoonnummer:
        <input type="tel" name="telefoonnummer" value={gegevens.telefoonnummer} onChange={handleChange} required />
      </label>
      <br />
      <br />
      <button type="submit">Opslaan</button>
    </form>
  );
};

export default ProfielFormulier;
