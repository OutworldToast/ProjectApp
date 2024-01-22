import React, { useState, useEffect } from 'react';

const UserList = () => {
  const [users, setUsers] = useState([]);
  const [companies, setCompanies] = useState([]);

  useEffect(() => {
    // Fetch gewone gebruikers
    fetch('api/Panellid/')
      .then((response) => response.json())
      .then((data) => setUsers(data))
      .catch((error) => console.error('Error fetching users:', error));

    fetch('api/Bedrijf/')
      .then((response) => response.json())
      .then((data) => setCompanies(data))
      .catch((error) => console.error('Error fetching companies:', error));
  }, []);

  const handleDeleteUser = (userId) => {
    fetch(`api/Panellid/${userId}`, {
      method: 'DELETE',
    })
      .then(() => {
        // Update de gebruikerslijst zonder de verwijderde gebruiker
        setUsers(users.filter((user) => user.id !== userId));
      })
      .catch((error) => console.error('Error deleting user:', error));
  };

  const handleDeleteCompany = (companyId) => {
    fetch(`api/Bedrijf/${companyId}`, {
      method: 'DELETE',
    })
      .then(() => {
        // Update de bedrijfsgebruikerslijst zonder de verwijderde bedrijfsgebruiker
        setCompanies(companies.filter((company) => company.id !== companyId));
      })
      .catch((error) => console.error('Error deleting company:', error));
  };

  return (
    <div>
      <h2>Gebruikers</h2>
      <ul>
        {users.map((user) => (
          <li key={user.id}>
            {user.voornaam} -{' '}
            <button onClick={() => handleDeleteUser(user.id)}>Verwijder</button>
          </li>
        ))}
      </ul>

      <h2>Bedrijfsgebruikers</h2>
      <ul>
        {companies.map((company) => (
          <li key={company.id}>
            {company.id} -{' '}
            <button onClick={() => handleDeleteCompany(company.id)}>Verwijder</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default UserList;
