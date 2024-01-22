// ResearchList.js
import React, { useState, useEffect } from 'react';

const ResearchList = () => {
  const [research, setResearch] = useState([]);
  const [selectedBeperking, setSelectedBeperking] = useState(null);
  const [beperkingen, setBeperkingen] = useState([]);

  useEffect(() => {
    // Haal de lijst met beperkingen op
    fetch('api/Beperking')
      .then((response) => response.json())
      .then((data) => setBeperkingen(data))
      .catch((error) => console.error('Error fetching beperkingen:', error));

    // Haal de onderzoeken op
    fetch('api/Onderzoek')
      .then((response) => response.json())
      .then((data) => setResearch(data))
      .catch((error) => console.error('Error fetching onderzoeken:', error));
  }, []);

  const handleFilterResearch = () => {
    if (selectedBeperking) {
      fetch(`api/Onderzoek/Beperking/?id=${selectedBeperking}`)
        .then((response) => response.json())
        .then((data) => setResearch(data))
        .catch((error) => console.error('Error filtering onderzoeken:', error));
    } else {
      // Geen beperking geselecteerd, toon alle onderzoeken
      fetch('api/Onderzoek')
        .then((response) => response.json())
        .then((data) => setResearch(data))
        .catch((error) => console.error('Error fetching onderzoeken:', error));
    }
  };

  const handleDeleteResearch = (researchId) => {
    fetch(`api/Onderzoek/${researchId}`, {
      method: 'DELETE',
    })
      .then(() => {
        // Update de onderzoekenlijst zonder het verwijderde onderzoek
        setResearch(research.filter((onderzoek) => onderzoek.id !== researchId));
      })
      .catch((error) => console.error('Error deleting onderzoek:', error));
  };

  return (
    <div>
      <h2>Onderzoeken</h2>
      <label>
        Filter op beperking:
        <select onChange={(e) => setSelectedBeperking(e.target.value)}>
          <option value="">Geen filter</option>
          {beperkingen.map((beperking) => (
            <option key={beperking.id} value={beperking.id}>
              {beperking.categorie}
            </option>
          ))}
        </select>
      </label>
      <button onClick={handleFilterResearch}>Filter</button>
      <ul>
        {research.map((onderzoek) => (
          <li key={onderzoek.id}>
            {onderzoek.titel} -{' '}
            <button onClick={() => handleDeleteResearch(onderzoek.id)}>Verwijder</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ResearchList;
