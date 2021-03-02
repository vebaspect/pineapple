import React, { useState } from 'react';

import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import Tooltip from '@material-ui/core/Tooltip';

interface Props {
  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  isDataFetched: boolean,
  // Lista wdrożeń.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Opis.
    description: string,
  }[];
};

const Implementations = ({ isDataFetched, data }: Props) => {
  // Flaga określająca, czy lista produktów jest rozwinięta.
  const [isExpanded, setIsExpanded] = React.useState(true);

  const onHeaderClick = () => {
    setIsExpanded(!isExpanded);
  };

  if (!isDataFetched) {
    return (
      <List component="nav">
        <ListItem>
          <ListItemText>
            Wdrożenia
          </ListItemText>
          <CircularProgress size={20} />
        </ListItem>
      </List>
    );
  }

  return (
    <List component="nav">
      <ListItem button onClick={onHeaderClick}>
        <ListItemText>
          Wdrożenia ({data.length})
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse in={isExpanded}>
        <List component="div">
          {
            data.length > 0
            ? data.map(implementation => {
              return (
                <Tooltip key={implementation.id} title={implementation.description} placement="right">
                  <ListItem button>
                    <ListItemText>
                      {implementation.name}
                    </ListItemText>
                  </ListItem>
                </Tooltip>
              )
            })
            : null
          }
        </List>
      </Collapse>
    </List>
  )
}

export default Implementations;
