import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import '../CSS/Light.css';

const OnderzoekFormulier = () => {

  const navigate = useNavigate();

  const [gegevens, setGegevens] = useState({
    titel: '',
    beschrijving: '',
    onderzoeksdatum: '',
    soortonderzoek: '',
    beloning: '',
    tijdslimiet: '',
    hoeveelheiddeelnemers: '',
    beperkingid: '', 
    bedrijfid: '13',
  });

  const [beperkingen, setBeperkingen] = useState([]);

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

      if (response.ok) {//moet doorgegeven aan gebruiker
        console.log('Onderzoek geplaatst');
      } else {
        const fouten = await response.json();
        console.error('Fout bij het wijzigen van het profiel:', fouten);
      }
    } catch (error) {
      console.error('Er is een fout opgetreden:', error.message);
    }

    {/*navigate('/Homepage');*/}

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
        {/*validatie nodig*/}
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