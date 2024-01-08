import React from 'react';
import { Link } from 'react-router-dom';

const LinkButton = ({link,body}) => {
    return (
        <Link to={link}>
            <button>{body}</button>
        </Link>
    );


};

export default LinkButton;
