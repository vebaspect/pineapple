import React from 'react';

import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

const Home = () => {
  return (
    <List component="nav">
      <ListItem button>
        <ListItemText>
          Strona główna
        </ListItemText>
      </ListItem>
    </List>
  )
}

export default Home;
