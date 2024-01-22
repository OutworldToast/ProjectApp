// UserList.js
import React, { useState, useEffect } from 'react';

const UserList = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch('api/Panellid/')
      .then((response) => response.json())
      .then((data) => setUsers(data))
      .catch((error) => console.error('Error fetching users:', error));
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
    </div>
  );
};

export default UserList;
