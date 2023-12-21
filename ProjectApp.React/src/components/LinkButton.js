import React from 'react';
import { Link } from 'react-router-dom';

const LinkButton = () => {
    return (
        <Link to="/HomePage">
            <button>Home</button>
        </Link>
    );
};

export default LinkButton;
