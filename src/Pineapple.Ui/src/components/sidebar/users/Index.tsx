import React, { useState } from 'react';
import { Link } from "react-router-dom";

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
  const [isExpanded, setIsExpanded] = useState(false);

  const onHeaderClick = () => {
    setIsExpanded(!isExpanded);
  };

  if (!isDevelopersCountFetched && !isOperatorsCountFetched && !isManagersCountFetched && !isAdministratorsCountFetched) {
    return (
      <ListItem>
        <ListItemText>
          Użytkownicy
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem button onClick={onHeaderClick}>
        <ListItemText>
          <Link
            to="/users"
            style={{ textDecoration: 'none'}}
          >
            Użytkownicy
          </Link>
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse in={isExpanded}>
        <List component="div">
          <ListItem button>
            <ListItemText>
              <Link
                to="/developers"
                style={{ textDecoration: 'none'}}
              >
                Programiści ({developersCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                to="/operators"
                style={{ textDecoration: 'none'}}
              >
                Wdrożeniowcy ({operatorsCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                to="/managers"
                style={{ textDecoration: 'none'}}
              >
                Menedżerowie ({managersCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                to="/administrators"
                style={{ textDecoration: 'none'}}
              >
                Administratorzy ({administratorsCount})
              </Link>
            </ListItemText>
          </ListItem>
        </List>
      </Collapse>
    </>
  )
}

export default Users;
