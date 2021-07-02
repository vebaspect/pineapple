import React from 'react';
import { Link as RouterLink, useLocation } from 'react-router-dom';

import Link from '@material-ui/core/Link';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import HomeIcon from '@material-ui/icons/Home';

const Home: React.VFC = () => {
  const location = useLocation();

  let homeListItemStyle = {};
  switch (location.pathname) {
    case '/': {
      homeListItemStyle = { 
        backgroundColor: '#f2f4ff',
      };
      break;
    }
    default:
      break;
  }

  return (
    <ListItem
      button
      style={homeListItemStyle}
    >
      <ListItemIcon>
        <HomeIcon color="primary" />
      </ListItemIcon>
      <ListItemText>
        <Link
          component={RouterLink}
          to="/"
        >
          Strona główna
        </Link>
      </ListItemText>
    </ListItem>
  )
}

export default Home;
