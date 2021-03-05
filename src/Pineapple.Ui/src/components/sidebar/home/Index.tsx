import React from 'react';
import { Link } from "react-router-dom";

import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

const Home = () => {
  return (
    <ListItem button>
      <ListItemText>
        <Link
          to="/"
          style={{ textDecoration: 'none'}}
        >
          Strona główna
        </Link>
      </ListItemText>
    </ListItem>
  )
}

export default Home;
