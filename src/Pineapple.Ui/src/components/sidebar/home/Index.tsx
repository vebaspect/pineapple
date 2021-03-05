import React from 'react';
import { Link } from "react-router-dom";

import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import HomeIcon from '@material-ui/icons/Home';

const Home = () => {
  return (
    <ListItem button>
      <ListItemIcon>
        <HomeIcon />
      </ListItemIcon>
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
