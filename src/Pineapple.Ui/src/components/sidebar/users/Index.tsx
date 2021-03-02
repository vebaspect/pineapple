import React, { useState } from 'react';

import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

interface Props {
  // Flaga określająca, czy liczba programistów została pobrana z API.
  isDevelopersCountFetched: boolean,
  // Liczba programistów.
  developersCount: number;
  // Flaga określająca, czy liczba wdrożeniowców została pobrana z API.
  isOperatorsCountFetched: boolean,
  // Liczba wdrożeniowców.
  operatorsCount: number;
  // Flaga określająca, czy liczba menedżerów pobrana z API.
  isManagersCountFetched: boolean,
  // Liczba menedżerów.
  managersCount: number;
  // Flaga określająca, czy liczba administratorów została pobrana z API.
  isAdministratorsCountFetched: boolean,
  // Liczba administratorów.
  administratorsCount: number;
};

const Users = ({ isDevelopersCountFetched, developersCount, isOperatorsCountFetched, operatorsCount, isManagersCountFetched, managersCount, isAdministratorsCountFetched, administratorsCount }: Props) => {
  // Flaga określająca, czy konfiguracja jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(true);

  const onHeaderClick = () => {
    setIsExpanded(!isExpanded);
  };

  if (!isDevelopersCountFetched && !isOperatorsCountFetched && !isManagersCountFetched && !isAdministratorsCountFetched) {
    return (
      <List component="nav">
        <ListItem>
          <ListItemText>
            Użytkownicy
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
          Użytkownicy
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse in={isExpanded}>
        <List component="div">
          <ListItem button>
            <ListItemText>
              Programiści ({developersCount})
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              Wdrożeniowcy ({operatorsCount})
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              Menedżerowie ({managersCount})
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              Administratorzy ({administratorsCount})
            </ListItemText>
          </ListItem>
        </List>
      </Collapse>
    </List>
  )
}

export default Users;
