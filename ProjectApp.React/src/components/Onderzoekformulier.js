import React, { useState, useEffect } from 'react';
import '../CSS/Light.css';

const OnderzoekFormulier = () => {
  const [gegevens, setGegevens] = useState({
    titel: '',
    beschrijving: '',
    onderzoeksdatum: '',
    soortonderzoek: '',
    beloning: '',
    tijdslimiet: '',
    hoeveelheiddeelnemers: '',
    beperkingid: '', 
    bedrijfid: '17',
  });

  const [beperkingen, setBeperkingen] = useState([]);
  const [succesMelding, setSuccesMelding] = useState(null);

  useEffect(() => {
    fetch('/api/Beperking')
      .then(response => response.json())
      .then(data => setBeperkingen(data))
      .catch(err => console.log(err));
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const gevuldeGegevens = Object.fromEntries(
      Object.entries(gegevens).filter(([_, value]) => value !== '')
    );

    try {
      const response = await fetch('api/Onderzoek', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(gevuldeGegevens),
      });

      if (response.ok) {
        console.log('Onderzoek geplaatst');
        setSuccesMelding('Onderzoek succesvol geplaatst!');
        // Reset het formulier na succesvolle plaatsing
        setGegevens({
          titel: '',
          beschrijving: '',
          onderzoeksdatum: '',
          soortonderzoek: '',
          beloning: '',
          tijdslimiet: '',
          hoeveelheiddeelnemers: '',
          beperkingid: '', 
          bedrijfid: '17',
        });
      } else {
        const fouten = await response.json();
        console.error('Fout bij het plaatsen van het onderzoek:', fouten);
        setSuccesMelding('Fout bij het plaatsen van het onderzoek. Probeer opnieuw.');
      }
    } catch (error) {
      console.error('Er is een fout opgetreden:', error.message);
      setSuccesMelding('Fout bij het plaatsen van het onderzoek. Probeer opnieuw.');
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
      beperkingid: e.target.value,
    }));
  };

  return (
    <form onSubmit={handleSubmit} className="onderzoek-formulier">
      {succesMelding && <div style={{ color: 'green' }}>{succesMelding}</div>}

      <label>
      Titel:
      <input type="text" name="titel" value={gegevens.titel} onChange={handleChange}/>
      </label>
      <br />
      <label>
      Beschrijving:
      <input type="text" name="beschrijving" value={gegevens.beschrijving} onChange={handleChange} />
      </label>
      <br />
      <label>
      Soortonderzoek:
      <input type="text" name="soortonderzoek" value={gegevens.soortonderzoek} onChange={handleChange} />
      </label>
      <br />
      <label>
      Beloning:
      <input type="text" name="beloning" value={gegevens.beloning} onChange={handleChange} />
      </label>
      <br />
      <label>
      Onderzoeksdatum:
      <input type="datetime-local" name="onderzoeksdatum" value={gegevens.onderzoeksdatum} onChange={handleChange} />
      </label>
      <br />
      <label>
      validatie nodig*
      Tijdslimiet:
      <input type="datetime-local" name="tijdslimiet" value={gegevens.tijdslimiet} onChange={handleChange} />
      </label>
      <br />
      <label>
      Hoeveelheiddeelnemers:
      <input type="tel" name="hoeveelheiddeelnemers" value={gegevens.hoeveelheiddeelnemers} onChange={handleChange}/>
      </label>

      <label>
      Beperking:
      <select name="beperkingId" value={gegevens.beperkingid} onChange={handleBeperkingChange}>
        <option value="">Selecteer een beperking</option>
        {beperkingen.map(beperking => (
          <option key={beperking.id} value={beperking.id}>
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

export default OnderzoekFormulier;


