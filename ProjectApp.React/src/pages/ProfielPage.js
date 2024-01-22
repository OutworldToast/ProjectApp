import React, { useState, useEffect } from 'react';

const ProfielFormulier = () => {
  const [gegevens, setGegevens] = useState({
    voornaam: '',
    achternaam: '',
    adres: '',
    postcode: '',
    telefoonnummer: '',
    beperkingId: '',
    id: '16',
  });

  const [beperkingen, setBeperkingen] = useState([]);
  const [wijzigingStatus, setWijzigingStatus] = useState(null); // Toegevoegde staat voor wijzigingsstatus

  useEffect(() => {
    fetch('api/Beperking')
      .then(response => response.json())
      .then(data => setBeperkingen(data))
      .catch(error => console.error('Fout bij het ophalen van beperkingen:', error));
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const gevuldeGegevens = Object.fromEntries(
      Object.entries(gegevens).filter(([_, value]) => value !== '')
    );

    try {
      const response = await fetch('api/Panellid/16', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gevuldeGegevens),
      });

      if (response.ok) {
        console.log('Profiel succesvol gewijzigd');
        setWijzigingStatus('success'); // Set wijzigingsstatus op 'success' bij succes
      } else {
        const fouten = await response.json();
        console.error('Fout bij het wijzigen van het profiel:', fouten);
        setWijzigingStatus('failure'); // Set wijzigingsstatus op 'failure' bij mislukking
      }
    } catch (error) {
      console.error('Er is een fout opgetreden:', error.message);
      setWijzigingStatus('failure'); // Set wijzigingsstatus op 'failure' bij mislukking
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
      {wijzigingStatus === 'success' && <div style={{ color: 'green' }}>Profiel succesvol gewijzigd!</div>}
      {wijzigingStatus === 'failure' && <div style={{ color: 'red' }}>Fout bij het wijzigen van het profiel. Probeer opnieuw.</div>}
      
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
        <select name="beperkingId" value={gegevens.beperkingId} onChange={handleChange}>
          <option value="">Selecteer een beperking</option>
          {beperkingen.map(beperking => (
            <option key={beperking.id} value={beperking.id}>
              {beperking.categorie}
            </option>
          ))}
        </select>
      </label>

      <button type="submit">Opslaan</button>
    </form>
  );
};

export default ProfielFormulier;


